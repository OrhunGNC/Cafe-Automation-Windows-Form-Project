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
    public partial class Siparis_Ver : Form
    {
        public Siparis_Ver()
        {
            InitializeComponent();
        }
        SqlConnection coon = new SqlConnection("Server=DESKTOP-38T2N6J;Database=Cafe;Integrated Security=true");
        public int degerr = 0;
        private void Siparis_Ver_Load(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            degerr = MusteriGirisEkrani.deger;
            cmd.Connection = coon;
            cmd.CommandText = "select * from Urunler";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            coon.Close();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox4.Text = degerr.ToString();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            coon.Open();
            DataGridViewRow column = dataGridView1.CurrentRow;
            textBox1.Text = column.Cells["urunIsim"].Value.ToString();
            textBox2.Text = column.Cells["urunFiyat"].Value.ToString();
            textBox4.Text = degerr.ToString();
            coon.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "insert into Siparisler(urunAdi,siparisUcret,siparisAdet,musteriNo,yoneticiNo)values(@urunAdi,@siparisUcret,@siparisAdet,@musteriNo,@yoneticiNo)";
            cmd.Parameters.AddWithValue("@urunAdi", textBox1.Text);
            cmd.Parameters.AddWithValue("@siparisUcret", textBox2.Text);
            cmd.Parameters.AddWithValue("@siparisAdet", textBox3.Text);
            cmd.Parameters.AddWithValue("@musteriNo", textBox4.Text);
            cmd.Parameters.AddWithValue("@yoneticiNo", textBox5.Text);
            cmd.ExecuteNonQuery();
            coon.Close();
            Orders go = new Orders();
            go.Show();
            this.Hide();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MusteriArayuz go = new MusteriArayuz();
            go.Show();
            this.Hide();
        }
    }
}
