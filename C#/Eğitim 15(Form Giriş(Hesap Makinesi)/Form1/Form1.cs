using System;
using System.Globalization;
using System.Windows.Forms;

namespace Eğitim_15_Form_Giriş_Hesap_Makinesi_
{
    public partial class Form1 : Form
    {
        bool opertDrm = false;             // Operatör butonuna basılıp basılmadığı durumu
        double sonuc = 0;                  // İşlem sonucu tutan değişken
        string opert = "";                 // Şu an seçili operatör

        public Form1()
        {
            InitializeComponent();         // Form bileşenlerini başlatır
        }

        // Rakam butonları (0-9) için ortak event
        private void rakamOlay(object sender, EventArgs e)
        {
            if (txtSonuc.Text == "0" || opertDrm) // Başlangıçta veya operatör sonrası textbox temizlenir
                txtSonuc.Clear();

            opertDrm = false;               // Yeni sayı girildiği için operatör durumu sıfırlanır
            Button btn = (Button)sender;    // Buton objesini alır
            txtSonuc.Text += btn.Text;      // Buton üzerindeki rakamı textbox'a ekler
        }

        // Operatör butonları (+, -, *, /) event'i
        private void islemOlay(object sender, EventArgs e)
        {
            opertDrm = true;                // Operatör basıldı işareti
            Button btn = (Button)sender;
            opert = btn.Text;               // Butondaki operatörü al

            double sayi;
            // Textbox içeriğini double'a çevir, başarılıysa devam et
            if (double.TryParse(txtSonuc.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out sayi))
            {
                if (sonuc == 0 && LabSonuc.Text == "") // İlk işlemse sonucu ayarla
                {
                    sonuc = sayi;
                }
                else // Önceki sonuç ile seçili operatörü uygula
                {
                    switch (opert)
                    {
                        case "+": sonuc += sayi; break;
                        case "-": sonuc -= sayi; break;
                        case "*": sonuc *= sayi; break;
                        case "/": sonuc /= sayi; break;
                    }
                }
            }

            // İşlem geçmişini göster
            LabSonuc.Text = LabSonuc.Text + " " + txtSonuc.Text + " " + opert;
            // Sonucu textbox'a yaz
            txtSonuc.Text = sonuc.ToString(CultureInfo.CurrentCulture);
        }

        // CE (Clear Entry) sadece mevcut giriş alanını temizler
        private void CE(object sender, EventArgs e)
        {
            txtSonuc.Text = "0";
        }

        // C (Clear) tüm işlemi sıfırlar, ekranı ve değişkenleri temizler
        private void C(object sender, EventArgs e)
        {
            LabSonuc.Text = "";
            txtSonuc.Text = "0";
            opert = "";
            sonuc = 0;
            opertDrm = false;
        }

        // = (eşittir) butonu, hesaplama yapar ve sonucu gösterir
        private void esit_Click(object sender, EventArgs e)
        {
            double sayi;
            if (double.TryParse(txtSonuc.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out sayi))
            {
                switch (opert)
                {
                    case "+": sonuc += sayi; break;
                    case "-": sonuc -= sayi; break;
                    case "*": sonuc *= sayi; break;
                    case "/": sonuc /= sayi; break;
                    default: sonuc = sayi; break; // operatör yoksa sonucu sayıya eşitle
                }

                txtSonuc.Text = sonuc.ToString(CultureInfo.CurrentCulture); // Sonucu göster
                LabSonuc.Text = "";      // İşlem geçmişini temizle
                opert = "";             // Operatörü sıfırla
                opertDrm = true;        // Operatör basılmış gibi işaretle (yeni giriş için)
            }
        }

        // Virgül (nokta) butonu işlemi - ondalık sayı için
        private void nokta(object sender, EventArgs e)
        {
            if (opertDrm)
            {
                txtSonuc.Text = "0";   // Yeni sayı girişi için sıfırla
                opertDrm = false;      // operatör durumu kaldır
            }

            if (!txtSonuc.Text.Contains(",")) // Eğer zaten virgül yoksa ekle
                txtSonuc.Text += ",";
        }
    }
}
