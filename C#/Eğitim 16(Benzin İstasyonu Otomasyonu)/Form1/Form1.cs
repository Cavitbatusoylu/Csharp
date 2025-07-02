using System;                  // Temel .NET fonksiyonları için
using System.Collections.Generic;  // Koleksiyonlar için
using System.ComponentModel;        // Bileşen modelleme için
using System.Data;                  // Veri işlemleri için
using System.Drawing;               // Grafik ve renk işlemleri için
using System.Linq;                  // LINQ sorguları için
using System.Text;                  // Metin işlemleri için
using System.Threading.Tasks;       // Çoklu iş parçacığı için
using System.Windows.Forms;         // Windows Forms uygulamaları için
using static System.Windows.Forms.VisualStyles.VisualStyleElement; // Görsel stil öğeleri için

namespace Eğitim_16_Benzin_İstasyonu_Otomasyonu_
{
    // Ana form sınıfı, akaryakıt istasyonu otomasyonunun kullanıcı arayüzü
    public partial class Form1 : Form
    {
        // Constructor - form bileşenlerini başlatır
        public Form1()
        {
            InitializeComponent();
        }

        // Akaryakıt depo miktarları (litre cinsinden)
        double D_benzin95 = 0, D_benzin97 = 0, D_dizel = 0, D_euroDizel = 0, D_lpg = 0;
        // Akaryakıt ekleme miktarları
        double E_benzin95 = 0, E_benzin97 = 0, E_dizel = 0, E_euroDizel = 0, E_lpg = 0;
        // Akaryakıt fiyatları (TL/litre)
        double F_benzin95 = 0, F_benzin97 = 0, F_dizel = 0, F_euroDizel = 0, F_lpg = 0;

        // Satış miktarları
        double S_benzin95 = 0, S_benzin97 = 0, S_dizel = 0, S_euroDizel = 0, S_lpg = 0;

        // Depo ve fiyat bilgileri dosya satırlarını tutar
        string[] depo_bilgileri;
        string[] fiyat_bilgileri;

        private void progressBar1_Click_1(object sender, EventArgs e)
        {

        }

        // Form yüklendiğinde yapılacaklar
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Akaryakıt Otomasyonu";

            // ProgressBarların maksimum kapasitesi 1000 litre
            progressBar1.Maximum = 1000;
            progressBar2.Maximum = 1000;
            progressBar3.Maximum = 1000;
            progressBar4.Maximum = 1000;
            progressBar5.Maximum = 1000;

            // Dosyalardan depo ve fiyat verilerini oku ve ara yüzde göster
            txt_depo_oku();
            txt_depo_yaz();
            txt_fiyat_oku();
            txt_fiyat_yaz();

            progressBar_durum();
            numericupdown_value();

            // Yakıt türlerini combobox'a ekle
            string[] yakit_turleri = { "Benzin (95)", "Benzin (97)", "Dizel", "Euro Dizel", "LPG" };
            comboBox1.Items.AddRange(yakit_turleri);

            // NumericUpDown kontrollerini başlangıçta pasif yap
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;

            // Ondalık hane sayısı ayarı
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown4.DecimalPlaces = 2;
            numericUpDown5.DecimalPlaces = 2;

            // NumericUpDown kontrollerini salt okunur yap
            numericUpDown1.ReadOnly = true;
            numericUpDown2.ReadOnly = true;
            numericUpDown3.ReadOnly = true;
            numericUpDown4.ReadOnly = true;
            numericUpDown5.ReadOnly = true;
        }

        // Combobox seçim değiştiğinde ilgili NumericUpDown etkinleşir
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tüm NumericUpDown kontrolleri devre dışı bırakılır
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;

            switch (comboBox1.Text)
            {
                case "Benzin (95)":
                    numericUpDown1.Enabled = true;
                    break;
                case "Benzin (97)":
                    numericUpDown2.Enabled = true;
                    break;
                case "Dizel":
                    numericUpDown3.Enabled = true;
                    break;
                case "Euro Dizel":
                    numericUpDown4.Enabled = true;
                    break;
                case "LPG":
                    numericUpDown5.Enabled = true;
                    break;
            }

            // NumericUpDown değerlerini sıfırla
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;

