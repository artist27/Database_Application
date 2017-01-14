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
    public partial class Not : Form
    {
        public Not()
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

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Değer giriniz!!!");
            }
            else
            {

                ds.Clear();
                baglanti.Open();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From Ogrenciler where ogrenci_no='" + textBox1.Text + "'", baglanti);
                adtr.Fill(ds, "Ogrenciler");

                dataGridView1.DataSource = ds.Tables["Ogrenciler"];
                adtr.Dispose();
                baglanti.Close();
            }
            comboBox1.Items.Clear();
            baglanti.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter("select ders_kodu from Alir where ogrenci_no='" + textBox1.Text + "'", baglanti);
            ad.Fill(ds, "Alir");

            foreach (DataRow Satir in ds.Tables["Alir"].Rows)
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
            ds.Clear();
            baglanti.Open();
            komut.Connection = baglanti;
            int vize = Convert.ToInt32(textBox3.Text);
            int final = Convert.ToInt32(textBox2.Text);
            int ort = (vize * 2 / 5) + (final * 3 / 5);
            komut.CommandText = "update Alir set Vize='" + textBox3.Text + "',Final='" + textBox2.Text + "',Ortalama=" + ort + " where ders_kodu='" + comboBox1.SelectedItem + "' and ogrenci_no='" + textBox1.Text + "'";
            komut.ExecuteNonQuery();
            komut.Dispose();
            baglanti.Close();
            MessageBox.Show(Convert.ToString(ort));
        }

       
    }
}
