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

namespace Cafe
{
    public partial class MusteriGirisEkrani : Form
    {
        SqlConnection coon = new SqlConnection("Server=DESKTOP-38T2N6J;Database=Cafe;Integrated Security=true");
        public MusteriGirisEkrani()
        {
            InitializeComponent();
        }
        public static int deger;
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection= coon;
            cmd.CommandText = "select musteriNo from Musteriler where musteriKAdi=@musteriKAdi and musteriSifre = @musteriSifre";
            cmd.Parameters.AddWithValue("@musteriKAdi", textBox1.Text);
            cmd.Parameters.AddWithValue("@musteriSifre", textBox2.Text);
            coon.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                deger = Convert.ToInt32(reader["musteriNo"]);
                MessageBox.Show("Başarıyla Giriş Yaptınız.");
                MusteriArayuz go = new MusteriArayuz();
                go.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı!");
                textBox1.Clear();
                textBox2.Clear();
            }
            coon.Close();
          
            
        }

        private void MusteriGirisEkrani_Load(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            MusteriKayit go = new MusteriKayit();
            go.Show();
            this.Hide();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 go = new Form1();
            go.Show();
            this.Hide();
        }
    }
}
