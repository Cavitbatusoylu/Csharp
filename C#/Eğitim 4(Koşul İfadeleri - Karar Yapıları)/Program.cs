using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kararYapilari
{
    class Program
    {
        static void Main(string[] args)
        {
            // if
            /*
            int a = 0;
            a = Convert.ToInt32(Console.ReadLine());
            if (a == 7)
            {
                Console.WriteLine("Girdiğiniz sayo {0}' dır. Koşulumuza uygundur.", a);
            }
            Console.WriteLine(a);
            Console.ReadLine();
            */

            // if...else
            /*
            int a = 0;
            a = Convert.ToInt32(Console.ReadLine());

            if (a % 2 == 0)
            {
                Console.WriteLine("Girdiğiniz Sayı {0}'dır. Sayı Çifttir", a);
            }
            else
            {
                Console.WriteLine("Girdiğiniz Sayı {0}'dır. Sayı Tektir.", a);
            }
            Console.ReadLine();
            */

            // else if
            /*
            string a;
            Console.WriteLine("Bir şehir adı giriniz = ");
            a = Console.ReadLine();
            if(a.ToLower() == "ankara" ||  a.ToLower() == "konya")
            {
                Console.WriteLine("Girdiğiniz şehir {0}'dir. İç Anadolu Bölgesindedir", a);
            }
            else if(a.ToLower() == "adana" || a.ToLower() == "mersin")
            {
                Console.WriteLine("Girdiğiniz şehir {0}'dir. Akdeniz Bölgesindedir.", a);
            }
            else if(a.ToLower() == "izmir" || a.ToLower() == "manisa")
            {
                Console.WriteLine("Girdiğiniz şehir {0}'dir. Ege Bölgesindedir." , a);
            }
            else if(a.ToLower() == "bursa" || a.ToLower() == "istanbul")
            {
                Console.WriteLine("Girdiğiniz şehir {0}'dir. Marmara Bölgesindedir.", a);
            }
            else if(a.ToLower() == "van" || a.ToLower() == "erzurum")
            {
                Console.WriteLine("Girdiğiniz şehir {0}'dir. Doğu Anadolu Bölgesindedir.", a);
            }
            else { Console.WriteLine("Girdiğiniz şehir {0}'dir. İç Anadolu Bölgesindedir.", a); }
            Console.ReadLine();
            */

            // if else örnek proje 1
            /*
            string kullaniciAdi;
            int sifre;
            Console.WriteLine("Lütfen Kullanıcı Adı Giriniz = ");
            kullaniciAdi = Console.ReadLine();
            Console.WriteLine("Lütfen Şifrenizi Giriniz =" );
            sifre = Convert.ToInt32( Console.ReadLine() );
            if(kullaniciAdi == "Admin" && sifre == 123456)
            {
                Console.WriteLine("Basarili bir sekilde giris yapildi");
            }
            else
            {
                Console.WriteLine("Kullanici adı ya da şifre hatalı");
            }
            Console.ReadKey();
            */

            // if else örnek proje 2
            /*
            int a, secim;
            double kare, kup, kok;
            Console.WriteLine("Bir sayı giriniz = ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("1 = Karesi, 2 = Küpü, 3 = Karekökü");
            Console.WriteLine();
            Console.WriteLine("Seçiminiz = ");
            secim = int.Parse(Console.ReadLine());
            if (secim == 1)
            {
                kare = a * a;
                Console.WriteLine("Yazmış olduğunuz sayı {0}'dir. Karesi = {1}", a, kare);
            }
            else if (secim == 2)
            {
                kup = a * a * a;
                Console.WriteLine("Yazmış olduğunuz sayı {0}'dir. Küpü = {1}", a, kup);
            }
            else if (secim == 3)
            {
                kok = Math.Sqrt(a);
                Console.WriteLine("Yazmış olduğunuz sayı {0}'dir. Karekökü = {1}", a, kok);
            }
            Console.ReadKey();
            */

            // switch case
            /*
            int sayi;
            Console.WriteLine("1 ile 7 arasında bir sayı giriniz = ");
            sayi = Convert.ToInt32(Console.ReadLine());

            switch (sayi)
            {
                case 1: Console.WriteLine("Pazartesi"); break;
                case 2: Console.WriteLine("Salı"); break;
                case 3: Console.WriteLine("Çarşamba"); break;
                case 4: Console.WriteLine("Perşembe"); break;
                case 5: Console.WriteLine("Cuma"); break;
                case 6: Console.WriteLine("Cumartesi"); break;
                case 7: Console.WriteLine("Pazar"); break;
                default: Console.WriteLine("Hatalı Giriş"); break;
            }
            Console.ReadLine();
            */

            // switch case örnek proje 1
            /*
            string mevsim;
            Console.WriteLine("Bir mevsim yazınız = ");
            mevsim = Console.ReadLine();

            switch (mevsim)
            {
                case "ilkbahar": Console.WriteLine("Mart", "Nisan", "Mayıs"); break;
                case "yaz": Console.WriteLine("Haziran", "Temmuz", "Ağustos"); break;
                case "sonbahar": Console.WriteLine("Eylül","Ekim","Kasım"); break;
                case "kış": Console.WriteLine("Aralık","Ocak","Şubat"); break;
                default: Console.WriteLine("Hatalı Giriş"); break;
            }
            Console.ReadLine();
            */

            // switch case örnek proje 2
            /*
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                case DayOfWeek.Thursday:   
                case DayOfWeek.Friday:
                    Console.WriteLine("Hafta içi çalışma var!"); break;
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    Console.WriteLine("Hafta sonu yatış!"); break;
            }
            Console.ReadLine();
            */
        }
    }
}