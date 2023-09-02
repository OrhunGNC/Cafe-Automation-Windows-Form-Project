using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Permissions;

namespace Cafe
{
    public partial class YöneticiGirisEkrani : Form
    {
        public YöneticiGirisEkrani()
        {
            InitializeComponent();
        }

        private void YöneticiGirisEkrani_Load(object sender, EventArgs e)
        {

        }
        SqlConnection coon = new SqlConnection("Server=DESKTOP-38T2N6J;Database=Cafe;Integrated Security=true");

        private void label3_Click(object sender, EventArgs e)
        {
            YoneticiKayit go = new YoneticiKayit();
            go.Show();
            this.Hide();
        }
        public static int deger;
        private void button1_Click(object sender, EventArgs e)
        {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = coon;
                cmd.CommandText = "select yoneticiNo from Yoneticiler where yoneticiKAdi = @yoneticiKAdi and yoneticiSifre=@yoneticiSifre";
                cmd.Parameters.AddWithValue("@yoneticiKAdi", textBox1.Text);
                cmd.Parameters.AddWithValue("@yoneticiSifre", textBox2.Text);
            coon.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                deger = Convert.ToInt32(reader["yoneticiNo"]);
                MessageBox.Show("Başarıyla Giriş Yaptınız!");
                YoneticiArayuz go = new YoneticiArayuz();
                go.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yanlış Kullanıcı Adı veya Şifre");
                textBox1.Clear();
                textBox2.Clear();
            }
            coon.Close();
                

            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 go = new Form1();
            go.Show();
            this.Hide();
        }
    }
}
