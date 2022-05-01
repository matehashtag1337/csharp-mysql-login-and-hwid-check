using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace naakkormegint
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            string cs = @"server=localhost;userid=root;password=;database=login"; // Change this, to your settings
            var con = new MySqlConnection(cs);
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from users where username='" + textBox2.Text + "' and password='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable datatable = new DataTable();
            MySqlDataAdapter datadapter = new MySqlDataAdapter(cmd);
            datadapter.Fill(datatable);
            i = Convert.ToInt32(datatable.Rows.Count.ToString());
            if(i == 0)
            {
                MessageBox.Show("Invalid login details.");
            } else
            {
                MessageBox.Show("Welcome, " + textBox2.Text + "!");
                this.Hide();
                Form mainform = new Main();
                mainform.Show();
            }
            con.Close();
        }
    }
}
