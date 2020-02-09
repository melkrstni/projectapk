using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace apksamsat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection koneksi = new SqlConnection(@"Data Source=DESKTOP-6LH0IM2\EYMELKRSTNI;Initial Catalog=aplikasisamsat;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("select count (*) from login where Username = '"+textBox1.Text+"' and Password = '"+textBox2.Text+"' ",koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Home panggil = new Home();
                panggil.Show();
            }
            else
            {
                MessageBox.Show("Mohon isi Username dan Password kamu dengan benar!", "PERHATIAN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
      

        }
    }
}
