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

namespace CrawlerAndSummary
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        string urlLoad;
        string soCauLoad;
        string messagesucc;
        string messageerr;
        byte BgA, BgR, BgG, BgB, txtA, txtR, txtG, txtB, btnA, btnR, btnG, btnB;
        byte BgtA, BgtR, BgtG, BgtB, txttA, txttR, txttG, txttB, btntA, btntR, btntG, btntB;
        int flatedit = 0;
        public EditWindow()
        {
            InitializeComponent();
            readXml();
            XmlTextReader xml = new XmlTextReader("ThamSo.xml");
            while (xml.Read())
            {
                if (xml.Name == "SoUrl")
                {
                    urlLoad  = xml.ReadElementContentAsString();
                }
                if (xml.Name == "SoCau")
                {
                    soCauLoad = xml.ReadElementContentAsString();
                }
            }
            txtUrl.Text = urlLoad;
            txtSentences.Text = soCauLoad;
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
        }
        private bool isNumber(string day)
        {
            //hardcode
            Regex regex = new Regex("^[1-9]\\d*$");
            Match match = regex.Match(day);
            if (match.Success)
                return true;
            else
                return false;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            string soUrl = txtUrl.Text.Trim();
            string soCau = txtSentences.Text.Trim();

            if (soUrl == "" || soCau == "" || soUrl=="0" || soCau == "0" || !isNumber(soUrl) || !isNumber(soCau))
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

                XmlTextWriter xml_color = new XmlTextWriter("Color.xml", Encoding.UTF8);

                xml_color.WriteStartDocument();
                xml_color.WriteStartElement("ThamSo");
                xml_color.WriteElementString("BgA", BgA.ToString());
                xml_color.WriteElementString("BgR", BgR.ToString());
                xml_color.WriteElementString("BgG", BgG.ToString());
                xml_color.WriteElementString("BgB", BgB.ToString());
                xml_color.WriteElementString("txtA", txtA.ToString());
                xml_color.WriteElementString("txtR", txtR.ToString());
                xml_color.WriteElementString("txtG", txtG.ToString());
                xml_color.WriteElementString("txtB", txtB.ToString());
                xml_color.WriteElementString("btnA", btnA.ToString());
                xml_color.WriteElementString("btnR", btnR.ToString());
                xml_color.WriteElementString("btnG", btnG.ToString());
                xml_color.WriteElementString("btnB", btnB.ToString());
                xml_color.WriteEndElement();
                xml_color.WriteEndDocument();
                xml_color.Flush();
                xml_color.Close();

                MessageBox.Show(messagesucc);
                flatedit = 1;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow.flatedit = 0;
            if(flatedit==0)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(BgtA, BgtR, BgtG, BgtB));
                ((MainWindow)System.Windows.Application.Current.MainWindow).resultTxtBox.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(txttA, txttR, txttG, txttB));
                ((MainWindow)System.Windows.Application.Current.MainWindow).searchTxtBox.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(txttA, txttR, txttG, txttB));
                ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(txttA, txttR, txttG, txttB));
                ((MainWindow)System.Windows.Application.Current.MainWindow).searchBtn.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(btntA, btntR, btntG, btntB));
            }
            
        }

       

        private void rdBackground_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog colorPicker = new System.Windows.Forms.ColorDialog();

            if (colorPicker.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(colorPicker.Color.A, colorPicker.Color.R, colorPicker.Color.G, colorPicker.Color.B));
                this.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(colorPicker.Color.A, colorPicker.Color.R, colorPicker.Color.G, colorPicker.Color.B));
                BgA = colorPicker.Color.A;
                BgR = colorPicker.Color.R;
                BgG = colorPicker.Color.G;
                BgB = colorPicker.Color.B;
            }
           
        }

        private void rdTexboxt_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog colorPicker = new System.Windows.Forms.ColorDialog();

            if (colorPicker.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).resultTxtBox.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(colorPicker.Color.A, colorPicker.Color.R, colorPicker.Color.G, colorPicker.Color.B));
                ((MainWindow)System.Windows.Application.Current.MainWindow).searchTxtBox.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(colorPicker.Color.A, colorPicker.Color.R, colorPicker.Color.G, colorPicker.Color.B));
                ((MainWindow)System.Windows.Application.Current.MainWindow).listBox.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(colorPicker.Color.A, colorPicker.Color.R, colorPicker.Color.G, colorPicker.Color.B));
          
                this.txtUrl.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(colorPicker.Color.A, colorPicker.Color.R, colorPicker.Color.G, colorPicker.Color.B));
                this.txtSentences.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(colorPicker.Color.A, colorPicker.Color.R, colorPicker.Color.G, colorPicker.Color.B));

                txtA = colorPicker.Color.A;
                txtR = colorPicker.Color.R;
                txtG = colorPicker.Color.G;
                txtB = colorPicker.Color.B;
            }
           

        }

        private void rdButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog colorPicker = new System.Windows.Forms.ColorDialog();

            if (colorPicker.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).searchBtn.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(colorPicker.Color.A, colorPicker.Color.R, colorPicker.Color.G, colorPicker.Color.B));
                
                this.button.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(colorPicker.Color.A, colorPicker.Color.R, colorPicker.Color.G, colorPicker.Color.B));
                
                btnA = colorPicker.Color.A;
                btnR = colorPicker.Color.R;
                btnG = colorPicker.Color.G;
                btnB = colorPicker.Color.B;

            }
           
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ColorXml();
        }

        private void ColorXml()
        {
            XmlTextReader xml = new XmlTextReader("Color.xml");
     
            while (xml.Read())
            {
                if (xml.Name == "BgA")
                {
                    BgA = Convert.ToByte(xml.ReadElementContentAsInt());
                    BgtA = BgA;
                }
                if (xml.Name == "BgR")
                {
                    BgR = Convert.ToByte(xml.ReadElementContentAsInt());
                    BgtR = BgR;
                }
                if (xml.Name == "BgG")
                {
                    BgG = Convert.ToByte(xml.ReadElementContentAsInt());
                    BgtG = BgG;
                }
                if (xml.Name == "BgB")
                {
                    BgB = Convert.ToByte(xml.ReadElementContentAsInt());
                    BgtB = BgB; 
                }
                if (xml.Name == "txtA")
                {
                    txtA = Convert.ToByte(xml.ReadElementContentAsInt());
                    txttA = txtA;
                }
                if (xml.Name == "txtR")
                {
                    txtR = Convert.ToByte(xml.ReadElementContentAsInt());
                    txttR = txtR;
                }
                if (xml.Name == "txtG")
                {
                    txtG = Convert.ToByte(xml.ReadElementContentAsInt());
                    txttG = txtG;
                }
                if (xml.Name == "txtB")
                {
                    txtB = Convert.ToByte(xml.ReadElementContentAsInt());
                    txttB = txtB;
                }
                if (xml.Name == "btnA")
                {
                    btnA = Convert.ToByte(xml.ReadElementContentAsInt());
                    btntA = btnA;
                }
                if (xml.Name == "btnR")
                {
                    btnR = Convert.ToByte(xml.ReadElementContentAsInt());
                    btntR = btnR;
                }
                if (xml.Name == "btnG")
                {
                    btnG = Convert.ToByte(xml.ReadElementContentAsInt());
                    btntG = btnG;
                }
                if (xml.Name == "btnB")
                {
                    btnB = Convert.ToByte(xml.ReadElementContentAsInt());
                    btntB = btnB;
                }
            }

            this.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(BgA, BgR, BgG, BgB));
            this.txtUrl.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(txtA, txtR, txtG, txtB));
            this.txtSentences.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(txtA, txtR, txtG, txtB));
            this.button.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(btnA, btnR, btnG, btnB));

        }

    }
}
