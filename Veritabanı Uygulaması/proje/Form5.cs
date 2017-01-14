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
    public partial class Bolum : Form
    {
        public Bolum()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=vt.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();

        private void button1_Click(object sender, EventArgs e)
        {
            Giris git = new Giris();
            git.Show();
            this.Visible = false;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Listelendi!");
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            baglanti.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter("select ogrenci_no from Okur where bolum_kodu='" + textBox1.Text + "'", baglanti);
            ad.Fill(ds, "Okur");

            foreach (DataRow Satir in ds.Tables["Okur"].Rows)
            {
                string deger = Satir[0].ToString();
                bool durum = comboBox1.Items.Contains(deger);
                if (!durum)
                {

                    comboBox1.Items.Add(deger).ToString();

                }

            }
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Listelendi!");
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            baglanti.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter("select durum from Okur where bolum_kodu='" + textBox1.Text + "'", baglanti);
            ad.Fill(ds, "Okur");

            foreach (DataRow Satir in ds.Tables["Okur"].Rows)
            {
                string deger = Satir[0].ToString();
                bool durum = comboBox2.Items.Contains(deger);
                if (!durum)
                {

                    comboBox2.Items.Add(deger).ToString();

                }

            }
            baglanti.Close();

        }

        
    }
}
