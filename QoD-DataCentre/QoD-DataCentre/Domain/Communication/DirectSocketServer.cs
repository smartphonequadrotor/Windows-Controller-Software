﻿using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using QoD_DataCentre.Src.UI;
    
    // offered to the public domain for any use with no restriction
    // and also with no warranty of any kind, please enjoy. - David Jeske. 
   
   // simple HTTP explanation
   // http://www.jmarshall.com/easy/http/

namespace QoD_DataCentre.Src.Communication
{
    public class DirectSocketServer
    {
        #region vars
        public TcpClient socket;
        public HttpServer httpServer;

        private Stream inputStream;
        public StreamWriter outputStream;

        public String http_method;
        public String http_url;
        public String http_protocol_versionstring;
        public Hashtable httpHeaders = new Hashtable();
        public String httpBody;

        private static int MAX_POST_SIZE = 10 * 1024 * 1024; // 10MB

        private NetworkCommunicationManager networkCommunicationManager;
        #endregion

        public DirectSocketServer(NetworkCommunicationManager networkCM, TcpClient c, HttpServer h)
        {
            this.socket = c;
            this.httpServer = h;
            this.networkCommunicationManager = networkCM;
        }

        private string streamReadLine(Stream inputStream)
        {
            int next_char;
            string data = "";
            while (true)
            {
                next_char = inputStream.ReadByte();
                if (next_char == '\n') { break; }
                if (next_char == '\r') { continue; }
                if (next_char == -1) { Thread.Sleep(1); continue; };
                data += Convert.ToChar(next_char);
            }
            return data;
        }

        public void process()
        {
            // we can't use a StreamReader for input, because it buffers up extra data on us inside it's
            // "processed" view of the world, and we want the data raw after the headers
            inputStream = new BufferedStream(socket.GetStream());

            // we probably shouldn't be using a streamwriter for all output from handlers either
            outputStream = new StreamWriter(new BufferedStream(socket.GetStream()));
            try
            {
                parseRequest();
                readHeaders();
                readBody();

                if (http_method.Equals("GET"))
                {
                    handleGETRequest();
                }
                else if (http_method.Equals("POST"))
                {
                    handlePOSTRequest();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.ToString());
                writeFailure();
            }
            outputStream.Flush();
            // flush any remaining output
            inputStream = null; outputStream = null;
            socket.Close();
        }

        public void parseRequest()
        {
            String request = streamReadLine(inputStream);
            string[] tokens = request.Split(' ');
            if (tokens.Length != 3)
            {
                throw new Exception("Invalid HTTP request line.");
            }
            http_method = tokens[0].ToUpper();
            http_url = tokens[1];
            http_protocol_versionstring = tokens[2];

            Console.WriteLine("Starting: " + request);
        }

        public void readHeaders()
        {
            Console.WriteLine("readHeaders()");
            String line;
            while ((line = streamReadLine(inputStream)) != null)
            {
                if (line.Equals(""))
                {
                    Console.WriteLine("got headers");
                    return;
                }

                int separator = line.IndexOf(':');
                if (separator == -1)
                {
                    throw new Exception("invalid http header line: " + line);
                }
                String name = line.Substring(0, separator);
                int pos = separator + 1;
                while ((pos < line.Length) && (line[pos] == ' '))
                {
                    pos++; // strip any spaces
                }

                string value = line.Substring(pos, line.Length - pos);
                Console.WriteLine("header: {0}:{1}", name, value);
                httpHeaders[name] = value;
            }
        }

        /// <summary>
        /// Read each line of the body into httpBody. End of read triggered by an empty line.
        /// </summary>
        public void readBody()
        {
            httpBody = "";

            Console.WriteLine("readBody()");
            String line;
            while ((line = streamReadLine(inputStream)) != null)
            {
                if (line.Equals(""))
                {
                    Console.WriteLine("got body");
                    return;
                }

                httpBody += line;

                Console.WriteLine("body is: " + httpBody);
            }
        }

        public void handleGETRequest()
        {
            httpServer.handleGETRequest(this);
        }

