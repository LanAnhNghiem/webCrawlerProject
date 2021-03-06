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
using Quobject.SocketIoClientDotNet.Client;
using System.IO;

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
        private string sub_string = "";
        public static int flat = 0;
        public static int flatedit = 0;
        private int tmInterval;
        private string key;
        private float timespan;
        Socket socket = IO.Socket("https://web-crawler-app.herokuapp.com");
        string backgroundValue;
        string tbFgValue;
        string lbFgValue;
        string btnBgValue;
        public MainWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.CanMinimize;
            checkRegistration();
        }

        private void MainWindow1_Loaded(object sender, RoutedEventArgs e)
        {
            searchBtn.IsEnabled = false;
            if (Properties.Settings.Default.Color == true)
                readMode("D");
            else
                readMode("L");
            editMainColor();
            ReadXmlThamSoEdit();

            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += backgroundWorker_ProgressChanged;
            worker.DoWork += backgroundWorker_DoWork;
            worker.RunWorkerCompleted += backgroundWordker_RunWorkerCompleted;
        }

        private void ReadXmlThamSoEdit()
        {
            XmlTextReader xmledit = new XmlTextReader("ThamSoEdit.xml");
            while (xmledit.Read())
            {
                if (xmledit.Name == "tmInterval")
                {
                    tmInterval = xmledit.ReadElementContentAsInt();
                }
                if (xmledit.Name == "keyrg")
                {
                    key = xmledit.ReadElementContentAsString();
                }
                if (xmledit.Name == "durationTimerg")
                {
                    timespan = xmledit.ReadElementContentAsFloat();
                }
            }
        }
        private void checkRegistration()
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.ID))
            {
                socket.Emit("client-check-registration", (Properties.Settings.Default.ID + "*" + DateTime.Now));
                socket.On("server-reply-registration", data =>
                {
                    string idString = (string)Properties.Settings.Default.ID;
                    if(idString.Substring(idString.Length - 1) == "0")
                    {
                        Properties.Settings.Default.ID = Properties.Settings.Default.ID.Remove(idString.Length - 2);
                        Properties.Settings.Default.Save();
                    }
                    Properties.Settings.Default.ID = Properties.Settings.Default.ID + "*" + data.ToString();
                    Properties.Settings.Default.Save();
                    
                    if (!String.IsNullOrEmpty(idString))
                    {
                        if (!idString.Contains("*") && idString.Substring(idString.Length - 1) != "0")
                        {
                            changeWindow();
                        }
                    }
                    else
                    {
                        changeWindow();
                    }
                });
            }
            else
                changeWindow();
        }
        private void readMode(string mode)
        {
            XmlTextReader xmledit = new XmlTextReader("ThamSoEdit.xml");
            while (xmledit.Read())
            {
                if (xmledit.Name == "BgValue" + mode)
                {
                    backgroundValue = xmledit.ReadElementContentAsString();
                }
                if (xmledit.Name == "tbFgValue" + mode)
                {
                    tbFgValue = xmledit.ReadElementContentAsString();
                }
                if (xmledit.Name == "lbFgValue" + mode)
                {
                    lbFgValue = xmledit.ReadElementContentAsString();
                }
                if (xmledit.Name == "btnBgValue" + mode)
                {
                    btnBgValue = xmledit.ReadElementContentAsString();
                }
            }
            xmledit.Close();
        }
        private void editMainColor()
        {
            BrushConverter brushConverter = new BrushConverter();
            this.Background = (System.Windows.Media.Brush)brushConverter.ConvertFrom(backgroundValue);
            this.resultTxtBox.Background = (System.Windows.Media.Brush)brushConverter.ConvertFrom(backgroundValue);
            this.resultTxtBox.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(tbFgValue);
            this.searchTxtBox.Background = (System.Windows.Media.Brush)brushConverter.ConvertFrom(backgroundValue);
            this.searchTxtBox.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(tbFgValue);
            this.listBox.Background = (System.Windows.Media.Brush)brushConverter.ConvertFrom(backgroundValue);
            this.listBox.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(tbFgValue);
            this.searchBtn.Background = (System.Windows.Media.Brush)brushConverter.ConvertFrom(btnBgValue);
            this.searchBtn.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(tbFgValue);
            this.URLLb.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(tbFgValue);
            this.ResultLb.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(tbFgValue);
        }
        private void changeWindow()
        {
            try
            {
                this.Hide();
                Registration reg = new Registration();
                reg.Show();
                reg.Closing += (sender, args) =>
                {
                    this.Close();
                };
            }catch
            {

            }
            
        }
        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
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
            if (!worker.IsBusy)
            {
                listBox.Items.Clear();
                resultTxtBox.Clear();
                loadingPage();
            }
        }

        private void searchTxtBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                searchBtn_Click(sender, e);
            }
        }
        private void loadingPage()
        {
            String link;

            link = "https://www.google.com.vn/#q=" + searchTxtBox.Text + "&num=" + SoUrl.ToString();

            webBrowser.Navigate(link);
            tm = new System.Windows.Forms.Timer();
            tm.Interval = tmInterval;
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
            string[] lines = File.ReadAllLines("link.txt");
            
            if (link.Count > 0)
            {
                for (int i = 0; i < link.Count; i++)
                {
                    if (link[i].OuterHtml.Contains("onmousedown") && !link[i].OuterHtml.Contains("class=\"fl\"") && !link[i].OuterHtml.Contains("google"))
                    {
                        string url = Uri.UnescapeDataString(link[i].GetAttribute("href"));

                        int j;
                        for(j = 0; j < lines.Count(); j++)
                        {
                            if (url.Contains(lines[j]))
                                break;
                        }

                        if(j==lines.Count())
                        {
                            listBox.Items.Add(url);
                            listLinks.Add(url);
                        }
                    }
                    
                    if (listLinks.Count == SoUrl)
                        break;
                }
                sub_string = searchTxtBox.Text;
                if (!worker.IsBusy)
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
            string[] pattern = new string[] { @"<head>[^>]*>[\s\S]*?</head>", @"<header[^>]*>[\s\S]*?</header>", @"<ul[^>]*>[\s\S]*?</ul>", @"<script[^>]*>[\s\S]*?</script>", @"<style[^>]*>[\s\S]*?</style>", @"<!--[\s\S]*?-->", @"<form[^>]*>[\s\S]*?</form>", @"&[\s\S]*?;", @"<footer[^>]*>[\s\S]*?</footer>", @"<div class=" + "\"footer\">" + @"[^>]*>[\s\S]*?</div>" };
            Regex regex = new Regex(string.Join("|", pattern), RegexOptions.IgnoreCase);
            HTML = regex.Replace(HTML, "");
            doc.LoadHtml(HTML);

            foreach (HtmlNode p in doc.DocumentNode.Descendants("p").ToArray())
            {
                text += p.InnerText.Trim() + " ";
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
                .header("X-Mashape-Authorization", key)
                //.header("Content-Type", "application/x-www-form-urlencoded")
                .header("Accept", "application/json")
                .field("sentnum", SoCau)
                .field("text", content)
                .asJson<String>();
            JObject json = JObject.Parse(response.Body);
            worker.ReportProgress(20);
            double percent = 0;
            result = "";
            for (int i = 0; i < SoCau; i++)
            {
                string contain_string = (string)json.SelectToken("sentences[" + i.ToString() + "]");
                if (contain_string.IndexOf(sub_string,StringComparison.OrdinalIgnoreCase) != -1)
                {
                    result = result + (string)json.SelectToken("sentences[" + i.ToString() + "]") + " ";
                }
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
            Duration duration = new Duration(TimeSpan.FromSeconds(timespan));
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
            flat = flat + 1;
            if (flat == 1)
            {
                HelpWindow helpWindow = new HelpWindow();
                helpWindow.Show();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            flatedit = flatedit + 1;
            if(flatedit==1)
            {
                EditWindow edit = new EditWindow(this);
                edit.Show();

            }
            
        }
    }
}
