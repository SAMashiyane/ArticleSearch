using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Web;
using Microsoft.Win32;
using System.Net.NetworkInformation;



namespace ArticleSearch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            bool connection = NetworkInterface.GetIsNetworkAvailable();
            if (connection == true)
            {
                MessageBox.Show("available");

            }
            else
            {
                MessageBox.Show("not available");
            }
        }


        private void Form1_Load(object sender, EventArgs e)

        {

            



        RegistryKey reg;
            reg = Registry.CurrentUser.OpenSubKey("Software", true);
            reg.CreateSubKey("SA");

            String sn = Registry.GetValue(@"HKEY_CURRENT_USER\Software\SA", "s", "").ToString();

            if (sn != "C://SAM")
            {
                int n = Convert.ToInt32(Registry.GetValue("HKEY_CURRENT_USER\\Software\\SA", "c", "-1").ToString());

                if (n == -1)
                {
                    Registry.SetValue(@"HKEY_CURRENT_USER\Software\SA", "c", "3");
                    lblCount.Text = "3";
                }

                else if (n > 0)
                {
                    Registry.SetValue(@"HKEY_CURRENT_USER\Software\SA", "c", (--n).ToString());
                    lblCount.Text = n.ToString();
                }
                else
                {
                    new frmRegister().ShowDialog();

                }
            }
            else
            {
                lblCount.BackColor = Color.Green;
                lblCount.Text = "فعال شد";
                label4.Visible = false;

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (textBox3.Text != "")
                {
                    HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
                    HtmlAgilityPack.HtmlDocument doc = web.Load("https://sci-hub.se/" + textBox2.Text);                  
                    HtmlNode node = doc.DocumentNode.SelectSingleNode("//*[@id='buttons']/ul/li[2]");


                    if (node == null)

                    {
                         
                            MessageBox.Show(" مقاله درست نمی باشد لطفا مجددا بررسی نماییدویااتصال به اینترنت را چک کنید   DOI ");
                     
                    }
                    else
                    {
                        
                        //string value = (node == null) ? "Error, id not found" : node.InnerHtml;

                        String msg = node.InnerHtml.Substring(node.InnerHtml.IndexOf("/"));
                        String msg2 = msg.Remove(msg.LastIndexOf("?"));
                        textBox1.Text = "http:" + msg2;


                        Form2 startdownload = new Form2(textBox1.Text, textBox3.Text);
                        startdownload.Show();
                       
                    }
                   
                }
                else
                {
                    MessageBox.Show("لطفا محل ذخیره فایل  را مشخص کنید");
                }
            }
            else
            {
                MessageBox.Show(": مقاله خود را وارد کنید DOI ");
            }



        }

        private void btnSaveAS_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveAS = new SaveFileDialog();
            saveAS.Title = "محل ذخیره مقاله را انتخاب کنید:";
            saveAS.FileName = Path.GetFileName(textBox2.Text);
            saveAS.DefaultExt = ".pdf";
            saveAS.ShowDialog();
            textBox3.Text = saveAS.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();

            form3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        
    }
}
