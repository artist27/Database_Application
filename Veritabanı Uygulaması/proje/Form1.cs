using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ProLab_Proje3
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=vt.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();

        private void button3_Click(object sender, EventArgs e)
        {
            Ders git = new Ders();
            git.Show();

            this.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ögrenci git = new Ögrenci();
            git.Show();
            this.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Not git = new Not();
            git.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bolum git = new Bolum();
            git.Show();
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OgretimUyesi git = new OgretimUyesi();
            git.Show();
            this.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
