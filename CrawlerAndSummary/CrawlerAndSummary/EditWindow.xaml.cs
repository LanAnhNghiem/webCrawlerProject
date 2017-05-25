using System;
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
using System.Windows.Shapes;
using System.Xml;
using System.Text.RegularExpressions;
using System.Drawing;

namespace CrawlerAndSummary
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        MainWindow mainWin = null;
        string urlLoad;
        string soCauLoad;
        string messagesucc;
        string messageerr;
        string backgroundValue;
        string tbFgValue;
        string lbFgValue;
        string btnBgValue;
        int flatedit = 0;

        private void lightRb_Click(object sender, RoutedEventArgs e)
        {
            readMode("L");
            Properties.Settings.Default.Color = false;
            Properties.Settings.Default.Save();
        }

        private void darkRb_Click(object sender, RoutedEventArgs e)
        {
            readMode("D");
            Properties.Settings.Default.Color = true;
            Properties.Settings.Default.Save();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            string soUrl = txtUrl.Text.Trim();
            string soCau = txtSentences.Text.Trim();

            if (String.IsNullOrWhiteSpace(soUrl) || String.IsNullOrWhiteSpace(soCau) || soUrl == "0" || soCau == "0" || !isNumber(soUrl) || !isNumber(soCau))
            {
                MessageBox.Show(messageerr);
            }
            else
            {
                XmlTextWriter xml = new XmlTextWriter("ThamSo.xml", Encoding.UTF8);
                xml.WriteStartDocument();
                xml.WriteStartElement("ThamSo");
                xml.WriteElementString("SoUrl", soUrl);
                xml.WriteElementString("SoCau", soCau);
                xml.WriteEndElement();
                xml.WriteEndDocument();
                xml.Flush();
                xml.Close();
                editColor();
                editMainColor();
                MessageBox.Show(messagesucc);
                flatedit = 1;
            }
        }

        private void editColor()
        {
            BrushConverter brushConverter = new BrushConverter();
            this.Background = (System.Windows.Media.Brush)brushConverter.ConvertFrom(backgroundValue);
            this.txtUrl.Background = (System.Windows.Media.Brush)brushConverter.ConvertFrom(backgroundValue);
            this.txtUrl.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(tbFgValue);
            this.txtSentences.Background = (System.Windows.Media.Brush)brushConverter.ConvertFrom(backgroundValue);
            this.txtSentences.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(tbFgValue);
            this.soCauLb.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(lbFgValue);
            this.soURLLb.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(lbFgValue);
            this.editBtn.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(tbFgValue);
            this.editBtn.Background = (System.Windows.Media.Brush)brushConverter.ConvertFrom(btnBgValue);
            this.BackgroundLb.Background = (System.Windows.Media.Brush)brushConverter.ConvertFrom(backgroundValue);
            this.BackgroundLb.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(lbFgValue);
            this.groupBox.Background = (System.Windows.Media.Brush)brushConverter.ConvertFrom(backgroundValue);
            this.lightRb.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(lbFgValue);
            this.darkRb.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(lbFgValue);
            this.groupBox.BorderBrush = (System.Windows.Media.Brush)brushConverter.ConvertFrom(lbFgValue);
        }

        private void readMode(string mode)
        {
            XmlTextReader xmledit = new XmlTextReader("ThamSoEdit.xml");
            while (xmledit.Read())
            {
                if (xmledit.Name == "BgValue"+mode)
                {
                    backgroundValue = xmledit.ReadElementContentAsString();
                }
                if (xmledit.Name == "tbFgValue"+mode)
                {
                    tbFgValue = xmledit.ReadElementContentAsString();
                }
                if (xmledit.Name == "lbFgValue"+mode)
                {
                    lbFgValue = xmledit.ReadElementContentAsString();
                }
                if (xmledit.Name == "btnBgValue"+mode)
                {
                    btnBgValue = xmledit.ReadElementContentAsString();
                }
            }
            xmledit.Close();
        }
        
        public EditWindow(MainWindow main)
        {
            InitializeComponent();
            mainWin = main;
            readXml();
            readURL_Sentences();
            txtUrl.Text = urlLoad;
            txtSentences.Text = soCauLoad;
        }
        private void readURL_Sentences()
        {
            XmlTextReader xml = new XmlTextReader("ThamSo.xml");
            while (xml.Read())
            {
                if (xml.Name == "SoUrl")
                {
                    urlLoad = xml.ReadElementContentAsString();
                }
                if (xml.Name == "SoCau")
                {
                    soCauLoad = xml.ReadElementContentAsString();
                }
            }
            
            xml.Close();
        }

        private void readXml()
        {
            XmlTextReader xmledit = new XmlTextReader("ThamSoEdit.xml");

            while (xmledit.Read())
            {
                if (xmledit.Name == "messagesuss") 
                {
                    messagesucc = xmledit.ReadElementContentAsString();
                }
                if (xmledit.Name == "messageerr")
                {
                    messageerr = xmledit.ReadElementContentAsString();
                }
            }
            xmledit.Close();
        }
        private bool isNumber(string day)
        {
            Regex regex = new Regex("^[1-9]\\d*$");
            Match match = regex.Match(day);
            if (match.Success)
                return true;
            else
                return false;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow.flatedit = 0;
            if(flatedit==1)
            {
                //editMainColor();
            }
        }
        private void editMainColor()
        {
            BrushConverter brushConverter = new BrushConverter();
            mainWin.Background = (System.Windows.Media.Brush)brushConverter.ConvertFrom(backgroundValue);
            mainWin.resultTxtBox.Background = (System.Windows.Media.Brush)brushConverter.ConvertFrom(backgroundValue);
            mainWin.resultTxtBox.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(tbFgValue);
            mainWin.searchTxtBox.Background = (System.Windows.Media.Brush)brushConverter.ConvertFrom(backgroundValue);
            mainWin.searchTxtBox.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(tbFgValue);
            mainWin.listBox.Background = (System.Windows.Media.Brush)brushConverter.ConvertFrom(backgroundValue);
            mainWin.listBox.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(tbFgValue);
            mainWin.searchBtn.Background = (System.Windows.Media.Brush)brushConverter.ConvertFrom(btnBgValue);
            mainWin.searchBtn.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(tbFgValue);
            mainWin.URLLb.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(tbFgValue);
            mainWin.ResultLb.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(tbFgValue);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.Color == true)
            {
                readMode("D");
            }
            else
                readMode("L");
            editColor();
        }
    }
}
