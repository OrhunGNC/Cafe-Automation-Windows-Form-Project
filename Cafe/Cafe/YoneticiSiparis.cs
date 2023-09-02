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
    public partial class YoneticiSiparis : Form
    {
        public YoneticiSiparis()
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

        private void YoneticiSiparis_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow column = dataGridView1.CurrentRow;
            textBox1.Text = column.Cells["siparisNo"].Value.ToString();
            textBox2.Text = column.Cells["urunAdi"].Value.ToString();
            textBox3.Text = column.Cells["siparisUcret"].Value.ToString();
            textBox4.Text = column.Cells["siparisAdet"].Value.ToString();
            textBox5.Text = column.Cells["musteriNo"].Value.ToString();
            textBox6.Text = column.Cells["yoneticiNo"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "delete from Siparisler where siparisNo=@siparisNo";
            cmd.Parameters.AddWithValue("@siparisNo", textBox1.Text);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter();
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
            cmd.CommandText = "select * from Siparisler";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            coon.Close();
        }
    }
}
