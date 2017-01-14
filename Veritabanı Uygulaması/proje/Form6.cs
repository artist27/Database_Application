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
    public partial class OgretimUyesi : Form
    {
        public OgretimUyesi()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=vt.accdb");
      
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        OleDbDataAdapter adt = new OleDbDataAdapter();
        OleDbDataAdapter ad = new OleDbDataAdapter();
        DataSet ds = new DataSet();

        private void button1_Click(object sender, EventArgs e)
        {
            Giris git = new Giris();
            git.Show();
            this.Visible = false;
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            baglanti.Open();
            
            OleDbDataAdapter ad = new OleDbDataAdapter("select ders_kodu from Verir where sicil_no=" + Convert.ToInt32(textBox1.Text) + "", baglanti);
            ad.Fill(ds, "Verir");

            foreach (DataRow Satir in ds.Tables["Verir"].Rows)
            {
                string deger = Satir[0].ToString();
                bool durum = comboBox1.Items.Contains(deger);
                if (!durum)
                {

                    comboBox1.Items.Add(deger).ToString();

                }
                baglanti.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select ders_kodu from Alir where ogrenci_no='"+textBox2.Text+"'", baglanti);
            adtr.Fill(ds, "Alir");
            dataGridView1.DataSource = ds.Tables["Alir"];
            adtr.Dispose();
    
            
          /*  OleDbDataAdapter adt = new OleDbDataAdapter("select sicil_no from Ogretim_Uyeleri where bolum_kodu in(select bolum_kodu  from Okur where ogrenci_no='"+textBox2.Text+"' )", baglanti);
           
            adt.Fill(ds, "Ogretim_Uyeleri");
            dataGridView2.DataSource = ds.Tables["Ogretim_Uyeleri"];
            adt.Dispose();*/
            baglanti.Close();

        }

       
    }
}
