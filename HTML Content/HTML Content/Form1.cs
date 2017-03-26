using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace HTML_Content
{
    public partial class Form1 : Form
    {
        public sealed class HtmlDocument{};

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "Copy vào TextBox:\n\nwww.dienmayxanh.com/dien-thoai/iphone-7-plus-256gb\n" + "\nvnexpress.net/tin-tuc/phap-luat/an-mang-tu-chiec-noi-bi-hong-3560356.html\n";
        }


        private string getContent()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("http://" + textBox1.Text);
            HtmlAgilityPack.HtmlNodeCollection tags = doc.DocumentNode.SelectNodes("//meta");
            string s = "";
            if (tags != null)
            {

                foreach (HtmlNode tag in tags)
                {

                    if (tag.Attributes["content"] != null)
                    {
                        s += tag.Attributes["content"].Value + "\n";
                    }
                }
            }
            return s;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Text = getContent();
        }
    }
}
