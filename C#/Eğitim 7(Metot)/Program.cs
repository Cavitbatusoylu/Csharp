using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace method
{
    class Program
    {
        // Geri Değer Döndürmeyen ve Parametre Alamayan
        /*
        static void alan()
        {
            int uk, kk, sonuc;
            Console.WriteLine("Uzun kenarı giriniz = ");
            uk = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Kısa kenarı giriniz = ");
            kk = Convert.ToInt32(Console.ReadLine());
            sonuc = kk * uk;
            Console.WriteLine(sonuc);
        }

        private static void cevre()
        {
            int uk, kk, sonuc;
            Console.WriteLine("Uzun kenarı giriniz = ");
            uk = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Kısa kenarı giriniz = ");
            kk = Convert.ToInt32(Console.ReadLine());
            sonuc = 2 * (uk + kk);
            Console.WriteLine(sonuc);
        }
        */

        // Geri Değer Döndürmeyen ve Parametre Alan
        /*
        static void toplam(int a, int b)
        {
            int topla = a + b;
            Console.WriteLine("Sayıların toplamı = {0}", topla);   
        }
        */

        // Geri Değer Döndüren ve Parametre Almayan
        /*
        private static float topla()
        {
            int a, b;
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            float sonuc = a + b;
            return sonuc;
        }
        */

        // Geri Değer Döndüren ve Parametre Alan
        /*
        static int carpma(int a, int b, int c)
        {
            int sonuc = a * b * c;
            return sonuc;
        }
        */

        // Static Metot
        /*
        static void deneme()
        {
            int a = 5, b = 10;
            int top = a + b;
        }
        */

        static void Main(string[] args)
        {
            //Method tanımlama
            /*
             
             Erişim Belirleyici Dönüş Tipi Metot Adı(Parametre Liste){
                    Metot Ana Gövdesi
                }
            burası metotdan bağımsızdır.

            private, public, static
            */

            // Geri Değer Döndürmeyen ve Parametre Almayan
            /*
            Console.WriteLine("Ne hesaplamak istersiniz ? = 1 - Alan , 2 - Çevre");
            int a;
            a = Convert.ToInt32(Console.ReadLine());
            if (a == 1)
            {
                alan();
            }
            else if (a == 2)
            {
                cevre();
            }
            else 
            {
                Console.WriteLine("Hatalı Giriş");
            }
            Console.ReadLine();
            */

            // Geri Değer Döndürmeyen ve Parametre Alan
            /*
            int s1, s2;
            Console.WriteLine("1.sayıyı giriniz = ");
            s1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("2.sayıyı giriniz = ");
            s2 = Convert.ToInt32(Console.ReadLine());
            toplam(s1, s2);
            Console.ReadKey();
            */

            // Geri Değer Döndüren ve Parametre Almayan
            /*
            float son = topla();
            Console.WriteLine(son);
            Console.ReadLine();
            */

            // Geri Değer Döndüren ve Parametre Alan
            /*
            Console.WriteLine("Bir sayı giriniz = ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Bir sayı giriniz = ");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Bir sayı giriniz = ");
            int c = Convert.ToInt32(Console.ReadLine());
            int carp = carpma(a, b, c);
            Console.WriteLine(carp);
            Console.ReadLine();
            */

            // Static Metot
            /*
            deneme();
            */
        }
    }
}