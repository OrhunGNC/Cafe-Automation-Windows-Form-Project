using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void yöneticiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YöneticiGirisEkrani go = new YöneticiGirisEkrani();
            go.Show();
            this.Hide();
        }

        private void müşteriGirişiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MusteriGirisEkrani go = new MusteriGirisEkrani();
            go.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
