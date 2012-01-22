using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Net;

namespace QoD_DataCentre.Modules
{
    public partial class Welcome : UserControl
    {
        public Welcome()
        {
            InitializeComponent();

            bool error = false;

            //based on code from http://www.haiders.net/post/C-RSS-Feed-Fetcher-Display-RSS-Feed-with-2-lines-of-Code.aspx
            string rssXml = "http://smartphone-quadrotor.blogspot.com/feeds/posts/default?alt=rss";

            XDocument doc = null;

            try
            {
                doc = XDocument.Load(rssXml);
            }
            catch(WebException e)
            {
                richTextBox1.Text = "Error getting feed. Check that you are connected to the internet.";
                error = true;
            }

            if (!error)
            {
                IEnumerable<FeedResult> rssFeed = from el in doc.Elements("rss").Elements("channel").Elements("item")
                              select new FeedResult
                              {
                                  Title = el.Element("title").Value,
                                  Link = el.Element("link").Value,
                                  Description = el.Element("description").Value
                              };

                IEnumerator<FeedResult> enumerator = rssFeed.GetEnumerator();
                
                richTextBox1.Text = "";

                foreach (FeedResult f in rssFeed)
                {
                    if (f.Title.Equals(""))
                    {
                        richTextBox1.Text += "Untitled";
                    }
                    else
                    {
                        richTextBox1.Text += f.Title;
                    }
                    richTextBox1.Text += Environment.NewLine;
                    richTextBox1.Text += f.Description;
                    richTextBox1.Text += Environment.NewLine;
                    richTextBox1.Text += Environment.NewLine;
                    string stripped = Regex.Replace(richTextBox1.Text, @"<(.|\n)*?>", string.Empty);

                    richTextBox1.Text = stripped;
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://smartphone-quadrotor.blogspot.com/");
        }
    }

    public class FeedResult
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
    }
}
