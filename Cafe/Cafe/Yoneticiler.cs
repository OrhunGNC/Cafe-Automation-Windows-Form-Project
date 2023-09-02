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
    public partial class Yoneticiler : Form
    {
        public Yoneticiler()
        {
            InitializeComponent();
        }
        SqlConnection coon = new SqlConnection("Server=DESKTOP-38T2N6J;Database=Cafe;Integrated Security=true");
        private void Yoneticiler_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            YoneticiArayuz go = new YoneticiArayuz();
            go.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "insert into Yoneticiler(yoneticiAdSoyad,yoneticiKAdi,yoneticiSifre,yoneticiYas,yoneticiUnvan,yoneticiMaas)values(@yoneticiAdSoyad,@yoneticiKAdi,@yoneticiSifre,@yoneticiYas,@yoneticiUnvan,@yoneticiMaas)";
            cmd.Parameters.AddWithValue("@yoneticiAdSoyad", textBox1.Text);
            cmd.Parameters.AddWithValue("@yoneticiKAdi", textBox2.Text);
            cmd.Parameters.AddWithValue("@yoneticiSifre", textBox3.Text);
            cmd.Parameters.AddWithValue("@yoneticiYas", textBox4.Text);
            cmd.Parameters.AddWithValue("@yoneticiUnvan", textBox5.Text);
            cmd.Parameters.AddWithValue("@yoneticiMaas", textBox6.Text);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select * from Yoneticiler";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            coon.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "update Yoneticiler set yoneticiAdSoyad=@yoneticiAdSoyad,yonetciKAdi=@yonetciKAdi,yoneticiSifre=@yoneticiSifre,yoneticiYas=@yoneticiYas,yoneticiUnvan=@yoneticiUnvan,yoneticiMaas=@yoneticiMaas where yoneticiNo=@yoneticiNo ";
            cmd.Parameters.AddWithValue("@yoneticiNo", textBox1.Tag);
            cmd.Parameters.AddWithValue("@yoneticiAdSoyad", textBox1.Text);
            cmd.Parameters.AddWithValue("@yonetciKAdi", textBox2.Text);
            cmd.Parameters.AddWithValue("@yoneticiSifre", textBox3.Text);
            cmd.Parameters.AddWithValue("@yoneticiYas", textBox4.Text);
            cmd.Parameters.AddWithValue("@yoneticiUnvan", textBox5.Text);
            cmd.Parameters.AddWithValue("@yoneticiMaas", textBox6.Text);
            cmd.ExecuteNonQuery();
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
            cmd.CommandText = "select * from Yoneticiler";
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
            cmd.CommandText = "select * from Yoneticiler where yoneticiAdSoyad like '%'+@yoneticiAdi+'%'";
            cmd.Parameters.AddWithValue("@yoneticiAdi", textBox1.Text);
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
            cmd.CommandText = "select * from Yoneticiler where yoneticiKAdi like '%'+@yoneticiKAdi+'%'";
            cmd.Parameters.AddWithValue("@yoneticiKAdi", textBox2.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            coon.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow column = dataGridView1.CurrentRow;
            textBox1.Tag = column.Cells["yoneticiNo"].Value.ToString();
            textBox1.Text = column.Cells["yoneticiAdSoyad"].Value.ToString();
            textBox2.Text = column.Cells["yoneticiKAdi"].Value.ToString();
            textBox3.Text = column.Cells["yoneticiSifre"].Value.ToString();
            textBox4.Text = column.Cells["yoneticiYas"].Value.ToString();
            textBox5.Text = column.Cells["yoneticiUnvan"].Value.ToString();
            textBox6.Text = column.Cells["yoneticiMaas"].Value.ToString();
        }
    }
}
