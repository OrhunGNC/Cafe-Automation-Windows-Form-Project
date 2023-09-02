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

namespace Cafe
{
    public partial class Orders : Form
    {
        public Orders()
        {
            InitializeComponent();
        }
        SqlConnection coon = new SqlConnection("Server=DESKTOP-38T2N6J;Database=Cafe;Integrated Security=true");
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public int degerr = 0;
        private void Orders_Load(object sender, EventArgs e)
        {
            coon.Open();
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select * from Siparisler where musteriNo=@musteriNo";
            degerr=MusteriGirisEkrani.deger  ;
            cmd.Parameters.AddWithValue("@musteriNo", degerr);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox5.Text = MusteriGirisEkrani.deger.ToString();
            coon.Close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select * from Siparisler where urunAdi=@urunAdi";
            cmd.Parameters.AddWithValue("@urunAdi", textBox2.Text);
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
            degerr = MusteriGirisEkrani.deger;
            cmd.Connection = coon;
            cmd.CommandText = "update Siparisler set siparisNo=@siparisNo,urunAdi=@urunAdi,siparisUcret=@siparisUcret,siparisAdet=@siparisAdet,musteriNo=@musteriNo,yoneticiNo=@yoneticiNo ";
            cmd.Parameters.AddWithValue("@siparisNo", textBox1.Text);
            cmd.Parameters.AddWithValue("@urunAdi", textBox2.Text);
            cmd.Parameters.AddWithValue("@siparisUcret",textBox3.Text);
            cmd.Parameters.AddWithValue("@siparisAdet", textBox4.Text);
            cmd.Parameters.AddWithValue("@musteriNo", degerr);
            cmd.Parameters.AddWithValue("@yoneticiNo", textBox6.Text);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            coon.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Siparis_Ver go = new Siparis_Ver();
            go.Show();
            this.Hide();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MusteriArayuz go = new MusteriArayuz();
            go.Show();
            this.Hide();
        }
    }
}
