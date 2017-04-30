﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using HtmlAgilityPack;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using unirest_net.http;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Windows.Media.Animation;
using System.ComponentModel;

namespace CrawlerAndSummary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Forms.Timer tm;
        private List<String> listLinks = new List<String>();
        private string content = "";
        private int SoUrl;
        private int SoCau;
        private readonly BackgroundWorker worker = new BackgroundWorker();
        private string result = "";
        public MainWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.CanMinimize;
        }

        private void MainWindow1_Loaded(object sender, RoutedEventArgs e)
        {
            searchBtn.IsEnabled = false;
            XmlTextReader xml = new XmlTextReader("ThamSo.xml");
            while (xml.Read())
            {
                if (xml.Name == "SoUrl")
                {
                    SoUrl = xml.ReadElementContentAsInt();
                }
                if (xml.Name == "SoCau")
                {
                    SoCau = xml.ReadElementContentAsInt();
                }
            }
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += backgroundWorker_ProgressChanged;
            worker.DoWork += backgroundWorker_DoWork;
            worker.RunWorkerCompleted += backgroundWordker_RunWorkerCompleted;
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
            resultTxtBox.Clear();
            loadingPage();
        }

        private void searchTxtBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                listBox.Items.Clear();
                loadingPage();
            }
        }
        private void loadingPage()
        {
            String link;
            link = "https://www.google.com.vn/#q=" + searchTxtBox.Text + "&num=" + SoUrl.ToString();

            webBrowser.Navigate(link);
            tm = new System.Windows.Forms.Timer();
            tm.Interval = 3000;
            tm.Tick += new EventHandler(tm_Tick);

        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
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
            HtmlElementCollection link = webBrowser.Document.Links ;
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
                        listBox.Items.Add(url);
                        listLinks.Add(url);
                        title = System.Uri.UnescapeDataString(link[i].InnerHtml);
                        titles.Add(title);
                    }
                }
                if(!worker.IsBusy)
                    worker.RunWorkerAsync();
                this.Cursor = System.Windows.Input.Cursors.Wait;
            }
            else
            {
                loadingPage();
            }
        }

        private void searchTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchTxtBox.Text))
            {
                searchBtn.IsEnabled = false;
            }
            else
            {
                searchBtn.IsEnabled = true;
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

        private void createContent()
        {
            string text = "";
            content = "";
            double percent = 0;
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            for (int i = 0; i < listLinks.Count; i++)
            {
                try
                {
                    doc = web.Load(listLinks[i]);
                    text = getText(doc);
                }
                catch
                {
                    text = "";
                }

                content += text + "\n";
                Thread.Sleep(100);
                percent += 50 / listLinks.Count;
                worker.ReportProgress((int)Math.Ceiling(percent));
                if(i == listLinks.Count -1)
                {
                    if (percent < 50)
                        worker.ReportProgress(50);
                }
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
            JObject json = JObject.Parse(response.Body);
            worker.ReportProgress(20);
            
            double percent = 0;
            for (int i = 0; i < SoCau; i++)
            {
                result = result + (string)json.SelectToken("sentences[" + i.ToString() + "]") + " ";
                percent += 50 / SoCau;
                worker.ReportProgress((int)Math.Ceiling(percent));
            }
            if (percent < 100)
                worker.ReportProgress(100);
            
        }
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            worker.ReportProgress(0);
            createContent();
            summarize();
        }
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Duration duration = new Duration(TimeSpan.FromSeconds(0.5));
            DoubleAnimation animation = new DoubleAnimation(e.ProgressPercentage, duration);
            processBar.BeginAnimation(System.Windows.Controls.ProgressBar.ValueProperty, animation);
        }
        private void backgroundWordker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            resultTxtBox.Text = result;
            this.Cursor = System.Windows.Input.Cursors.Arrow;
        }

        private void copyBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Clipboard.SetText(resultTxtBox.Text);
        }

        private void helpBtn_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.Show();
        }
    }
}