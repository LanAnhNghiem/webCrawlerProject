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
    /// Interaction logic for HelpWindow.xaml
    /// </summary>
    public partial class HelpWindow : Window
    {
        string lbFgValue;
        string backgroundValue;
        public HelpWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            if (Properties.Settings.Default.Color == true)
                readMode("D");
            else
                readMode("L");
            editMainColor();
        }

        private void HelpWindow1_Closed(object sender, EventArgs e)
        {
            MainWindow.flat = 0;
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
                if (xmledit.Name == "lbFgValue" + mode)
                {
                    lbFgValue = xmledit.ReadElementContentAsString();
                }
            }
            xmledit.Close();
        }
        private void editMainColor()
        {
            BrushConverter brushConverter = new BrushConverter();
            this.Background = (System.Windows.Media.Brush)brushConverter.ConvertFrom(backgroundValue);
            this.background.Background = (System.Windows.Media.Brush)brushConverter.ConvertFrom(backgroundValue);
            this.label.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(lbFgValue);
            this.label_Copy.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(lbFgValue);
            this.label_Copy1.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(lbFgValue);
            this.label_Copy2.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(lbFgValue);

            this.background2.Background = (System.Windows.Media.Brush)brushConverter.ConvertFrom(backgroundValue);
            this.label_Copy3.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(lbFgValue);
            this.label_Copy4.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(lbFgValue);
            this.label_Copy5.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(lbFgValue);
            this.label_Copy6.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(lbFgValue);
            this.label_Copy7.Foreground = (System.Windows.Media.Brush)brushConverter.ConvertFrom(lbFgValue);
        }
    }
}
