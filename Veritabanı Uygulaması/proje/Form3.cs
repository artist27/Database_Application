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
    public partial class Ders : Form
    {
        public Ders()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=vt.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();

        private void Form3_Load(object sender, EventArgs e)
        {
            cmb1.Items.Clear();
            comboBox2.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Giris git = new Giris();
            git.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            cmb1.Items.Clear();
            comboBox2.Items.Clear();
            
            baglanti.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter("select ders_kodu from Verilir where bolum_kodu='" + textBox1.Text + "'", baglanti);
            ad.Fill(ds, "Alir");
            cmb1.Items.Clear();
            foreach (DataRow Satir in ds.Tables["Alir"].Rows)
            {
                
                string deger = Satir[0].ToString();
                bool durum = cmb1.Items.Contains(deger);
                if (!durum)
                {

                    cmb1.Items.Add(deger).ToString();

                }
                
               }
            baglanti.Close();
            MessageBox.Show("Açılan dersler listelendi!!");
            comboBox2.Items.Clear();
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            cmb1.Items.Clear();
            baglanti.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter("select ders_kodu from Alir where ogrenci_no='" + textBox2.Text + "'", baglanti);
            ad.Fill(ds, "Alir");

            foreach (DataRow Satir in ds.Tables["Alir"].Rows)
            {
                string deger = Satir[0].ToString();
                bool durum = comboBox2.Items.Contains(deger);
                if (!durum)
                {

                    comboBox2.Items.Add(deger).ToString();

                }
               
            }
            baglanti.Close();
            cmb1.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();


            OleDbDataAdapter adtr = new OleDbDataAdapter("Select Ortalama from Alir where ders_kodu='"+comboBox2.SelectedItem+"' and ogrenci_no='"+textBox2.Text+"'", baglanti);
            adtr.Fill(ds, "Ogrenciler");
            dataGridView1.DataSource = ds.Tables["Ogrenciler"];
            adtr.Dispose();
            baglanti.Close();
        }

       
    }
}
