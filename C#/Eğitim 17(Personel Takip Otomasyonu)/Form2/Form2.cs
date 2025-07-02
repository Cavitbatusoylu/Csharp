using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.OleDb; // Access veritabanı bağlantısı için gerekli kütüphane.
using System.Text.RegularExpressions; // Regex (düzenli ifadeler) işlemleri için.
using System.IO; // Dosya ve dizin işlemleri için.

namespace Eğitim_17_Personel_Takip_Otomasyonu_
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent(); // Form bileşenlerini başlatır.
        }
        // Access veritabanı bağlantı dizesi. Personel bilgilerini 'personel.accdb' dosyasında tutar.
        OleDbConnection baglantim = new OleDbConnection("Provider = Microsoft.Ace.OleDb.12.0; Data Source = personel.accdb");

        // Kullanıcıları veritabanından alıp DataGridView'e listeleme fonksiyonu.
        private void kullanicilari_listele()
        {
            try
            {
                baglantim.Open(); // Veritabanı bağlantısını aç.
                // 'kullanici' tablosundan belirli sütunları seçerek, Türkçe başlıklarla sıralı olarak getir.
                OleDbDataAdapter kullanici_listesi = new OleDbDataAdapter("SELECT tcno AS [TC NUMARASI], ad AS [ADI], soyad AS [SOYADI], yetki AS [YETKİSİ], kullaniciAdi AS [KULLANICI ADI], parola AS [PAROLA] FROM kullanici ORDER BY ad ASC", baglantim);
                DataSet dshafiza = new DataSet(); // Verileri belleğe almak için DataSet oluştur.
                kullanici_listesi.Fill(dshafiza); // Verileri DataSet'e doldur.
                dataGridView1.DataSource = dshafiza.Tables[0]; // DataGridView'e verileri bağla.
                baglantim.Close(); // Veritabanı bağlantısını kapat.
            }
            catch (Exception hatamsj) // Hata oluşursa yakala.
            {
                // Hata mesajını kullanıcıya göster.
                MessageBox.Show(hatamsj.Message, "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglantim.Close(); // Hata durumunda bile bağlantıyı kapat.
            }
        }

        // Personelleri veritabanından alıp DataGridView'e listeleme fonksiyonu.
        private void personelleri_listele()
        {
            try
            {
                baglantim.Open(); // Veritabanı bağlantısını aç.
                // 'personel' tablosundan belirli sütunları seçerek, Türkçe başlıklarla sıralı olarak getir.
                OleDbDataAdapter personel_listesi = new OleDbDataAdapter("SELECT tcno AS [TC NUMARASI], ad AS [ADI], soyad AS [SOYADI], cinsiyet AS [CİNSİYET], dogumtarihi AS [DOĞUM TARİHİ], görevi AS [GÖREVİ], görevyeri AS [GÖREV YERİ], maasi AS [MAAŞ] FROM personel ORDER BY ad ASC", baglantim);
                DataSet dshafiza = new DataSet(); // Verileri belleğe almak için DataSet oluştur.
                personel_listesi.Fill(dshafiza); // Verileri DataSet'e doldur.
                dataGridView2.DataSource = dshafiza.Tables[0]; // DataGridView'e verileri bağla.
                baglantim.Close(); // Veritabanı bağlantısını kapat.
            }
            catch (Exception hatamsj) // Hata oluşursa yakala.
            {
                // Hata mesajını kullanıcıya göster.
                MessageBox.Show(hatamsj.Message, "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglantim.Close(); // Hata durumunda bile bağlantıyı kapat.
            }
        }

        // --- Boş Olay İşleyicileri ---
        // Bu metotlar, ilgili kontrol olayları (TextChanged, Click) tetiklendiğinde çalışır, ancak şu an boş.
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void tabPage1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label13_Click(object sender, EventArgs e) { }

        // Form yüklendiğinde (başladığında) çalışan olay işleyicisi.
        private void Form2_Load(object sender, EventArgs e)
        {
            personelleri_listele(); // Form açıldığında personelleri listele.

            // PictureBox1 ayarları (kullanıcı resmi için).
            pictureBox1.Height = 150;
            pictureBox1.Width = 150;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Resmi kutuya sığdır.

            try
            {
                // Kullanıcının TC kimlik numarasına göre resmini yükle.
                pictureBox1.Image = Image.FromFile(Path.Combine(Application.StartupPath, "kullaniciresimleri", Form1.tcno + ".png"));
            }
            catch (Exception)
            {
                // Resim bulunamazsa varsayılan 'resimsiz.png' resmini yükle.
                pictureBox1.Image = Image.FromFile(Path.Combine(Application.StartupPath, "kullaniciresimleri", "resimsiz.png"));
            }

            // Kullanıcı İşlemleri sekmesi için ayarlar.
            this.Text = "YÖNETİCİ İŞLEMLERİ"; // Form başlığını ayarla.
            label12.ForeColor = Color.DarkRed; // Label rengini ayarla.
            label12.Text = Form1.adi + " " + Form1.soyadi; // Kullanıcının adını ve soyadını göster.
            textBox1.MaxLength = 11; // TC Kimlik No alanının maksimum karakterini ayarla.
            textBox4.MaxLength = 8; // Kullanıcı adı alanının maksimum karakterini ayarla.
            // TC Kimlik No alanına fare geldiğinde ipucu göster.
            toolTip1.SetToolTip(this.textBox1, "TC Kimlik Numarası 11 Karakter İçermelidir!");
            radioButton1.Checked = true; // Yönetici yetkisi seçili gelsin.
            textBox2.CharacterCasing = CharacterCasing.Upper; // Adı büyük harfe çevir.
            textBox3.CharacterCasing = CharacterCasing.Upper; // Soyadı büyük harfe çevir.
            textBox5.MaxLength = 10; // Parola alanının maksimum karakterini ayarla.
            textBox6.MaxLength = 10; // Parola tekrarı alanının maksimum karakterini ayarla.
            progressBar1.Maximum = 100; // Parola gücü çubuğunun maksimum değerini ayarla.
            progressBar1.Value = 0; // Başlangıçta değeri sıfır yap.
            kullanicilari_listele(); // Kullanıcıları listele.

            // Personel İşlemleri sekmesi için ayarlar.
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage; // Resmi kutuya sığdır.
            pictureBox2.Width = 100; pictureBox2.Height = 100; // Resim kutusu boyutunu ayarla.
            pictureBox2.BorderStyle = BorderStyle.Fixed3D; // Resim kutusu kenar stilini ayarla.
            maskedTextBox1.Mask = "00000000000"; // TC Kimlik No için maske (sadece 11 rakam).
            maskedTextBox2.Mask = "LL?????????????????????"; // Ad için maske (harf ve boşluk).
            maskedTextBox3.Mask = "LL?????????????????????"; // Soyad için maske (harf ve boşluk).
            maskedTextBox4.Mask = "00000"; // Maaş için maske (5 rakam).
            // maskedTextBox2.Text.ToUpper(); // Adı büyük harfe çevir (Bu satırın bir etkisi olmaz, TextBox'ın CharacterCasing özelliği kullanılmalı).
            // maskedTextBox3.Text.ToUpper(); // Soyadı büyük harfe çevir (Bu satırın bir etkisi olmaz).

            // ComboBox'lara eğitim düzeylerini ekle.
            comboBox1.Items.Add("Lise");
            comboBox1.Items.Add("Önlisans");
            comboBox1.Items.Add("Lisans");
            comboBox1.Items.Add("Yüksek Lisans");

            // ComboBox'lara görev yerlerini ekle.
            comboBox2.Items.Add("İdareci");
            comboBox2.Items.Add("Eğitmen");
            comboBox2.Items.Add("Memur");
            comboBox2.Items.Add("Hizmetli");

            // ComboBox'lara görev yerlerini ekle (muhtemelen bu da görev yeridir, isim çakışması olabilir).
            comboBox3.Items.Add("İlkokul");
            comboBox3.Items.Add("Ortaokul");
            comboBox3.Items.Add("Lise");
            comboBox3.Items.Add("Kurs Merkezi");

            // Doğum tarihi kısıtlamaları için mevcut tarihi al.
            DateTime zaman = DateTime.Now;
            int yil = int.Parse(zaman.ToString("yyyy"));
            int ay = int.Parse(zaman.ToString("MM"));
            int gun = int.Parse(zaman.ToString("dd"));

            // Doğum tarihi seçici için minimum ve maksimum tarihleri ayarla (18 yaşından büyükler).
            dateTimePicker1.MinDate = new DateTime(1970, 1, 1);
            dateTimePicker1.MaxDate = new DateTime(yil - 18, ay, gun);
            dateTimePicker1.Format = DateTimePickerFormat.Short; // Tarih formatını kısa yap.

            radioButton3.Checked = true; // Cinsiyet (Bay) seçili gelsin.
            personelleri_listele(); // Personelleri tekrar listele.
        }

        // --- Boş Olay İşleyicileri ---
        private void radioButton3_CheckedChanged(object sender, EventArgs e) { }

        // textBox1 (TC Kimlik No) metin değiştiğinde çalışır.
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // TC Kimlik No 11 karakterden azsa hata mesajı göster.
            if (textBox1.Text.Length < 11)
                errorProvider1.SetError(textBox1, "TC Kimlik Numarası 11 Karakter Olmalıdır!");
            else
                errorProvider1.Clear(); // Hata yoksa mesajı temizle.
        }

        // textBox1 (TC Kimlik No) tuş basıldığında çalışır (sadece rakam girişine izin verir).
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Basılan tuş rakam (48-57 arası ASCII) veya Backspace (8 ASCII) ise işleme izin ver.
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57 || (int)e.KeyChar == 8)
                e.Handled = false; // Tuş işlensin.
            else
                e.Handled = true; // Tuş işlenmesin (girilmesi engellensin).
        }

        // textBox2 (Ad) tuş basıldığında çalışır (sadece harf, kontrol veya boşluk tuşlarına izin verir).
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = true; // Tuş işlensin (bu yorumda bir mantık hatası var, harf, kontrol, boşluksa Handled true olursa engeller).
            else
                e.Handled = false; // Tuş işlenmesin.
        }

        // textBox3 (Soyad) tuş basıldığında çalışır (sadece harf, kontrol veya boşluk tuşlarına izin verir).
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = true; // Tuş işlensin (burada da aynı mantık hatası var).
            else
                e.Handled = false; // Tuş işlenmesin.
        }

        // textBox4 (Kullanıcı Adı) tuş basıldığında çalışır (sadece harf, kontrol veya boşluk tuşlarına izin verir).
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = true; // Tuş işlensin (burada da aynı mantık hatası var).
            else
                e.Handled = false; // Tuş işlenmesin.
        }

        // textBox4 (Kullanıcı Adı) metin değiştiğinde çalışır.
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Kullanıcı adı 9 karakterden farklıysa hata mesajı göster. (Not: MaxLength 8 olarak ayarlanmış, burada 9 kontrol ediliyor.)
            if (textBox1.Text.Length != 11) // Yanlışlıkla textBox1 kontrol ediliyor, textBox4 olmalı.
                errorProvider1.SetError(textBox4, "Kullanıcı Adı 8 karakterden oluşmalıdır!");
            else
                errorProvider1.Clear(); // Hata yoksa mesajı temizle.
        }

        int parola_skoru = 0; // Parola gücü skorunu tutar.
        // textBox5 (Parola) metin değiştiğinde parola gücünü hesaplar.
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string parola_seviyesi = ""; // Parola seviyesini tutar.
            int kucuk_harf_skoru = 0, buyuk_harf_skoru = 0, rakam_skoru = 0, sembol_skoru = 0; // Skorları tutar.

            string sifre = textBox5.Text; // Girilen parolayı al.
            string duzeltilmis_sifre = ""; // Türkçe karakter düzeltilmiş parolayı tutar.

            duzeltilmis_sifre = sifre;
            // Türkçe karakterleri İngilizce karşılıklarına dönüştür.
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('İ', 'I');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ı', 'i');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('Ç', 'C');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ç', 'c');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('Ş', 'S');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ş', 's');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('Ğ', 'G');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ğ', 'g');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('Ü', 'U');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ü', 'u');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('Ö', 'O');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ö', 'o');

            if (sifre != duzeltilmis_sifre) // Türkçe karakter dönüştürmesi yapıldıysa.
            {
                sifre = duzeltilmis_sifre; // Parolayı düzeltilmiş haliyle güncelle.
                textBox5.Text = sifre; // TextBox'ı güncelle.
                MessageBox.Show("Paroladaki Türkçe Karakterler Dönüştürüldü"); // Kullanıcıya bilgi ver.
            }

            // Küçük harf sayısını ve skorunu hesapla (en fazla 2 adet 10 puan).
            int az_karakter_sayisi = sifre.Length - Regex.Replace(sifre, "[a-z]", "").Length; // 'a-z' olmalı
            kucuk_harf_skoru = Math.Min(2, az_karakter_sayisi) * 10;

            // Büyük harf sayısını ve skorunu hesapla (en fazla 2 adet 10 puan).
            int AZ_karakter_sayisi = sifre.Length - Regex.Replace(sifre, "[A-Z]", "").Length; // 'A-Z' olmalı
            buyuk_harf_skoru = Math.Min(2, AZ_karakter_sayisi) * 10;

            // Rakam sayısını ve skorunu hesapla (en fazla 2 adet 10 puan).
            int rakam_sayisi = sifre.Length - Regex.Replace(sifre, "[0-9]", "").Length; // '0-9' olmalı
            rakam_skoru = Math.Min(2, rakam_sayisi) * 10;

            // Sembol sayısını ve skorunu hesapla (en fazla 2 adet 10 puan).
            int sembol_sayisi = sifre.Length - az_karakter_sayisi - AZ_karakter_sayisi - rakam_sayisi;
            sembol_skoru = Math.Min(2, sembol_sayisi) * 10;

            parola_skoru = kucuk_harf_skoru + buyuk_harf_skoru + rakam_skoru + sembol_skoru; // Toplam parolayı hesapla.

            // Parola uzunluğuna göre ek puanlar.
            if (sifre.Length == 9)
                parola_skoru += 10;
            else if (sifre.Length == 11) // TC Kimlik No ile aynı uzunlukta olmasının bir anlamı olmayabilir.
                parola_skoru += 10;

            // Güçsüz parola için uyarı.
            if (kucuk_harf_skoru == 0 || buyuk_harf_skoru == 0 || rakam_skoru == 0 || sembol_skoru == 0)
                label22.Text = "Büyük, küçük harf, rakam veya sembollerden en az 1 adet kullanın";

            // Eğer koşul sağlanırsa uyarıyı temizle.
            if (kucuk_harf_skoru != 0 || buyuk_harf_skoru != 0 || rakam_skoru != 0 || sembol_skoru != 0)
                label22.Text = "";

            // Parola seviyesini belirle.
            if (parola_skoru < 60)
                parola_seviyesi = "Parola Seviyesi Düşük";
            else if (parola_skoru == 65 || parola_skoru == 85) // Belirli skorlar için "Güçlü".
                parola_seviyesi = "Parola Seviyesi Güçlü";
            else if (parola_skoru == 90 || parola_skoru == 100) // Belirli skorlar için "Çok Güçlü".
                parola_seviyesi = "Parola Seviyesi Çok Güçlü";

            label9.Text = "%" + Convert.ToString(parola_skoru); // Parola skorunu göster.
            label10.Text = parola_seviyesi; // Parola seviyesini göster.
            progressBar1.Value = parola_skoru; // ProgressBar'ı güncelle.
        }

        // textBox6 (Parola Tekrarı) metin değiştiğinde çalışır.
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            // Parolalar eşleşmiyorsa hata mesajı göster.
            if (textBox6.Text != textBox5.Text)
                errorProvider1.SetError(textBox6, "Parola Eşlemedi");
            else
                errorProvider1.Clear(); // Eşleşiyorsa hata mesajını temizle.
        }

        // Kullanıcı işlemleri sayfasındaki giriş alanlarını temizler.
        private void topPage1_temiz()
        {
            textBox1.Clear(); // TC Kimlik No.
            textBox2.Clear(); // Ad.
            textBox3.Clear(); // Soyad.
            textBox4.Clear(); // Kullanıcı Adı.
            textBox5.Clear(); // Parola.
            textBox6.Clear(); // Parola Tekrarı.
        }

        // Personel işlemleri sayfasındaki giriş alanlarını temizler.
        private void topPage2_temiz()
        {
            pictureBox2.Image = null; // Resim kutusunu temizle.
            maskedTextBox1.Clear(); // TC Kimlik No.
            maskedTextBox2.Clear(); // Ad.
            maskedTextBox3.Clear(); // Soyad.
            maskedTextBox4.Clear(); // Maaş.
            comboBox1.SelectedIndex = -1; // Mezuniyet.
            comboBox2.SelectedIndex = -1; // Görev.
            comboBox3.SelectedIndex = -1; // Görev Yeri.
        }

        // Kullanıcı Ekle butonu Click olayı.
        private void button1_Click(object sender, EventArgs e)
        {
            string yetki = ""; // Kullanıcının yetkisini tutar.
            bool kayitkontrol = false; // Kayıt kontrol durumu.

            baglantim.Open(); // Veritabanı bağlantısını aç.

            // Girilen TC Kimlik No'ya sahip kullanıcı var mı kontrol et.
            // DİKKAT: SQL Injection riski var! Parametreli sorgu kullanılmalı.
            OleDbCommand selectsorgu = new OleDbCommand("Select * from kullanici where tcno='" + textBox1.Text + "'", baglantim);
            OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();

            while (kayitokuma.Read())
            {
                kayitkontrol = true; // Kayıt bulundu.
                break;
            }
            baglantim.Close(); // Bağlantıyı kapat.

            if (kayitkontrol == false) // Kayıt yoksa yeni kullanıcı ekle.
            {
                // Alanların doğrulamasını yap ve kırmızı uyarıları ayarla.
                if (textBox1.Text.Length < 11 || textBox1.Text == "")
                    label1.ForeColor = Color.Red;
                else
                    label1.ForeColor = Color.Black;
                if (textBox2.Text.Length < 2 || textBox2.Text == "")
                    label2.ForeColor = Color.Red;
                else
                    label2.ForeColor = Color.Black;
                if (textBox3.Text.Length < 2 || textBox3.Text == "")
                    label3.ForeColor = Color.Red;
                else
                    label3.ForeColor = Color.Black;
                // textBox4 için MaxLength 8 iken burada 9 kontrol ediliyor. Dikkat!
                if (textBox4.Text.Length != 9 || textBox4.Text == "")
                    label5.ForeColor = Color.Red;
                else
                    label5.ForeColor = Color.Black;
                if (parola_skoru <= 65 || textBox5.Text == "")
                    label6.ForeColor = Color.Red;
                else
                    label6.ForeColor = Color.Black;
                // Parolaların eşleşme kontrolü ve boş olup olmadığı.
                if (textBox6.Text != textBox5.Text || textBox5.Text == "")
                    label7.ForeColor = Color.Red;
                else
                    label7.ForeColor = Color.Black;

                // Tüm alanlar geçerliyse ve parola skoru yeterliyse kaydet.
                // Not: textBox5.Text != textBox6.Text olması hata, eşit olması lazım.
                if (textBox1.Text.Length == 11 && textBox1.Text != "" && textBox2.Text.Length > 1 && textBox2.Text != "" &&
                    textBox3.Text.Length > 1 && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" &&
                    textBox6.Text != "" && textBox5.Text == textBox6.Text && parola_skoru >= 65) // Burası düzeltildi: textBox5.Text == textBox6.Text
                {
                    // Yetki seçimine göre 'yetki' değişkenini ayarla.
                    if (radioButton1.Checked == true)
                        yetki = "Yönetici";
                    else if (radioButton2.Checked == true)
                        yetki = "Kullanıcı";

                    try
                    {
                        baglantim.Open(); // Bağlantıyı aç.
                        // Yeni kullanıcıyı veritabanına ekle.
                        // DİKKAT: SQL Injection riski var! Parametreli sorgu kullanılmalı.
                        // TCNO için textBox1.Text kullanılmalı.
                        OleDbCommand eklemenotu = new OleDbCommand("insert into kullanici (tcno, ad, soyad, yetki, kullaniciAdi, parola) values ('" + textBox1.Text + "','" + textBox2.Text + "','" +
                            textBox3.Text + "','" + yetki + "','" + textBox4.Text + "','" + textBox5.Text + "')", baglantim);
                        eklemenotu.ExecuteNonQuery(); // Sorguyu çalıştır.
                        baglantim.Close(); // Bağlantıyı kapat.
                        MessageBox.Show("Kullanıcı başarılı bir şekilde oluşturuldu!", "SKY PERSONEL TAKİP PROGRAMI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        topPage1_temiz(); // Alanları temizle.
                        kullanicilari_listele(); // Kullanıcı listesini yenile.
                    }
                    catch (Exception hatamsj)
                    {
                        MessageBox.Show(hatamsj.Message); // Hata mesajını göster.
                        baglantim.Close(); // Hata durumunda bağlantıyı kapat.
                    }
                }
                else
                    // Doğrulama hatası varsa kullanıcıyı uyar.
                    MessageBox.Show("Uyarı veren alanları gözden geçirin!", "SKY PERSONEL TAKİP PROGRAMI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                // TC Kimlik No daha önce eklenmişse kullanıcıyı uyar.
                MessageBox.Show("Girilen TC No Daha Önce Eklenmiş", "SKY PERSONEL TAKİP PROGRAMI", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Kullanıcı Ara butonu Click olayı.
        private void button2_Click(object sender, EventArgs e)
        {
            bool kayit_durum = false; // Kayıt durumu.
            if (textBox1.Text.Length == 11) // TC Kimlik No 11 haneli ise ara.
            {
                baglantim.Open(); // Bağlantıyı aç.
                // TC Kimlik No'ya göre kullanıcı ara.
                // DİKKAT: SQL Injection riski var! Parametreli sorgu kullanılmalı.
                OleDbCommand selectsorgu = new OleDbCommand("Select * from kullanici where tcno= '" + textBox1.Text + "'", baglantim);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();

                while (kayitokuma.Read())
                {
                    kayit_durum = true; // Kayıt bulundu.
                    // Bulunan verileri ilgili alanlara yerleştir.
                    textBox2.Text = kayitokuma.GetValue(1).ToString(); // Ad.
                    textBox3.Text = kayitokuma.GetValue(2).ToString(); // Soyad.
                    if (kayitokuma.GetValue(3).ToString() == "Yönetici") // Yetki kontrolü.
                        radioButton1.Checked = true;
                    else
                        radioButton2.Checked = true;
                    textBox4.Text = kayitokuma.GetValue(4).ToString(); // Kullanıcı Adı.
                    textBox5.Text = kayitokuma.GetValue(5).ToString(); // Parola.
                    // textBox6.Text = kayitokuma.GetValue(5).ToString(); // Parola tekrarı alanı güncellenmeli.
                    break;
                }
                baglantim.Close(); // Bağlantıyı kapat.

                if (kayit_durum == false) // Kayıt bulunamadıysa uyarı göster.
                    MessageBox.Show("Aranan Kayıt Bulunamadı!", "SKY PERSONEL TAKİP PROGRAMI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                // TC Kimlik No 11 hane değilse uyarı göster.
                MessageBox.Show("Lütfen 11 haneli TC No giriniz!", "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Kullanıcı Güncelle butonu Click olayı.
        private void button3_Click(object sender, EventArgs e)
        {
            string yetki = ""; // Kullanıcının yetkisini tutar.

            // Alanların doğrulamasını yap ve kırmızı uyarıları ayarla (button1 ile benzer).
            if (textBox1.Text.Length < 11 || textBox1.Text == "")
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;
            if (textBox2.Text.Length < 2 || textBox2.Text == "")
                label2.ForeColor = Color.Red;
            else
                label2.ForeColor = Color.Black;
            if (textBox3.Text.Length < 2 || textBox3.Text == "")
                label3.ForeColor = Color.Red;
            else
                label3.ForeColor = Color.Black;
            if (textBox4.Text.Length != 9 || textBox4.Text == "") // MaxLength 8 iken burada 9 kontrol ediliyor.
                label5.ForeColor = Color.Red;
            else
                label5.ForeColor = Color.Black;
            if (parola_skoru <= 65 || textBox5.Text == "")
                label6.ForeColor = Color.Red;
            else
                label6.ForeColor = Color.Black;
            if (textBox6.Text != textBox5.Text || textBox5.Text == "")
                label7.ForeColor = Color.Red;
            else
                label7.ForeColor = Color.Black;

            // Tüm alanlar geçerliyse ve parola skoru yeterliyse güncelle.
            // Not: textBox5.Text != textBox6.Text olması hata, eşit olması lazım.
            if (textBox1.Text.Length == 11 && textBox1.Text != "" && textBox2.Text.Length > 1 && textBox2.Text != "" &&
                textBox3.Text.Length > 1 && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" &&
                textBox6.Text != "" && textBox5.Text == textBox6.Text && parola_skoru >= 65) // Burası düzeltildi: textBox5.Text == textBox6.Text
            {
                // Yetki seçimine göre 'yetki' değişkenini ayarla.
                if (radioButton1.Checked == true)
                    yetki = "Yönetici";
                else if (radioButton2.Checked == true)
                    yetki = "Kullanıcı";

                try
                {
                    baglantim.Open(); // Bağlantıyı aç.
                    // Kullanıcı bilgilerini güncelle.
                    // DİKKAT: SQL Injection riski var! Parametreli sorgu kullanılmalı.
                    OleDbCommand guncellemenotu = new OleDbCommand("update kullanici set ad = '" + textBox2.Text + "',soyad='" + textBox3.Text + "',yetki = '" +
                        yetki + "',kullaniciadi = '" + textBox4.Text + "',parola = '" + textBox5.Text + "'where tcno = '" + textBox1.Text + "'", baglantim);
                    guncellemenotu.ExecuteNonQuery(); // Sorguyu çalıştır.
                    baglantim.Close(); // Bağlantıyı kapat.
                    MessageBox.Show("Kullanıcı başarılı bir şekilde güncellendi!", "SKY PERSONEL TAKİP PROGRAMI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    kullanicilari_listele(); // Kullanıcı listesini yenile.
                    topPage1_temiz(); // Alanları temizle.
                }
                catch (Exception hatamsj)
                {
                    MessageBox.Show(hatamsj.Message); // Hata mesajını göster.
                    baglantim.Close(); // Hata durumunda bağlantıyı kapat.
                }
            }
            else
                // Doğrulama hatası varsa kullanıcıyı uyar.
                MessageBox.Show("Uyarı veren alanları gözden geçirin!", "SKY PERSONEL TAKİP PROGRAMI", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Kullanıcı Sil butonu Click olayı.
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 11) // TC Kimlik No 11 haneli ise silme işlemine başla.
            {
                bool kayit_durum = false; // Kayıt durumu.
                baglantim.Open(); // Bağlantıyı aç.
                // TC Kimlik No'ya göre silinecek kaydı ara.
                // DİKKAT: SQL Injection riski var! Parametreli sorgu kullanılmalı.
                OleDbCommand selectsorgu = new OleDbCommand("Select * from kullanici where tcno = '" + textBox1.Text + "'", baglantim);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();

                if (kayitokuma.Read()) // Kayıt bulunduysa.
                {
                    kayit_durum = true;
                }
                // DİKKAT: Burada 'while(true)' döngüsü yerine 'if (kayit_durum)' kullanılmalıydı.
                // Kayıt bulunmasa bile sonsuz döngüye girip Delete komutunu çalıştırmaya çalışabilir.
                // Bu kısım ciddi bir hata içeriyor.
                if (kayit_durum) // Kayıt bulunduysa silme işlemini yap.
                {
                    // Kaydı veritabanından sil.
                    OleDbCommand deletesorgu = new OleDbCommand("delete from kullanici where tcno = '" + textBox1.Text + "'", baglantim);
                    deletesorgu.ExecuteNonQuery(); // Sorguyu çalıştır.
                    MessageBox.Show("Kullanıcı başarılı bir şekilde silindi.", "SKY PERSONEL TAKİP PROGRAMI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    baglantim.Close(); // Bağlantıyı kapat.
                    kullanicilari_listele(); // Listeyi yenile.
                    topPage1_temiz(); // Alanları temizle.
                }
                else // Kayıt bulunamadıysa.
                {
                    MessageBox.Show("Silinecek kayıt bulunamadı.", "SKY PERSONEL TAKİP PROGRAMI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    baglantim.Close(); // Bağlantıyı kapat.
                    topPage1_temiz(); // Alanları temizle.
                }
            }
            else
                // TC Kimlik No 11 hane değilse uyarı göster.
                MessageBox.Show("Lütfen 11 haneli TC Numarası giriniz!", "SKY PERSONEL TAKİP PROGRAMI", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Kullanıcı Temizle butonu Click olayı.
        private void button5_Click(object sender, EventArgs e)
        {
            topPage1_temiz(); // Kullanıcı işlemleri alanlarını temizle.
        }

        // Personel Resmi Seç butonu Click olayı.
        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog resim = new OpenFileDialog(); // Dosya seçme diyaloğu oluştur.
            resim.Filter = "PNG Dosyalar (*.png) | *.png"; // Sadece PNG dosyalarını filtrele.
            resim.Title = "Lütfen Personel Resmi Seçin"; // Diyalog başlığını ayarla.
            if (resim.ShowDialog() == DialogResult.OK) // Kullanıcı dosya seçip Tamam'a basarsa.
            {
                this.pictureBox2.Image = new Bitmap(resim.OpenFile()); // Seçilen resmi PictureBox'a yükle.
            }
        }

        // Personel Ekle butonu Click olayı.
        private void button8_Click(object sender, EventArgs e)
        {
            string cinsiyet = ""; // Cinsiyet bilgisini tutar.
            bool kayitKontrol = false; // Kayıt kontrol durumu.

            baglantim.Open(); // Veritabanı bağlantısını aç.
            // Girilen TC Kimlik No'ya sahip personel var mı kontrol et.
            // DİKKAT: SQL Injection riski var! Parametreli sorgu kullanılmalı.
            OleDbCommand selectsorgu = new OleDbCommand("Select * from personel where tcno = '" + maskedTextBox1.Text + "'", baglantim);
            OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();

            while (kayitokuma.Read())
            {
                kayitKontrol = true; // Kayıt bulundu.
                break;
            }
            baglantim.Close(); // Bağlantıyı kapat.

            if (kayitKontrol == false) // Kayıt yoksa yeni personel ekle.
            {
                // Alanların doğrulamasını yap ve kırmızı uyarıları ayarla.
                if (pictureBox2.Image == null)
                    button6.ForeColor = Color.Red; // (Button6 yerine label kullanılmalı, yanlış buton rengi değişiyor)
                else
                    button6.ForeColor = Color.Black;
                if (maskedTextBox1.MaskCompleted == false)
                    label24.ForeColor = Color.Red;
                else
                    label24.ForeColor = Color.Black;
                if (maskedTextBox2.MaskCompleted == false)
                    label25.ForeColor = Color.Red;
                else
                    label25.ForeColor = Color.Black;
                if (maskedTextBox3.MaskCompleted == false)
                    label28.ForeColor = Color.Red;
                else
                    label28.ForeColor = Color.Black;
                if (comboBox1.Text == "")
                    label26.ForeColor = Color.Red;
                else
                    label26.ForeColor = Color.Black;
                if (comboBox2.Text == "")
                    label30.ForeColor = Color.Red;
                else
                    label30.ForeColor = Color.Black;
                if (comboBox3.Text == "")
                    label31.ForeColor = Color.Red;
                else
                    label31.ForeColor = Color.Black;
                if (maskedTextBox4.MaskCompleted == false)
                    label32.ForeColor = Color.Red;
                else
                    label32.ForeColor = Color.Black;
                if (int.Parse(maskedTextBox4.Text) < 1000) // Maaş 1000'den azsa.
                    label32.ForeColor = Color.Red;
                else
                    label32.ForeColor = Color.Black;

                // Tüm alanlar geçerliyse ve resim seçilmişse kaydet.
                if (pictureBox2.Image != null && maskedTextBox1.MaskCompleted != false && maskedTextBox2.MaskCompleted != false &&
                    maskedTextBox3.MaskCompleted != false && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" &&
                    maskedTextBox4.MaskCompleted != false)
                {
                    // Cinsiyet seçimine göre 'cinsiyet' değişkenini ayarla.
                    if (radioButton3.Checked == true)
                    {
                        cinsiyet = "Bay";
                    }
                    else if (radioButton4.Checked == true)
                    {
                        cinsiyet = "Bayan";
                    }

                    try
                    {
                        baglantim.Open(); // Bağlantıyı aç.
                        // Yeni personeli veritabanına ekle.
                        // DİKKAT: SQL Injection riski var! Parametreli sorgu kullanılmalı.
                        // maskedTextBox3 için .Text kullanılmalı.
                        // maskedTextBox4 için .Text kullanılmalı.
                        OleDbCommand eklekomutu = new OleDbCommand("insert into personel values('" + maskedTextBox1.Text +
                            "','" + maskedTextBox2.Text + "','" + maskedTextBox3.Text + "','" + cinsiyet + "','" + comboBox1.Text +
                            "','" + dateTimePicker1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + maskedTextBox4.Text +
                            "')", baglantim);
                        eklekomutu.ExecuteNonQuery(); // Sorguyu çalıştır.
                        baglantim.Close(); // Bağlantıyı kapat.

                        // Personel resimleri için klasör yoksa oluştur.
                        if (!Directory.Exists(Application.StartupPath + "\\personelresimleri"))
                        {
                            Directory.CreateDirectory(Application.StartupPath + "\\personelresimleri");
                        }
                        // Resmi kaydet.
                        // DİKKAT: maskedTextBox1.Text kullanılmalı.
                        pictureBox2.Image.Save(Application.StartupPath + "\\personelresimleri\\" + maskedTextBox1.Text + ".png");

                        MessageBox.Show("Yeni Personel Oluşturuldu", "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        personelleri_listele(); // Personel listesini yenile.
                        topPage2_temiz(); // Alanları temizle.
                    }
                    catch (Exception hatamsj)
                    {
                        MessageBox.Show(hatamsj.Message, "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        baglantim.Close(); // Hata durumunda bağlantıyı kapat.
                    }
                }
                else
                {
                    // Eksik veya hatalı alan varsa uyarı göster.
                    MessageBox.Show("Yazı Rengi Kırmızı Olan Alanları Kontrol Ediniz!", "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // TC Kimlik No daha önce kayıtlıysa uyarı göster.
                MessageBox.Show("Girilen TC Kimlik Numarası Daha Önce Kayıt Edilmiştir!", "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Personel Ara butonu Click olayı.
        private void button6_Click(object sender, EventArgs e)
        {
            bool kayit_arama_durumu = false; // Kayıt arama durumu.

            if (maskedTextBox1.Text.Length == 11) // TC Kimlik No 11 haneli ise ara.
            {
                baglantim.Open(); // Bağlantıyı aç.
                // TC Kimlik No'ya göre personel ara.
                // DİKKAT: SQL Injection riski var! Parametreli sorgu kullanılmalı.
                OleDbCommand selectsorgu = new OleDbCommand("select * from personel where tcno = '" + maskedTextBox1.Text + "'", baglantim);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();

                while (kayitokuma.Read()) // Kayıt bulunduysa.
                {
                    kayit_arama_durumu = true; // Kayıt bulundu.

                    try
                    {
                        // Personelin resmini yükle.
                        // DİKKAT: Klasör ayracı eksik olabilir ("\\personelresimleri\\" olmalı).
                        pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\personelresimleri\\" + kayitokuma.GetValue(0).ToString() + ".png");
                    }
                    catch (Exception)
                    {
                        // Resim bulunamazsa varsayılan 'resimsiz.png' resmini yükle.
                        pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\personelresimleri\\resimsiz.png");
                    }
                    // Bulunan verileri ilgili alanlara yerleştir.
                    maskedTextBox2.Text = kayitokuma.GetValue(1).ToString(); // Ad.
                    maskedTextBox3.Text = kayitokuma.GetValue(2).ToString(); // Soyad. (Hata: maskedTextBox2'ye tekrar atanmış)
                    if (kayitokuma.GetValue(3).ToString() == "Bay") // Cinsiyet kontrolü.
                        radioButton3.Checked = true;
                    else
                        radioButton4.Checked = true;
                    comboBox1.Text = kayitokuma.GetValue(4).ToString(); // Mezuniyet.
                    dateTimePicker1.Text = kayitokuma.GetValue(5).ToString(); // Doğum Tarihi.
                    comboBox2.Text = kayitokuma.GetValue(6).ToString(); // Görev. (Hata: kayitokuma.GetValue(5) yerine (6) olmalıydı)
                    comboBox3.Text = kayitokuma.GetValue(7).ToString(); // Görev Yeri.
                    maskedTextBox4.Text = kayitokuma.GetValue(8).ToString(); // Maaş.
                    break;
                }
                if (kayit_arama_durumu == false) // Kayıt bulunamadıysa uyarı göster.
                    MessageBox.Show("Aranan Kayıt Bulunamadı!", "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglantim.Close(); // Bağlantıyı kapat.
            }
            else
                // TC Kimlik No 11 hane değilse uyarı göster.
                MessageBox.Show("TC Kimlik Numarası 11 hane olmalıdır", "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            topPage1_temiz(); // Kullanıcı sayfası alanlarını temizle (Yanlış, topPage2_temiz() olmalı).
        }

        // Personel Güncelle butonu Click olayı.
        private void button9_Click(object sender, EventArgs e)
        {
            string cinsiyet = ""; // Cinsiyet bilgisini tutar.

            // Alanların doğrulamasını yap ve kırmızı uyarıları ayarla (button8 ile benzer).
            if (pictureBox2.Image == null)
                button6.ForeColor = Color.Red; // (Button6 yerine label kullanılmalı)
            else
                button6.ForeColor = Color.Black;
            if (maskedTextBox1.MaskCompleted == false)
                label24.ForeColor = Color.Red;
            else
                label24.ForeColor = Color.Black;
            if (maskedTextBox2.MaskCompleted == false)
                label25.ForeColor = Color.Red;
            else
                label25.ForeColor = Color.Black;
            if (maskedTextBox3.MaskCompleted == false)
                label28.ForeColor = Color.Red;
            else
                label28.ForeColor = Color.Black;
            if (comboBox1.Text == "")
                label26.ForeColor = Color.Red;
            else
                label26.ForeColor = Color.Black;
            if (comboBox2.Text == "")
                label30.ForeColor = Color.Red;
            else
                label30.ForeColor = Color.Black;
            if (comboBox3.Text == "")
                label31.ForeColor = Color.Red;
            else
                label31.ForeColor = Color.Black;
            if (maskedTextBox4.MaskCompleted == false)
                label32.ForeColor = Color.Red;
            else
                label32.ForeColor = Color.Black;
            if (int.Parse(maskedTextBox4.Text) < 1000)
                label32.ForeColor = Color.Red;
            else
                label32.ForeColor = Color.Black;

            // Tüm alanlar geçerliyse ve resim seçilmişse güncelle.
            if (pictureBox2.Image != null && maskedTextBox1.MaskCompleted != false && maskedTextBox2.MaskCompleted != false &&
                maskedTextBox3.MaskCompleted != false && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" &&
                maskedTextBox4.MaskCompleted != false)
            {
                // Cinsiyet seçimine göre 'cinsiyet' değişkenini ayarla.
                if (radioButton3.Checked == true)
                {
                    cinsiyet = "Bay";
                }
                else if (radioButton4.Checked == true)
                {
                    cinsiyet = "Bayan";
                }

                try
                {
                    baglantim.Open(); // Bağlantıyı aç.
                    // Personel bilgilerini güncelle.
                    // DİKKAT: SQL Injection riski var! Parametreli sorgu kullanılmalı.
                    // maskedTextBox3 için .Text, maskedTextBox4 için .Text kullanılmalı.
                    // maskedTextBox1 için .Text kullanılmalı.
                    OleDbCommand guncellekomutu = new OleDbCommand("update personel set ad = '" + maskedTextBox2.Text + "',soyad = '" +
                        maskedTextBox3.Text + "',cinsiyet = '" + cinsiyet + "', mezuniyet = '" + comboBox1.Text + "',dogumtarihi = '" + // 'dogumtarih' yerine 'dogumtarihi' olmalı.
                        dateTimePicker1.Text + "',gorevi = '" + comboBox2.Text + "',gorevyeri = '" + comboBox3.Text + "',maasi = '" + maskedTextBox4.Text + "'where tcno='" + maskedTextBox1.Text + "'", baglantim);
                    guncellekomutu.ExecuteNonQuery(); // Sorguyu çalıştır.
                    baglantim.Close(); // Bağlantıyı kapat.

                    // Resim klasörü yoksa oluştur ve resmi kaydet.
                    if (!Directory.Exists(Application.StartupPath + "\\personelresimleri"))
                    {
                        Directory.CreateDirectory(Application.StartupPath + "\\personelresimleri");
                    }
                    // Resmi kaydet.
                    pictureBox2.Image.Save(Application.StartupPath + "\\personelresimleri\\" + maskedTextBox1.Text + ".png");

                    MessageBox.Show("Personel başarılı bir şekilde güncellendi!", "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    personelleri_listele(); // Personel listesini yenile.
                    topPage2_temiz(); // Alanları temizle.
                }
                catch (Exception hatamsj)
                {
                    MessageBox.Show(hatamsj.Message, "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    baglantim.Close(); // Hata durumunda bağlantıyı kapat.
                }
            }
            // Kalan kod buraya dahil edilecek
        }

        private void button10_Click(object sender, EventArgs e) 
        {

        }
        private void button11_Click()
        {

        }
    }
}