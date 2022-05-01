using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace naakkormegint
{
    public partial class HWIDCheck : Form
    {
        public HWIDCheck()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string HWID;
            HWID = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
            WebClient wb = new WebClient();
            string HWIDLIST = wb.DownloadString("https://pastebin.com/raw/KKx3Ht6z");
            if (HWIDLIST.Contains(HWID))
            {
                MessageBox.Show("Successfully authenticated.");
                MessageBox.Show("Loading login page...");
                this.Hide();
                Form form = new Login();
                form.Show();
            }
            else
            {
                MessageBox.Show("I cannot find your HWID on the list.\nYour HWID: " + HWID + "\nYour HWID copied to the clipboard.");
                Clipboard.SetText(HWID);
            }
        }
    }
}
