using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArticleSearch
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.Untitled;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = "https://www.doi.org/";
            linkLabel1.Links.Add(link);

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }
    }
}
