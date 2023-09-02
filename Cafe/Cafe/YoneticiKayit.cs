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

namespace Cafe
{
    public partial class YoneticiKayit : Form
    {
        public YoneticiKayit()
        {
            InitializeComponent();
        }
        SqlConnection coon = new SqlConnection("Server=DESKTOP-38T2N6J;Database=Cafe;Integrated Security=true");
        //public void Listele()
        //{
        //    coon.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = coon;
        //    cmd.CommandText = "select * from Yoneticiler";
        //    cmd.ExecuteNonQuery();
        //    coon.Close();
        //},
        public void Temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
                coon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = coon;
                cmd.CommandText = "insert into Yoneticiler(yoneticiAdSoyad,yoneticiKAdi,yoneticiSifre,yoneticiYas,yoneticiUnvan,yoneticiMaas)values(@yoneticiAdSoyad,@yoneticiKAdi,@yoneticiSifre,@yoneticiYas,@yoneticiUnvan,@yoneticiMaas)";
                cmd.Parameters.AddWithValue("@yoneticiAdSoyad", textBox3.Text);
                cmd.Parameters.AddWithValue("@yoneticiKAdi", textBox1.Text);
                cmd.Parameters.AddWithValue("@yoneticiSifre", textBox2.Text);
                cmd.Parameters.AddWithValue("@yoneticiYas", textBox4.Text);
                cmd.Parameters.AddWithValue("@yoneticiUnvan", textBox5.Text);
                cmd.Parameters.AddWithValue("@yoneticiMaas", textBox6.Text);
                cmd.ExecuteNonQuery();
                coon.Close();
                MessageBox.Show("Başarıyla Kayıt Oldunuz.");
                YöneticiGirisEkrani go = new YöneticiGirisEkrani();
                go.Show();
                this.Hide();
            
        }

        private void YoneticiKayit_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 go = new Form1();
            go.Show();
            this.Hide();
        }
    }
}
