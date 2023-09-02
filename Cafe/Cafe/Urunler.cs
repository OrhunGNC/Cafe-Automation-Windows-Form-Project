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
    public partial class Urunler : Form
    {
        public Urunler()
        {
            InitializeComponent();
        }
        SqlConnection coon = new SqlConnection("Server=DESKTOP-38T2N6J;Database=Cafe;Integrated Security=true");
        private void Urunler_Load(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            textBox2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select * from Urunler";
            SqlDataAdapter adapter =new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource= dt;
            coon.Close();
            textBox1.Visible = true;
            textBox2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select*from Urunler where urunIsim like '%'+@urunAdi+'%'";
            cmd.Parameters.AddWithValue("@urunAdi", textBox1.Text);
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
            cmd.CommandText = "select * from Urunler where urunFiyat=@urunFiyat";
            cmd.Parameters.AddWithValue("@urunFiyat", textBox2.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            coon.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MusteriArayuz go = new MusteriArayuz();
            go.Show();
            this.Hide();
        }
    }
}
