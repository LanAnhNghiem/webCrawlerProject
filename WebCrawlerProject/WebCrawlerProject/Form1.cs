using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace WebCrawlerProject
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer tm;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //num = Int32.Parse(textBox2.Text);
            listBox1.Items.Clear();
            loadingPage();

        }

        private void loadingPage()
        {
            String link;
            link = "https://www.google.com.vn/#q=" + textBox1.Text + "&num=200";
            webBrowser1.Navigate(link);
            tm = new System.Windows.Forms.Timer();
            tm.Interval = 2000;
            tm.Tick += new EventHandler(tm_Tick);

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tm.Start();
        }
        private void tm_Tick(object sender, EventArgs e)
        {
            tm.Stop();
            listLink();

        }
        void listLink()
        {

            HtmlElementCollection link = webBrowser1.Document.Links;
            for (int i = 0; i < link.Count; i++)
            {
                if (link[i].OuterHtml.Contains("onmousedown") && !link[i].OuterHtml.Contains("class=\"fl\"") & !link[i].OuterHtml.Contains("google"))
                {
                    String k = System.Uri.UnescapeDataString(link[i].GetAttribute("href"));
                    listBox1.Items.Add(k);
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }


        // Loading content from HTML
        private string getContent(string link)
        {
            string content = "";
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

            try
            {
                if(link.Contains("https://") || link.Contains("http://"))
                    doc = web.Load(link);
                else
                    doc = web.Load("http://" + link);                    
            }
            catch
            {
                return content;
            }

            content = doc.DocumentNode.SelectSingleNode("//body").InnerText;
            
            return content;
        }
    }
}
