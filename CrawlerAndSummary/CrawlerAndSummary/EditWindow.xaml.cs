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

namespace CrawlerAndSummary
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public EditWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string soUrl = txtUrl.Text.Trim();
            string soCau = txtSentences.Text.Trim();

            if (soUrl != "" || soCau != "" || Convert.ToInt32(soUrl)==0 || Convert.ToInt32(soCau) == 0)
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


                MessageBox.Show("Tùy chỉnh thành công");
            }
            else
            {
                MessageBox.Show("không được trống số câu và số url hoặc số câu và số url là 0");
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow.flatedit = 0;
        }
    }
}
