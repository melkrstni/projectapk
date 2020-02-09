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
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;

namespace apksamsat
{
    public partial class Home : Form
    {
        SqlConnection koneksi = new SqlConnection(@"Data Source=DESKTOP-6LH0IM2\EYMELKRSTNI;Initial Catalog=aplikasisamsat;Integrated Security=True");
        public Home()
        {
            InitializeComponent();
        }
        string Bahan_Bakar;
        string Warna_TNKB;
        SqlCommand cmd = new SqlCommand();

        private void Button2_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [data] (Nomor_Plat,Nama_Pemilik,Alamat,Merk,Jenis,No_Rangka,No_Mesin,Bahan_Bakar,Warna_KB,Warna_TNKB.Milik,Wilayah,Foto) " +
                "values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + Bahan_Bakar + "','" + textBox8.Text + "','" + Warna_TNKB + "','" + textBox9.Text + "','" + textBox10.Text + "',@images)";
            koneksi.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;

            MessageBox.Show("Data insert Successfully");
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Bahan_Bakar = "Bensin";
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Bahan_Bakar = "Solar";
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Warna_TNKB = "Hitam";
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Warna_TNKB = "Merah";
        }

        private void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            Warna_TNKB = "Kuning";
        }

        private void displaydata()
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [data]";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView1.DataSource = dta;
            koneksi.Close();
        }
        private void display()
        {
            SqlCommand cmd = new SqlCommand("select * from[data]", koneksi);
            DataTable dt = new DataTable();

            koneksi.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            koneksi.Close();

            dataGridView1.DataSource = dt;
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            display();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from [data]";
        }
        private void Label11_Click(object sender, EventArgs e)
        {

        }


        private void Label1_Click(object sender, EventArgs e) 
        {

        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

         
    }
}
