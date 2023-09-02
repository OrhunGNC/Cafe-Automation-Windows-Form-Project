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
    public partial class MusteriKayit : Form
    {
        SqlConnection coon = new SqlConnection("Server=DESKTOP-38T2N6J;Database=Cafe;Integrated Security=true");
        public MusteriKayit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "insert into Musteriler(musteriAdSoyad,musteriKAdi,musteriSifre,musteriBakiye,musteriTelefonNo)values(@musteriAdSoyad,@musteriKAdi,@musteriSifre,@musteriBakiye,@musteriTelefonNo)";
            cmd.Parameters.AddWithValue("@musteriAdSoyad", textBox3.Text);
            cmd.Parameters.AddWithValue("@musteriKAdi", textBox1.Text);
            cmd.Parameters.AddWithValue("@musteriSifre", textBox2.Text);
            cmd.Parameters.AddWithValue("@musteriBakiye", textBox4.Text);
            cmd.Parameters.AddWithValue("@musteriTelefonNo", textBox5.Text);
            cmd.ExecuteNonQuery();
            coon.Close();
            MessageBox.Show("Başarıyla Kayıt Oldunuz!");
            MusteriGirisEkrani go = new MusteriGirisEkrani();
            go.Show();
            this.Hide();
        }

        private void MusteriKayit_Load(object sender, EventArgs e)
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
