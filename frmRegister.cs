using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ArticleSearch
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)

        {
            this.FormClosing += new FormClosingEventHandler(frmRegister_FormClosing);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtRegister.Text == "C://SAM")
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\SA", "s", txtRegister.Text);
                this.Hide();
                new Form1().ShowDialog();
            }
            else
            {
                MessageBox.Show(" رمز وارد شده اشتباه است لطفا جهت دریافت رمز به ایمیل زیر Salio.blue@gmail.com درخواست خود را ارسال کنید");
                txtRegister.Clear();
                txtRegister.BackColor = Color.Yellow;
                txtRegister.Focus();
            }

        }
       

        
    }
}
