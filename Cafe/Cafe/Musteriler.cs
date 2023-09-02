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
    public partial class Musteriler : Form
    {
        public Musteriler()
        {
            InitializeComponent();
        }
        SqlConnection coon = new SqlConnection("Server=DESKTOP-38T2N6J;Database=Cafe;Integrated Security=true");
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            YoneticiArayuz go = new YoneticiArayuz();
            go.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow column = dataGridView1.CurrentRow;
            textBox1.Tag = column.Cells["musteriNo"].Value.ToString();
            textBox1.Text = column.Cells["musteriAdSoyad"].Value.ToString();
            textBox2.Text = column.Cells["musteriKAdi"].Value.ToString();
            textBox3.Text = column.Cells["musteriSifre"].Value.ToString();
            textBox4.Text = column.Cells["musteriBakiye"].Value.ToString();
            textBox5.Text = column.Cells["musteriTelefonNo"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "update Musteriler set musteriAdSoyad=@musteriAdSoyad,musteriKAdi=@musteriKAdi,musteriSifre=@musteriSifre,musteriBakiye=@musteriBakiye,musteriTelefonNo=@musteriTelefonNo where musteriNo=@musteriNo";
            cmd.Parameters.AddWithValue("@musteriNo", textBox1.Tag);
            cmd.Parameters.AddWithValue("@musteriAdSoyad", textBox1.Text);
            cmd.Parameters.AddWithValue("@musteriKAdi", textBox2.Text);
            cmd.Parameters.AddWithValue("@musteriSifre", textBox3.Text);
            cmd.Parameters.AddWithValue("@musteriBakiye", textBox4.Text);
            cmd.Parameters.AddWithValue("@musteriTelefonNo", textBox5.Text);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select * from Musteriler";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            coon.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select * from Musteriler";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            coon.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select * from Musteriler where musteriAdSoyad like '%'+@musteriAdSoyad+'%'";
            cmd.Parameters.AddWithValue("@musteriAdSoyad", textBox1.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            coon.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select * from Musteriler where musteriKAdi like '%'+@musteriKAdi+'%'";
            cmd.Parameters.AddWithValue("@musteriKAdi", textBox2.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            coon.Close();
        }

        private void Musteriler_Load(object sender, EventArgs e)
        {

        }
    }
}
