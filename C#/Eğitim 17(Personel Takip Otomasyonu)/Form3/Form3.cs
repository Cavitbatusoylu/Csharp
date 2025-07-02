using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Eğitim_17_Personel_Takip_Otomasyonu_
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        // Veritabanı bağlantısı tanımlanıyor.
        // personel.accdb dosyasına OleDb sağlayıcısı ile bağlanılır.
        OleDbConnection baglantim = new OleDbConnection("Provider = Microsoft.Ace.OleDb.12.0; Data Source = personel.accdb");


        // `personel_listele()` metodu: Personel kayıtlarını veritabanından çekip DataGridView'de görüntüler.
        private void personel_listele()
        {
            try
            {
                baglantim.Open(); // Veritabanı bağlantısı açılıyor.
                // SQL sorgusu ile 'personeller' tablosundan belirli sütunlar çekiliyor ve başlıkları yeniden adlandırılıyor.
                // NOT: "ad ad[ADI" ifadesinde yazım hatası var, "ad as [ADI]" olmalı.
                // NOT: "Order by ASC" ifadesinde hangi sütuna göre sıralanacağı belirtilmeli (örn: "Order by tcno ASC").
                OleDbDataAdapter personel_listesi = new OleDbDataAdapter("select tcno as [TC KİMLİK NO], ad ad[ADI, soyad as [SOYADI]," +
                    "cinsiyet as[CİNSİYETİ], mezuniyet as[MEZUNİYET], dogumtarihi as[DOĞUM TARİHİ], gorevi as[GÖREVİ], gorevyeri as " +
                    "[GÖREV YERİ], maasi as [MAAŞI] from personeller Order by ASC", baglantim);
                DataSet dshafiza = new DataSet(); // Verileri tutmak için bir DataSet oluşturuluyor.
                personel_listesi.Fill(dshafiza); // Adaptörden gelen veriler DataSet'e dolduruluyor.
                dataGridView1.DataSource = dshafiza.Tables[0]; // DataGridView'in veri kaynağı DataSet'in ilk tablosu olarak ayarlanıyor.
                baglantim.Close(); // Veritabanı bağlantısı kapatılıyor.
            }
            catch (Exception hatamsj)
            {
                // Hata oluşursa, hata mesajı kullanıcıya gösteriliyor.
                MessageBox.Show(hatamsj.Message, "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---

        // `Form3_Load()` olayı: Form yüklendiğinde çalışır.
        private void Form3_Load(object sender, EventArgs e)
        {
            personel_listele(); // Form yüklendiğinde personel listesi görüntüleniyor.
            this.Text = "KULLANICI İŞLEMLERİ"; // Formun başlığı ayarlanıyor.
            label19.Text = Form1.adi + " " + Form1.soyadi; // label19'a Form1'den gelen kullanıcı adı ve soyadı yazılıyor.

            // pictureBox1'in boyutları ve görüntüleme ayarları yapılıyor.
            pictureBox1.Height = 150; pictureBox1.Width = 150;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;

            try
            {
                // Kullanıcının kendi resmini yüklemeye çalışılıyor (TC kimlik numarasına göre).
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimleri\\" + Form1.tcno + ".png");
            }
            catch
            {
                // Resim bulunamazsa, varsayılan 'resimsiz.png' resmi yükleniyor.
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimleri\\resimsiz.png");
            }
        }

        // ---

        // `button1_Click()` olayı: button1'e tıklandığında çalışır (genellikle arama butonu).
        private void button1_Click(object sender, EventArgs e)
        {
            bool kayit_okuma_durumu = false; // Kayıt bulunup bulunmadığını kontrol eden bayrak.
            if (maskedTextBox1.Text.Length == 11) // maskedTextBox1'deki metnin 11 haneli olup olmadığı kontrol ediliyor (TC Kimlik No için).
            {
                baglantim.Open(); // Veritabanı bağlantısı açılıyor.
                // maskedTextBox1'deki TC Kimlik Numarasına göre 'personel' tablosunda arama sorgusu oluşturuluyor.
                // NOT: maskedTextBox1'in metin değeri yerine doğrudan nesnenin kendisi kullanılmış, ".Text" eklenmeliydi.
                OleDbCommand selectsorgu = new OleDbCommand("Select * from personel where tcno='" + maskedTextBox1.Text + "'", baglantim);
                OleDbDataReader kayit_okuma = selectsorgu.ExecuteReader(); // Sorgu çalıştırılıyor ve okuyucu ile sonuçlar alınıyor.

                while (kayit_okuma.Read()) // Kayıtlar okunmaya devam ettiği sürece döngü devam ediyor.
                {
                    kayit_okuma_durumu = true; // Kayıt bulundu olarak işaretleniyor.
                    try
                    {
                        // Bulunan kaydın fotoğrafı yüklenmeye çalışılıyor (ilk sütundaki değere göre).
                        pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimleri\\" + kayit_okuma.GetValue(0) + ".png");
                    }
                    catch
                    {
                        // Fotoğraf bulunamazsa, varsayılan 'resimsiz.png' resmi yükleniyor.
                        pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimleri\\resimsiz.png");
                    }
                    // Okunan personel bilgileri ilgili Label kontrollerine atanıyor.
                    label10.Text = kayit_okuma.GetValue(1).ToString(); // Adı
                    label11.Text = kayit_okuma.GetValue(2).ToString(); // Soyadı
                    if (kayit_okuma.GetValue(3).ToString() == "Bay") // Cinsiyet kontrolü yapılıyor.
                        label12.Text = "Bay";
                    else
                        label12.Text = "Bayan";
                    label13.Text = kayit_okuma.GetValue(4).ToString(); // Mezuniyet
                    label14.Text = kayit_okuma.GetValue(5).ToString(); // Doğum Tarihi
                    label15.Text = kayit_okuma.GetValue(6).ToString(); // Görevi
                    label16.Text = kayit_okuma.GetValue(7).ToString(); // Görev Yeri
                    label17.Text = kayit_okuma.GetValue(8).ToString(); // Maaşı
                    break; // Kayıt bulunduktan sonra döngüden çıkılıyor (TC Kimlik No benzersiz olduğu için).
                }
                if (kayit_okuma_durumu == false)
                    // Eğer kayıt bulunamazsa mesaj gösteriliyor.
                    MessageBox.Show("Aranan Kayıt Bulunamadı");
                baglantim.Close(); // Veritabanı bağlantısı kapatılıyor.
            }
            else
                // TC Kimlik Numarası 11 haneli değilse uyarı gösteriliyor.
                MessageBox.Show("TC Kimlik Numarası 11 Haneli Olmalıdır.");
        }
    }
}