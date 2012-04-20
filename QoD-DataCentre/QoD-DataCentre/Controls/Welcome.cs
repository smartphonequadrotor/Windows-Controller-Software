using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Net;

namespace QoD_DataCentre.Modules
{
    public partial class Welcome : UserControl
    {
        public Welcome()
        {
            InitializeComponent();



            //based on code from http://www.haiders.net/post/C-RSS-Feed-Fetcher-Display-RSS-Feed-with-2-lines-of-Code.aspx
            string rssXml = "http://smartphone-quadrotor.blogspot.com/feeds/posts/default?alt=rss";


            richTextBox1.Text = "Loading Feed...";
            rssReader.RunWorkerAsync(rssXml);
         
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://smartphone-quadrotor.blogspot.com/");
        }

        private void rssReader_DoWork(object sender, DoWorkEventArgs e)
        {
                e.Result = XDocument.Load((string)e.Argument);
        }

        private void rssReader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                XDocument doc = ((XDocument)e.Result);
                IEnumerable<FeedResult> rssFeed = from el in doc.Elements("rss").Elements("channel").Elements("item")
                                                  select new FeedResult
                                                  {
                                                      Title = el.Element("title").Value,
                                                      Link = el.Element("link").Value,
                                                      Description = el.Element("description").Value
                                                  };

                IEnumerator<FeedResult> enumerator = rssFeed.GetEnumerator();

                Font largeBoldFont = new Font(richTextBox1.Font.FontFamily, 16, FontStyle.Bold);
                Font normalFont = new Font(richTextBox1.Font.FontFamily, 12, FontStyle.Regular);

                //todo lisa trying to get the bold working -> bold the title, leave the rest
                richTextBox1.Text = "";

                foreach (FeedResult f in rssFeed)
                {
                    richTextBox1.SelectionFont = largeBoldFont;

                    if (f.Title.Equals(""))
                    {
                        richTextBox1.Text += "Untitled";
                    }
                    else
                    {
                        richTextBox1.Text += f.Title;
                    }
                    richTextBox1.Text += Environment.NewLine;
                    richTextBox1.SelectionFont = normalFont;
                    richTextBox1.Text += f.Description;
                    richTextBox1.Text += Environment.NewLine;
                    richTextBox1.Text += Environment.NewLine;
                    string stripped = Regex.Replace(richTextBox1.Text, @"<(.|\n)*?>", string.Empty);

                    richTextBox1.Text = stripped;
                }
            }
            else
            {
                richTextBox1.Text = "Error getting feed. Check that you are connected to the internet.";
            }
        }
    }

    public class FeedResult
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
    }
}
