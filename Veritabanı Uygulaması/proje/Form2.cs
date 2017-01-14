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
    public partial class Ögrenci : Form
    {
        public Ögrenci()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=vt.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbCommand komut1 = new OleDbCommand();
        OleDbCommand komut2 = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();

        private void button1_Click(object sender, EventArgs e)
        {
            Giris git = new Giris();
            git.Show();
            this.Visible = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut1.Connection = baglanti;
            komut2.Connection = baglanti;
            komut.CommandText = "insert into Ogrenciler(tc_no,ogrenci_no,İsim,Soyisim,tel_no) Values ('" + textBox1.Text + "','" + textBox5.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            komut1.CommandText = "insert into Okur(bolum_kodu,ogrenci_no,Durum) values ('" + textBox7.Text + "','" + textBox5.Text + "','" + textBox8.Text + "')";
            komut2.CommandText = "insert into Alir (ders_kodu) select ders_kodu from Verilir where bolum_kodu ='" + textBox7.Text + "'";
            komut.ExecuteNonQuery();
            komut1.ExecuteNonQuery();
            komut2.ExecuteNonQuery();
            komut.Dispose();
            komut1.Dispose();
            komut2.Dispose();
            baglanti.Close();
            ds.Clear();
            listele();
        }

        

        void listele()
        {
            
            baglanti.Open();
            
            
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from Ogrenciler", baglanti);
            adtr.Fill(ds, "Ogrenciler");
            dataGridView1.DataSource = ds.Tables["Ogrenciler"];
            adtr.Dispose();
            baglanti.Close();



        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox6.Text == "")
            {
                MessageBox.Show("Değer giriniz!!!");
            }
            else
            {

                ds.Clear();
                baglanti.Open();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From Ogrenciler where ogrenci_no='" + textBox6.Text + "'", baglanti);
                adtr.Fill(ds, "Ogrenciler");

                dataGridView1.DataSource = ds.Tables["Ogrenciler"];
                adtr.Dispose();
                baglanti.Close();
            }

        }
        

         private void button5_Click_1(object sender, EventArgs e)
         {
             ds.Clear();
             baglanti.Open();
             komut.Connection = baglanti;
             komut1.Connection = baglanti;
             komut2.Connection = baglanti;
             komut1.CommandText = "delete from Okur where ogrenci_no='" + textBox11.Text + "'";
             komut.CommandText = "delete from Ogrenciler where ogrenci_no='" + textBox11.Text + "'";
             komut2.CommandText = "delete from Alir where ogrenci_no='" + textBox11.Text + "'";
             komut2.ExecuteNonQuery();
             komut2.Dispose();
             komut1.ExecuteNonQuery();
             komut1.Dispose();
             komut.ExecuteNonQuery();
             komut.Dispose();
             baglanti.Close();
             listele();

         }

         private void button4_Click(object sender, EventArgs e)
         {
             ds.Clear();
             baglanti.Open();
             komut.Connection = baglanti;
             komut.CommandText = "update Ogrenciler set İsim='"+textBox2.Text+"',Soyisim='"+textBox3.Text+"',tel_no='"+textBox4.Text+"' where ogrenci_no='"+textBox5.Text+"'";
             komut.ExecuteNonQuery();
             komut.Dispose();
             baglanti.Close();
             listele();
         }

       

        
       
        
        

       

       
    }
}
