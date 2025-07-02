using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb; // OleDb: Access veritabanı bağlantısı için kütüphane
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eğitim_17_Personel_Takip_Otomasyonu_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Veritabanı bağlantısı, Access dosyasına bağlanır
        OleDbConnection baglantim = new OleDbConnection("Provider = Microsoft.Ace.OleDb.16.0;Data Source = personel.accdb");

        // Formlar arasında kullanılacak kullanıcı bilgileri
        public static string tcno, adi, soyadi, yetki;

        // Giriş hakkı ve doğrulama durumu değişkenleri
        int hak = 3;          // Kullanıcının kalan giriş hakkı
        bool durum = false;   // Girişin başarılı olup olmadığını tutar

        private void button1_Click(object sender, EventArgs e)
        {
            if (hak != 0) // Hala giriş hakkı varsa
            {
                baglantim.Open(); // Veritabanı bağlantısını aç
                // Kullanıcılar tablosundaki tüm kayıtları sorgula
                OleDbCommand selectsorgu = new OleDbCommand("SELECT * FROM kullanici", baglantim);

                // Sorgu sonucunu oku
                OleDbDataReader kayitOkuma = selectsorgu.ExecuteReader();

                while (kayitOkuma.Read()) // Kayıtlar üzerinde dön
                {
                    // Yönetici seçilmişse kontrol et
                    if (radioButton1.Checked == true)
                    {
                        if (kayitOkuma["kullaniciadi"].ToString() == textBox1.Text &&
                            kayitOkuma["parola"].ToString() == textBox2.Text &&
                            kayitOkuma["yetki"].ToString() == "Yönetici")
                        {
                            durum = true; // Giriş başarılı
                            // Kullanıcı bilgilerini statik değişkenlere ata
                            tcno = kayitOkuma.GetValue(0).ToString();
                            adi = kayitOkuma.GetValue(1).ToString();
                            soyadi = kayitOkuma.GetValue(2).ToString();
                            yetki = kayitOkuma.GetValue(3).ToString();

                            this.Hide(); // Giriş formunu gizle
                            Form2 frm2 = new Form2(); // Yönetici formunu aç
                            frm2.Show();
                            break; // Döngüyü kır
                        }
                    }

                    // Kullanıcı seçilmişse kontrol et
                    if (radioButton2.Checked == true)
                    {
                        if (kayitOkuma["kullaniciadi"].ToString() == textBox1.Text &&
                            kayitOkuma["parola"].ToString() == textBox2.Text &&
                            kayitOkuma["yetki"].ToString() == "Kullanıcı")
                        {
                            durum = true; // Giriş başarılı
                            tcno = kayitOkuma.GetValue(0).ToString();
                            adi = kayitOkuma.GetValue(1).ToString();
                            soyadi = kayitOkuma.GetValue(2).ToString();
                            yetki = kayitOkuma.GetValue(3).ToString();

                            this.Hide(); // Giriş formunu gizle
                            Form3 frm3 = new Form3(); // Kullanıcı formunu aç
                            frm3.Show();
                            break; // Döngüyü kır
                        }
                    }
                }

                if (durum == false) // Eğer giriş başarısızsa
                    hak--; // Giriş hakkını azalt

                baglantim.Close(); // Bağlantıyı kapat
            }

            label5.Text = Convert.ToString(hak); // Kalan hakkı label'a yaz

            if (hak == 0) // Hakkı kalmadıysa
            {
                button1.Enabled = false; // Giriş butonunu devre dışı bırak
                MessageBox.Show("Giriş Hakkı Kalmadı!", "SKY Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Uygulamayı kapat
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Kullanıcı Girişi"; // Form başlığı
            this.AcceptButton = button1;    // Enter tuşu button1'i tetikler
            this.CancelButton = button2;    // Esc tuşu button2'yi tetikler
            label5.Text = Convert.ToString(hak); // Giriş hakkı label'ına yaz
            radioButton1.Checked = true; // Varsayılan olarak Yönetici seçili
            this.StartPosition = FormStartPosition.CenterScreen; // Form ortaya gelsin
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow; // Pencere sabit boyutlu, küçük simge
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Boş event, gerekirse kaldırılabilir
        }
    }
}
