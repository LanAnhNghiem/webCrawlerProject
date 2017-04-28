using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HtmlAgilityPack;
using unirest_net.http;
using unirest_net.request;
using Newtonsoft.Json.Linq;
using System.Xml;

namespace WebCrawlerProject
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer tm;
        private List<String> listLinks = new List<String>();
        private int SoUrl;
        private int SoCau;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            XmlTextReader xml = new XmlTextReader("ThamSo.xml");
            while(xml.Read())
            {
                if(xml.Name=="SoUrl")
                {
                    SoUrl = xml.ReadElementContentAsInt();
                }
                if(xml.Name=="SoCau")
                {
                    SoCau = xml.ReadElementContentAsInt();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            loadingPage();
            
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listBox1.Items.Clear();
                loadingPage();
            }
        }
        

        private void loadingPage()
        {
            String link;
            link = "https://www.google.com.vn/#q=" + textBox1.Text + "&num="+SoUrl.ToString();

            webBrowser1.Navigate(link);
            tm = new System.Windows.Forms.Timer();
            tm.Interval = 3000;
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
            List<string> titles = new List<string>();
            String url = "";
            String title = "";
            if (link.Count > 0)
            {
                for (int i = 0; i < link.Count; i++)
                {
                    if (link[i].OuterHtml.Contains("onmousedown") && !link[i].OuterHtml.Contains("class=\"fl\"") & !link[i].OuterHtml.Contains("google"))
                    {
                        url = System.Uri.UnescapeDataString(link[i].GetAttribute("href"));
                        listBox1.Items.Add(url);
                        listLinks.Add(url);
                        title = System.Uri.UnescapeDataString(link[i].InnerHtml);
                        titles.Add(title);
                    }
                }
                createContent();
                //tom tat van ban 
                summarize();
            }
            else
            {
                loadingPage();
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
        
        
        
        private string getText(HtmlAgilityPack.HtmlDocument doc)
        {
            string text = "";
            
            string HTML = doc.DocumentNode.InnerHtml;
            string[] pattern = new string[] { @"<script[^>]*>[\s\S]*?</script>", @"<style[^>]*>[\s\S]*?</style>", @"<!--[\s\S]*?-->", @"<form[^>]*>[\s\S]*?</form>", @"&[\s\S]*?;" };
            Regex regex = new Regex(string.Join("|", pattern), RegexOptions.IgnoreCase);
            HTML = regex.Replace(HTML, "");
            doc.LoadHtml(HTML);
            
            foreach (HtmlNode p in doc.DocumentNode.Descendants("p").ToArray())
            {
                text += p.InnerText + " ";
            }

            return text;
        }

        string content = "";
        private void createContent()
        {
            string text = "";
            content = "";


            HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

                for (int i = 0; i < listLinks.Count; i++)
                {
                    try
                    {
                        //url = System.Uri.UnescapeDataString(listLinks[i]);
                        doc = web.Load(listLinks[i]);
                        text = getText(doc);
                    }
                    catch
                    {
                        text = "";
                    }

                    content += text + "\r\n\n-------------------------------------------------------------------------------\r\n\n";
                }


            // Xoa danh sach link cu trong listBox1 de load link moi cho lan search sau
            listLinks.Clear();
            
        }

        private void summarize()
        {
            

            HttpResponse<String> response = Unirest.post("https://textanalysis-text-summarization.p.mashape.com/text-summarizer-text")
                .header("X-Mashape-Authorization", "omFDgdAsRAmshCbOhXoIKwsebnAEp14idUOjsn2UxGevxvi8Y8")
                //.header("Content-Type", "application/x-www-form-urlencoded")
                .header("Accept", "application/json")
                .field("sentnum", SoCau)
                .field("text", content)
                .asJson<String>();
        //       richTextBox1.Text = System.Text.RegularExpressions.Regex.Unescape(response.Body);
            JObject json = JObject.Parse(response.Body);

            string k = "";
            for (int i = 0; i < SoCau; i++)
            {
                k = k + (string)json.SelectToken("sentences[" + i.ToString() + "]") + " ";
            }

            richTextBox1.Text = k;
        }
    }
}
