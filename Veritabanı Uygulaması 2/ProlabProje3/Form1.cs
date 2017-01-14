using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProlabProje3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            db = new KocaeliUniversitesiDBEntities();
        }
        KocaeliUniversitesiDBEntities db;

        //Öğrenciler sekmesinde sorgula butonuna basılarak öğrenci sorgulama işlemi yapılıyor..
        private void btnSorgula_Click(object sender, EventArgs e)
        {
            Student[] ogrenciler = (from o in db.Students select o).ToArray();



            foreach (Student ogrenci in ogrenciler)
            {
                if (ogrenci.Number == txtNumara.Text)
                {
                    txtAd.Text = ogrenci.FirstName;
                    txtSoyad.Text = ogrenci.LastName;
                    txtTc.Text = ogrenci.Tc;
                    txtTelefon.Text = ogrenci.Phone;
                }
               
            }
        }

        //Öğrenciler sekmesinde ekle butonuna basılarak öğrenci ekleme işlemi yaptırılıyor..
        private void btnEkle_Click(object sender, EventArgs e)
        {
            Department secilibolum = new Department();
            secilibolum.DepartmentName = cmbBolumler.SelectedText;

            Student ogrenci = new Student()
            {
                FirstName = txtAd.Text,
                LastName = txtSoyad.Text,
                Phone = txtTelefon.Text,
                Tc = txtTc.Text,
                Number = txtNumara.Text,
                DepartmentId = Convert.ToInt32(cmbBolumler.SelectedValue)
            };

            try
            {
                if (txtTc.Text.Length < 11)
                {
                    MessageBox.Show("Lütfen TC Kimlik numarasını 11 haneli giriniz");
                }
                else if (txtNumara.Text.Length < 9)
                {
                    MessageBox.Show("Lütfen Öğrenci numarasını 9 haneli giriniz");
                }
                
                
                else
                {
                    db.Students.Add(ogrenci);
                    db.SaveChanges();
                    MessageBox.Show("Öğrenci Başarıyla Eklendi..");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ogrenci numarası,telefon numarası ve ya Tc Kimlik numarasında bir hata oluştu.\nLütfen Kontrol Edip Tekrar Deneyin...");
            }

        }

        //Form ilk açılışta comboboxlar dolduruluyor..
        Department[] bolumler;
        Faculty[] fakulteler;
        private void Form1_Load(object sender, EventArgs e)
        {
            Student[] ogrenciler = (from o in db.Students select o).ToArray();
            comboBox1.DisplayMember = "Number";
            comboBox1.DataSource = ogrenciler;

            bolumler = (from b in db.Departments select b).ToArray();
            fakulteler = (from f in db.Faculties select f).ToArray();


            cmbFakulteAd.DisplayMember = "FacultyName";
            cmbFakulteAd.DataSource = fakulteler;
            cmbFakulteAd.ValueMember = "FacultyId";


            cmbBolumler.DisplayMember = "DepartmentName";
            cmbBolumler.DataSource = bolumler;
            cmbBolumler.ValueMember = "DepartmentId";

            cmbBolumler2.DisplayMember = "DepartmentName";
            cmbBolumler2.DataSource = bolumler;
            cmbBolumler2.ValueMember = "DepartmentId";

            cmbFakulteAd.Text = "";
            cmbBolumler.Text = "";
            cmbBolumler2.Text = "";
        }

        //Öğrenciler sekmesinde sil butonuna basılarak öğrenci silme işlemi yapılıyor
        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                string ogrencino = txtNumara.Text;
                Student ogrenci = (from o in db.Students where o.Number == ogrencino select o).FirstOrDefault(); // 1 tane nesne getireceğin anlamına gelir.
                db.Students.Remove(ogrenci);
                db.SaveChanges(); //refresh yapılmış olur ve yapılan değişiklikler ana db ye aktarılır.
                txtAd.Clear();
                txtSoyad.Clear();
                txtTc.Clear();
                txtTelefon.Clear();
                txtNumara.Clear();
                MessageBox.Show("Öğrenci Silindi..");
            }
            catch (Exception)
            {

                MessageBox.Show("Silerken Bir hata oluştu.\n Lütfen Bilgileri Kontrol Edip Tekrar Deneyin...");
            }

        }


        private void cmbBolumler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        //Öğrenciler sekmesinde güncelle butonuna basılarak öğrenci güncelleme yapılır
        //Şuanda çalışmıyor!!!!
       

        private void cmbBolumler2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Department[] departmanlar = (from d in db.Departments select d).ToArray();

            foreach (Department depertman in departmanlar)
            {
                if (depertman.DepartmentName == cmbBolumler2.Text.ToString())
                {
                    txtBolumAd.Text = depertman.DepartmentName;
                    txtBolumKod.Text = depertman.DepartmentCode;
                    cmbFakulteAd.Text = depertman.Faculty.FacultyName;
                }
            }

        }

        //Bölümler sekmesinde ekle butonuna basılarak bölüm ekleme işlemi
        private void btnEkle2_Click(object sender, EventArgs e)
        {
            Department departman2 = new Department()
            {
                DepartmentName = txtBolumAd.Text,
                DepartmentCode = txtBolumKod.Text,
                FacultyId = Convert.ToInt32(cmbFakulteAd.SelectedValue)

            };

            db.Departments.Add(departman2);
            db.SaveChanges();
            BolumlerGetir();
            txtBolumAd.Clear();
            txtBolumKod.Clear();
            MessageBox.Show("Bölüm başarıyla eklendi..");
        }

        //Bölümler sekmesinde sil butonuna basılarak bölüm silme işlemi
        private void btnSil2_Click(object sender, EventArgs e)
        {
            string bolumkod = txtBolumKod.Text;
            Department departman = (from d in db.Departments where d.DepartmentCode == bolumkod select d).FirstOrDefault();
            db.Departments.Remove(departman);
            db.SaveChanges();

            BolumlerGetir();
            txtBolumAd.Clear();
            txtBolumKod.Clear();
            MessageBox.Show("Bölüm silindi..");
        }

        //Bölümlerle ilgili herhangi bir değişiklik yapıldığında bölümlerle doldurulan comboboxların içini yeniden dolduran method
        private void BolumlerGetir()
        {
            bolumler = (from b in db.Departments select b).ToArray();

            cmbBolumler.DisplayMember = "DepartmentName";
            cmbBolumler.DataSource = bolumler;
            cmbBolumler.ValueMember = "DepartmentId";

            cmbBolumler2.DisplayMember = "DepartmentName";
            cmbBolumler2.DataSource = bolumler;
            cmbBolumler2.ValueMember = "DepartmentId";
        }

        //Bölümler sekmesinde sorgula butonuna basılarak bölüm sorgulama işlemi
        private void btnSorgula2_Click(object sender, EventArgs e)
        {
            
            Department[] departmanlar = (from d in db.Departments select d).ToArray();

            foreach (Department depertman in departmanlar)
            {
                if (depertman.DepartmentName == txtBolumAd.Text)
                {
                    txtBolumAd.Text = depertman.DepartmentName;
                    txtBolumKod.Text = depertman.DepartmentCode;
                    cmbFakulteAd.SelectedText = depertman.Faculty.FacultyName;
                }
            }
        }

        //Dersler sekmesinde ekle butonuna basılarak ders ekleme işlemi
        private void btnDersEkle3_Click(object sender, EventArgs e)
        {
            Lesson lesson = new Lesson()
            {
                LessonName = txtDersAd3.Text,
                LessonCode = txtDersKod3.Text,
            };
            db.Lessons.Add(lesson);
            db.SaveChanges();
            MessageBox.Show("Ders Başarıyla Eklendi..");
        }

        //Dersler sekmesinde sil butonuna basılarak ders silme işlemi
        private void btnDersSil3_Click(object sender, EventArgs e)
        {
            string derskod = txtDersKod3.Text;
            Lesson ders = (from d in db.Lessons where d.LessonCode == derskod select d).FirstOrDefault();
            db.Lessons.Remove(ders);
            db.SaveChanges();
            txtDersAd3.Text = "";
            txtDersKod3.Text = "";
            MessageBox.Show("Ders Silindi..");
        }

        //Dersler sekmesinde sorgula butonuna basılarak ders sorgulama işlemi
        private void btnBolumSorgula3_Click(object sender, EventArgs e)
        {
            Lesson[] dersler = (from d in db.Lessons select d).ToArray();

            foreach (Lesson ders in dersler)
            {
                if (ders.LessonCode == txtDersKod3.Text)
                {
                    txtDersAd3.Text = ders.LessonName;
                    txtDersKod3.Text = ders.LessonCode;
                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        //Öğretim Üyeleri sekmesinde ekle butonuna basılarak öğretim üyesi ekleme
        private void btnOuEkle_Click(object sender, EventArgs e)
        {
            AcedemicMember ogretimuyesi = new AcedemicMember()
            {
                FirstName = txtOuAd.Text,
                LastName = txtOuSoyad.Text,
                RegisterNumber = txtOuSicilNo.Text
            };
            db.AcedemicMembers.Add(ogretimuyesi);
            db.SaveChanges();
            txtOuAd.Clear();
            txtOuSicilNo.Clear();
            txtOuSoyad.Clear();
            MessageBox.Show("Öğretim Üyesi Başarıyla Eklendi");
        }

        //Öğretim Üyeleri sekmesinde sil butonuna basılarak öğretim üyesi silme işlemi
        private void btnOuSil_Click(object sender, EventArgs e)
        {
            string ousicilno = txtOuSicilNo.Text;
            AcedemicMember ou = (from o in db.AcedemicMembers where o.RegisterNumber == ousicilno select o).FirstOrDefault();
            db.AcedemicMembers.Remove(ou);
            db.SaveChanges();
            txtOuAd.Text = "";
            txtOuSicilNo.Text = "";
            txtOuSoyad.Text = "";
            MessageBox.Show("Öğretim üyesi silindi");
        }

        //Öğretim Üyeleri sekmesinde sorgula butonuna basılarak öğretim üyesi sorgulama işlemi
        private void btnOuSorgula_Click(object sender, EventArgs e)
        {
            AcedemicMember[] ouler = (from o in db.AcedemicMembers select o).ToArray();

            foreach (AcedemicMember ou in ouler)
            {
                if (ou.RegisterNumber == txtOuSicilNo.Text)
                {
                    txtOuAd.Text = ou.FirstName;
                    txtOuSoyad.Text = ou.LastName;
                    txtOuSicilNo.Text = ou.RegisterNumber;
                }
            }
        }

        //Notlar sekmesinde numarası girilen öğrencinin aldığı dersleri getirir..
        private void btnGetir5_Click(object sender, EventArgs e)
        {

            KocaeliUniversitesiDBEntities ko = new KocaeliUniversitesiDBEntities();
            ObjectResult<AlinanDersleriGetir_Result> alinanDersler = ko.AlinanDersleriGetir(txtOgrenciNo5.Text);
            cmbAlinanDersler.DataSource = alinanDersler.ToArray();
            cmbAlinanDersler.DisplayMember = "LessonName";

            Student[] ogrenciler = (from o in db.Students select o).ToArray();

            foreach (Student ogrenci in ogrenciler)
            {
                if (ogrenci.Number == txtOgrenciNo5.Text)
                {
                    txtAd5.Text = ogrenci.FirstName;
                    txtSoyad5.Text = ogrenci.LastName;
                    
                    mtxtTelefon5.Text = ogrenci.Phone;
                }
            }

            ObjectResult<VizeFinalGetir_Result> vizefinal= ko.VizeFinalGetir(txtOgrenciNo5.Text, cmbAlinanDersler.Text);
            cmbNotlar.DataSource = vizefinal.ToArray();
            cmbNotlar.DisplayMember = "Vize1";
        }
        //Ogrenciler sekmesindeki textboxların içini temizler
        private void btnOgrenciTemizle_Click(object sender, EventArgs e)
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtTc.Clear();
            txtTelefon.Clear();
            txtNumara.Clear();
        }
        //Bolumler sekmesindeki textboxların içini temizler
        private void btnBolumTemizle_Click(object sender, EventArgs e)
        {
            txtBolumAd.Clear();
            txtBolumKod.Clear();
        }

        private void btnOgretimUyesiTemizle_Click(object sender, EventArgs e)
        {
            txtOuAd.Clear();
            txtOuSicilNo.Clear();
            txtOuSoyad.Clear();
        }

        private void txtDersTemizle_Click(object sender, EventArgs e)
        {
            txtDersAd3.Clear();
            txtDersKod3.Clear();
        }

        private void webCamCapture1_ImageCaptured(object source, WebCam_Capture.WebcamEventArgs e)
        {
            pictureBox1.Image = e.WebCamImage;
        }

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            webCamCapture1.Start(0);
        }

        private void cmbNotlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        
    }

        private void cmbAlinanDersler_SelectedIndexChanged(object sender, EventArgs e)
        {
            //KocaeliUniversitesiDBEntities ko = new KocaeliUniversitesiDBEntities();
            //ObjectResult<VizeFinalGetir_Result> vizefinal = ko.VizeFinalGetir(txtOgrenciNo5.Text, cmbAlinanDersler.Text);
            //cmbNotlar.DataSource = vizefinal.ToArray();
            //cmbNotlar.DisplayMember = "Vize1";
            //txtVize2.Text = cmbNotlar.Items();

            //txtFinal.Text = (Convert.ToInt32(txtVize1.Text) + Convert.ToInt32(Text + txtVize2.Text)).ToString();
            
        }

        Student seciliogrenci;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            seciliogrenci = (Student)comboBox1.SelectedItem;
            txtAd.Text = seciliogrenci.FirstName;
            txtSoyad.Text = seciliogrenci.LastName;
            txtTc.Text = seciliogrenci.Tc;
            txtTelefon.Text = seciliogrenci.Phone;
            txtNumara.Text = seciliogrenci.Number;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            

            
            seciliogrenci.FirstName = txtAd.Text;
            seciliogrenci.LastName = txtSoyad.Text;
            seciliogrenci.Number = txtNumara.Text;
            seciliogrenci.Phone = txtTelefon.Text;
            seciliogrenci.Tc = txtTc.Text;
            seciliogrenci.DepartmentId = Convert.ToInt32(cmbBolumler.SelectedValue);
            db.SaveChanges();
        }
        
        }
}
