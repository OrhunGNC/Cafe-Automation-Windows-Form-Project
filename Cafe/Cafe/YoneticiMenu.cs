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
    public partial class YoneticiMenu : Form
    {
        public YoneticiMenu()
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

        private void YoneticiMenu_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "insert into Urunler(urunIsim,urunKategori,urunFiyat)values(@urunIsim,@urunKategori,@urunFiyat)";
            cmd.Parameters.AddWithValue("@urunIsim", textBox3.Text);
            cmd.Parameters.AddWithValue("@urunKategori", textBox4.Text);
            cmd.Parameters.AddWithValue("@urunFiyat", textBox5.Text);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select * from Urunler";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            coon.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "update Urunler set urunIsim=@urunIsim,urunKategori=@urunKategori,urunFiyat=@urunFiyat where urunNo=@urunNo";
            cmd.Parameters.AddWithValue("@urunNo", textBox1.Tag);
            cmd.Parameters.AddWithValue("@urunIsim", textBox3.Text);
            cmd.Parameters.AddWithValue("@urunKategori", textBox4.Text);
            cmd.Parameters.AddWithValue("@urunFiyat", textBox5.Text);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select * from Urunler";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            coon.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow column = dataGridView1.CurrentRow;
            textBox3.Tag = column.Cells["urunNo"].Value.ToString();
            textBox3.Text = column.Cells["urunIsim"].Value.ToString();
            textBox4.Text = column.Cells["urunKategori"].Value.ToString();
            textBox5.Text = column.Cells["urunFiyat"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select * from Urunler";
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
            cmd.CommandText = "select * from Urunler where urunIsim like '%'+@urunIsim+'%'";
            cmd.Parameters.AddWithValue("@urunIsim", textBox1.Text);
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
            cmd.CommandText = "select * from Urunler where urunFiyat =@urunFiyat";
            cmd.Parameters.AddWithValue("@urunFiyat", textBox2.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            coon.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
