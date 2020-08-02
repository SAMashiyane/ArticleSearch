using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace ArticleSearch
{
    public partial class Form2 : Form
    {
        public Form2(String Link, string SaveAS)
        {
            InitializeComponent();
            Uri link = new Uri(Link);
            WebClient w = new WebClient();
            w.DownloadFileCompleted += new AsyncCompletedEventHandler(Takmil);
            w.DownloadProgressChanged += new DownloadProgressChangedEventHandler(progress);
            w.DownloadFileAsync(link, SaveAS);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(Form2_FormClosing);
        }
         private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        
        private void progress(object sender, DownloadProgressChangedEventArgs e)
        {

            

            lblsize.Text = e.TotalBytesToReceive.ToString();
            float s;
            s = float.Parse(lblsize.Text);
            s = s / 1024;
            if ( s<2)
            {
                MessageBox.Show("ای پی مسدود شد لطفا دوباره ویا بعدا تلاش کنید!!");
                lblsize.Visible = false;
            }
            else 
            {
                lblsize.Visible = true;
                progressBar1.Value = e.ProgressPercentage;
                lblsize.Text = s.ToString() + " Kb";
                lbldownloaded.Text = e.BytesReceived.ToString();
                float d;
                d = float.Parse(lbldownloaded.Text);
                d = d / 1024;
                lbldownloaded.Text = d.ToString() + "Kb";

                lblpercent.Text = ((d * 100) / s).ToString() + " %";
                if (((d* 100)/s)==100)
                {
                    MessageBox.Show("دانلود انجام شد");
                }
               
                    

            }
           
            
        }
        private void Takmil(object sender, AsyncCompletedEventArgs e)
        {
            //MessageBox.Show("فایل دانلود شد");
        }
       

    }

}