        private const int BUF_SIZE = 4096;
        public void handlePOSTRequest()
        {
            // this post data processing just reads everything into a memory stream.
            // this is fine for smallish things, but for large stuff we should really
            // hand an input stream to the request processor. However, the input stream 
            // we hand him needs to let him see the "end of the stream" at this content 
            // length, because otherwise he won't know when he's seen it all! 

            Console.WriteLine("get post data start");
            int content_len = 0;
            MemoryStream ms = new MemoryStream();
            if (this.httpHeaders.ContainsKey("Content-Length"))
            {
                content_len = Convert.ToInt32(this.httpHeaders["Content-Length"]);
                if (content_len > MAX_POST_SIZE)
                {
                    throw new Exception(
                        String.Format("POST Content-Length({0}) too big for this simple server",
                          content_len));
                }
                byte[] buf = new byte[BUF_SIZE];
                int to_read = content_len;
                while (to_read > 0)
                {
                    Console.WriteLine("starting Read, to_read={0}", to_read);

                    int numread = this.inputStream.Read(buf, 0, Math.Min(BUF_SIZE, to_read));
                    Console.WriteLine("read finished, numread={0}", numread);
                    if (numread == 0)
                    {
                        if (to_read == 0)
                        {
                            break;
                        }
                        else
                        {
                            throw new Exception("client disconnected during post");
                        }
                    }
                    to_read -= numread;
                    ms.Write(buf, 0, numread);
                }
                ms.Seek(0, SeekOrigin.Begin);
            }
            Console.WriteLine("get post data end");
            httpServer.handlePOSTRequest(this, new StreamReader(ms));
        }

        public void writeSuccess()
        {
            outputStream.Write("HTTP/1.1 200 OK\r\n");
            outputStream.Write("Content-Type: text/html\r\n");
            outputStream.Write("Connection: close\r\n");
            outputStream.Write("\r\n");
        }

        public void writeFailure()
        {
            outputStream.Write("HTTP/1.1 404 File not found\r\n");
            outputStream.Write("Connection: close\r\n");
            outputStream.Write("\r\n");
        }

        public void writePOST(string content)
        {
            outputStream.Write("POST "+http_url+" HTTP/1.1\r\n");
            outputStream.Write("Content-length: "+content.Length+"\r\n");
            outputStream.Write("\r\n");
            outputStream.Write(content);
        }

        public void writeGET()
        {

        }
    }

    public abstract class HttpServer
    {
        protected DirectSocketServer processor;
        protected int port;
        IPAddress localAddress;
        TcpListener listener;
        bool is_active = true;
        protected NetworkCommunicationManager networkCommunicationManager;

        public HttpServer(NetworkCommunicationManager networkCM, IPAddress localAddress, int port)
        {
            this.port = port;
            this.localAddress = localAddress;
            this.networkCommunicationManager = networkCM;
        }

        public void listen()
        {
            try
            {
                listener = new TcpListener(localAddress, port);
                listener.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            while (is_active)
            {
                TcpClient s = null;
                try
                {
                    s = listener.AcceptTcpClient();
                }
                catch (Exception e)
                {
                    if (!is_active)
                    {
                        break;
                    }
                    else
                    {
                        s = listener.AcceptTcpClient();
                    }
                }
                DialogResult result = MessageBox.Show("Accept incoming connection " + s.Client.RemoteEndPoint.ToString().Substring(0, s.Client.RemoteEndPoint.ToString().IndexOf(':')) + " ?", "Incoming Connection", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    processor = new DirectSocketServer(networkCommunicationManager, s, this);
                    Thread thread = new Thread(new ThreadStart(processor.process));
                    thread.Start();
                    QoDMain.networkCommunicationManager.ConnectionStatus = "Connected to " + s.Client.RemoteEndPoint.ToString().Substring(0, s.Client.RemoteEndPoint.ToString().IndexOf(':'));
                }
                Thread.Sleep(1);
            }
        }

        public void disconnect()
        {
            is_active = false;
            listener.Stop();
        }

        public abstract void handleGETRequest(DirectSocketServer p);
        public abstract void handlePOSTRequest(DirectSocketServer p, StreamReader inputData);
    }

    public class MyHttpServer : HttpServer
    {
        public MyHttpServer(NetworkCommunicationManager networkCM, IPAddress localAddress, int port)
            : base(networkCM, localAddress, port)
        {
        }

        public override void handleGETRequest(DirectSocketServer p)
        {
            //DON'T need to implement. ONly handling POSTS!
            Console.WriteLine("TODO: HANDLE GET REQUEST BODY:\n" + p.httpBody);
            p.writeSuccess();
        }

        public override void handlePOSTRequest(DirectSocketServer p, StreamReader inputData)
        {
            networkCommunicationManager.RecieveMessage( inputData.ReadToEnd());
            p.writeSuccess();
        }

        public void WriteGETRequest()
        {
            //DON'T need to implement. ONly handling POSTS!
            processor.writeGET();
            processor.writeSuccess();
        }

        public void WritePOSTRequest(string content)
        {
            processor.writePOST(content);
            processor.writeSuccess();
        }

    }
}