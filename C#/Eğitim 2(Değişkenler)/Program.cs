using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace degiskenler
{
    class Program
    {
        static void Main(string[] args)
        {
            // STRİNG
            /*
            string marka, model, yil;
            Console.WriteLine("Aracınızın Markası : ");
            marka = Console.ReadLine();
            Console.WriteLine("Aracınızın Modeli : ");
            model = Console.ReadLine();
            Console.WriteLine("Aracınız Yılı : ");
            yil = Console.ReadLine();
            Console.WriteLine("Marka : {0} Model : {1} Yıl : {2}", marka, model, yil);
            Console.Read();
            */

            // İNT
            /*
            string ad, soyad, numara;
            int yazili1, yazili2, ortalama;

            ad = "Cavit";
            soyad = "Soylu";
            numara = "1601";
            yazili1 = 80;
            yazili2 = 70;
            ortalama = (yazili1 + yazili2) / 2;

            Console.WriteLine("*************ÖĞRENCİ BİLGİSİ*************");
            Console.WriteLine("Ad = " + ad);
            Console.WriteLine("Soyad = " + soyad);
            Console.WriteLine("Numarası = " + numara);

            Console.WriteLine("*************NOT BİLGİSİ*************");
            yazili1 = 90;
            yazili2 = 15;
            ortalama = (yazili1 + yazili2) / 2;
            Console.WriteLine("Yazili 1 = " + yazili1);
            Console.WriteLine("Yazili 2 = " + yazili2);
            Console.WriteLine("Ortalama = " + ortalama);
            Console.ReadKey();
            */

            // DOUBLE
            /*
            // Kullanımı
            double a = 0.8;
            double b = 0.8D;

            double fiyat, kdv, toplam;
            Console.WriteLine("Ürünün KDV'siz fiyatını giriniz = ");
            fiyat = Convert.ToDouble(Console.ReadLine());
            kdv = fiyat * 18 / 100;
            toplam = fiyat + kdv;
            Console.WriteLine("KDV'li Fiyatı = " + toplam.ToString());
            Console.ReadKey();
            */

            // FLOAT
            /*
            // Kullanım
            float c = 25.4f;

            Console.WriteLine("Ürünün KDV'siz Fiyatını Giriniz = ");
            float kdvsiz = float.Parse(Console.ReadLine());
            var kdvli = kdvsiz + (kdvsiz * 0.18);
            Console.WriteLine("KDV'li Fiyat = " + kdvli);
            Console.ReadKey();
            */

            // DECİMAL
            /*
            Console.WriteLine(decimal.Add(5.0M, 5.3M)); //Toplama
            Console.WriteLine(decimal.Subtract(7.0M, 8.3M)); //Çıkarma
            Console.WriteLine(decimal.Multiply(9.1M, 5.8M)); //Çarpma
            Console.WriteLine(decimal.Divide(6.1M, 2.3M)); //Bölme
            Console.WriteLine(decimal.Remainder(5.1M, 5.3M)); //Kalan
            Console.WriteLine(decimal.Truncate(4.1M)); // Tam Sayi Değeri
            Console.WriteLine(decimal.Negate(5.1M)); // Pozitiften Negatife
            Console.WriteLine(decimal.Negate(-5.1M)); // Negatiften Pozitife
            */

            // CHAR
            /*
            char sayi;
            Console.WriteLine("Lütfen bir sayı giriniz: ");
            sayi = Convert.ToChar(Console.ReadLine());
            if (sayi == '1' || sayi == '3' || sayi == '5' || sayi == '7' || sayi == '9')
            {
                Console.WriteLine("Girdiğiniz sayı tektir...");
            }
            else if (sayi == '0' || sayi == '2' || sayi == '4' || sayi == '6' || sayi == '8')
            {
                Console.WriteLine("Girdiğiniz sayı çifttir...");
            }
            else
            {
                Console.WriteLine("Geçerli bir rakam girmediniz!");
            }
            Console.ReadKey();
            */

            // BOOL
            /*
            int sayi;
            Console.WriteLine("Lütfen Br Sayi Giriniz = ");
            sayi = Convert.ToInt32(Console.ReadLine());
            bool durum1 = sayi > 0;
            bool durum2 = sayi > 20;
            Console.WriteLine("Girdiğiniz sayı pozitif = " + durum1);
            Console.WriteLine("Girdiğiniz sayı negatif = " + durum2);
            Console.ReadKey();
            */

            // BYTE - SBYTE SHORT - USHORT
            /*
            Console.WriteLine("*********SINAV NET LİSTESİ*********");
            sbyte turkce, mat, fen, sos;
            turkce = -13;
            mat = 21;
            fen = 4;
            sos = 0;
            Console.WriteLine("Türkçeden 20 soru içerisinde " + turkce + " Netiniz vardır");
            Console.WriteLine("Matematikten 20 soru içerisinde " + mat + " Netiniz vardır");
            Console.WriteLine("Fen Bilimlerinden 20 soru içerisinden " + " Netiniz vardır");
            Console.WriteLine("Sosyal Bilgisinden 20 soru içerisinden " + "Netiniz vardır");
            Console.ReadLine();
            */

            // SHORT - USHORT
            /*
            ushort deger; // Short 0 ile 65.535 arasında değerler alır
            deger = 65535;
            Console.WriteLine(deger);
            Console.ReadLine();
            */
        }
    }
}