            label29.Text = "___"; // Satış tutarı etiketi temizlenir
        }

        // Satış işlemi butonuna basıldığında çalışır
        private void button3_Click(object sender, EventArgs e)
        {
            // Satış miktarlarını al
            S_benzin95 = Convert.ToDouble(numericUpDown1.Value);
            S_benzin97 = Convert.ToDouble(numericUpDown2.Value);
            S_dizel = Convert.ToDouble(numericUpDown3.Value);
            S_euroDizel = Convert.ToDouble(numericUpDown4.Value);
            S_lpg = Convert.ToDouble(numericUpDown5.Value);

            // Seçilen yakıt türü için stoktan düş ve fiyat hesapla
            if (numericUpDown1.Enabled && S_benzin95 > 0)
            {
                D_benzin95 -= S_benzin95;
                label29.Text = (S_benzin95 * F_benzin95).ToString("N");
            }
            else if (numericUpDown2.Enabled && S_benzin97 > 0)
            {
                D_benzin97 -= S_benzin97;
                label29.Text = (S_benzin97 * F_benzin97).ToString("N");
            }
            else if (numericUpDown3.Enabled && S_dizel > 0)
            {
                D_dizel -= S_dizel;
                label29.Text = (S_dizel * F_dizel).ToString("N");
            }
            else if (numericUpDown4.Enabled && S_euroDizel > 0)
            {
                D_euroDizel -= S_euroDizel;
                label29.Text = (S_euroDizel * F_euroDizel).ToString("N");
            }
            else if (numericUpDown5.Enabled && S_lpg > 0)
            {
                D_lpg -= S_lpg;
                label29.Text = (S_lpg * F_lpg).ToString("N");
            }

            // Güncellenen depo bilgilerini kaydet
            depo_bilgileri[0] = D_benzin95.ToString();
            depo_bilgileri[1] = D_benzin97.ToString();
            depo_bilgileri[2] = D_dizel.ToString();
            depo_bilgileri[3] = D_euroDizel.ToString();
            depo_bilgileri[4] = D_lpg.ToString();

            System.IO.File.WriteAllLines(Application.StartupPath + "\\depo.txt", depo_bilgileri);

            // Görünümü ve değerleri güncelle
            txt_depo_oku();
            txt_depo_yaz();
            progressBar_durum();
            numericupdown_value();

            // NumericUpDown değerlerini sıfırla
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
        }

        // Fiyat güncelleme butonu
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                F_benzin95 = F_benzin95 + (F_benzin95 * Convert.ToDouble(textBox1.Text) / 100);
                fiyat_bilgileri[0] = Convert.ToString(F_benzin95);
            }
            catch (Exception)
            {
                textBox1.Text = "HATA!!";
            }
            try
            {
                F_benzin97 = F_benzin97 + (F_benzin97 * Convert.ToDouble(textBox4.Text) / 100);
                fiyat_bilgileri[1] = Convert.ToString(F_benzin97);
            }
            catch (Exception)
            {
                textBox4.Text = "HATA!!";
            }
            try
            {
                F_dizel = F_dizel + (F_dizel * Convert.ToDouble(textBox5.Text) / 100);
                fiyat_bilgileri[2] = Convert.ToString(F_dizel);
            }
            catch (Exception)
            {
                textBox5.Text = "HATA!!";
            }
            try
            {
                F_euroDizel = F_euroDizel + (F_euroDizel * Convert.ToDouble(textBox6.Text) / 100);
                fiyat_bilgileri[3] = Convert.ToString(F_euroDizel);
            }
            catch (Exception)
            {
                textBox6.Text = "HATA!!";
            }
            try
            {
                F_lpg = F_lpg + (F_lpg * Convert.ToDouble(textBox7.Text) / 100);
                fiyat_bilgileri[4] = Convert.ToString(F_lpg);
            }
            catch (Exception)
            {
                textBox7.Text = "HATA!!";
            }

            // Güncellenen fiyatları dosyaya kaydet
            System.IO.File.WriteAllLines(Application.StartupPath + "\\fiyat.txt", fiyat_bilgileri);

            // Fiyat görünümünü güncelle
            txt_fiyat_oku();
            txt_fiyat_yaz();
        }

        // Depo ekleme butonu
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                E_benzin95 = Convert.ToDouble(textBox2.Text);
                if (1000 < D_benzin95 + E_benzin95 || E_benzin95 <= 0)
                    textBox2.Text = "HATA!!";
                else
                    depo_bilgileri[0] = Convert.ToString(D_benzin95 + E_benzin95);
            }
            catch (Exception)
            {
                textBox2.Text = "HATA!";
            }

            try
            {
                E_benzin97 = Convert.ToDouble(textBox9.Text);
                if (1000 < D_benzin97 + E_benzin97 || E_benzin97 <= 0)
                    textBox9.Text = "HATA!!";
                else
                    depo_bilgileri[1] = Convert.ToString(D_benzin97 + E_benzin97);
            }
            catch (Exception)
            {
                textBox9.Text = "HATA!";
            }

            try
            {
                E_dizel = Convert.ToDouble(textBox10.Text);
                if (1000 < D_dizel + E_dizel || E_dizel <= 0)
                    textBox10.Text = "HATA!!";
                else
                    depo_bilgileri[2] = Convert.ToString(D_dizel + E_dizel);
            }
            catch (Exception)
            {
                textBox10.Text = "HATA!";
            }

            try
            {
                E_euroDizel = Convert.ToDouble(textBox11.Text);
                if (1000 < D_euroDizel + E_euroDizel || E_euroDizel <= 0)
                    textBox11.Text = "HATA!!";
                else
                    depo_bilgileri[3] = Convert.ToString(D_euroDizel + E_euroDizel);
            }
            catch (Exception)
            {
                textBox11.Text = "HATA!";
            }

            try
            {
                E_lpg = Convert.ToDouble(textBox12.Text);
                if (1000 < D_lpg + E_lpg || E_lpg <= 0)
                    textBox12.Text = "HATA!!";
                else
                    depo_bilgileri[4] = Convert.ToString(D_lpg + E_lpg);
            }
            catch (Exception)
            {
                textBox12.Text = "HATA!";
            }

            // Depo bilgilerini dosyaya kaydet ve ara yüzü güncelle
            System.IO.File.WriteAllLines(Application.StartupPath + "\\depo.txt", depo_bilgileri);
            txt_depo_oku();
            txt_depo_yaz();
            progressBar_durum();
            numericupdown_value();
        }

        // Depo bilgisini dosyadan oku
        private void txt_depo_oku()
        {
            depo_bilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\depo.txt");
            D_benzin95 = Convert.ToDouble(depo_bilgileri[0]);
            D_benzin97 = Convert.ToDouble(depo_bilgileri[1]);
            D_dizel = Convert.ToDouble(depo_bilgileri[2]);
            D_euroDizel = Convert.ToDouble(depo_bilgileri[3]);
            D_lpg = Convert.ToDouble(depo_bilgileri[4]);
        }

        // Depo bilgisini ekranda göster
        private void txt_depo_yaz()
        {
            label12.Text = D_benzin95.ToString("N");
            label13.Text = D_benzin97.ToString("N");
            label14.Text = D_dizel.ToString("N");
            label15.Text = D_euroDizel.ToString("N");
            label16.Text = D_lpg.ToString("N");
        }

        // Fiyat bilgisini dosyadan oku
        private void txt_fiyat_oku()
        {
            fiyat_bilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\fiyat.txt");
            F_benzin95 = Convert.ToDouble(fiyat_bilgileri[0]);
            F_benzin97 = Convert.ToDouble(fiyat_bilgileri[1]);
            F_dizel = Convert.ToDouble(fiyat_bilgileri[2]);
            F_euroDizel = Convert.ToDouble(fiyat_bilgileri[3]);
            F_lpg = Convert.ToDouble(fiyat_bilgileri[4]);
        }

        // Fiyat bilgisini ekranda göster
        private void txt_fiyat_yaz()
        {
            label2.Text = F_benzin95.ToString("N");
            label5.Text = F_benzin97.ToString("N");
            label7.Text = F_dizel.ToString("N");
            label9.Text = F_euroDizel.ToString("N");
            label11.Text = F_lpg.ToString("N");
        }

        // ProgressBar değerlerini güncelle
        private void progressBar_durum()
        {
            progressBar1.Value = Convert.ToInt16(D_benzin95);
            progressBar2.Value = Convert.ToInt16(D_benzin97);
            progressBar3.Value = Convert.ToInt16(D_dizel);
            progressBar4.Value = Convert.ToInt16(D_euroDizel);
            progressBar5.Value = Convert.ToInt16(D_lpg);
        }

        // NumericUpDown maksimum değerlerini depo miktarlarına göre ayarla
        private void numericupdown_value()
        {
            numericUpDown1.Maximum = (decimal)D_benzin95;
            numericUpDown2.Maximum = (decimal)D_benzin97;
            numericUpDown3.Maximum = (decimal)D_dizel;
            numericUpDown4.Maximum = (decimal)D_euroDizel;
            numericUpDown5.Maximum = (decimal)D_lpg;
        }

        // Aşağıdaki event handlerlar boş, tasarım amaçlı yer tutucu:
        private void progressBar2_Click(object sender, EventArgs e) { }
        private void progressBar1_Click(object sender, EventArgs e) { }
        private void label13_Click(object sender, EventArgs e) { }
        private void textBox12_TextChanged(object sender, EventArgs e) { }
        private void label26_Click(object sender, EventArgs e) { }
    }
}
