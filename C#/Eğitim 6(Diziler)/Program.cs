using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diziler
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dizi (Array)
            /*
                int[] isim = new int [20]; ---> İlk yazım tipi
                int[] isim;
                int[] = new int[20] ---> İkinci yazım tipi

                int[] isim = new int[15];
                isim[3] = 30; ---> 4.Elemanı 30'dur.
                Console.WriteLine(isim[3]);

                string[] deger = {"Cavit","Batu","Soylu"};
                int[] deger = {1,2,3,-4};
                float[] deger = {1f,1.2f};

                deger[3];

                int[] deger = new int[20];

                int a = Convert.ToInt32(Console.ReadLine());
                int dizi[] = new int[a+5];
            */

            // Dizi (Array) Örnek Uygulama 1
            /*
            string[] gunler = { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar" };
            Console.WriteLine(gunler[3]);
            Console.ReadLine();
            */

            // Dizi (Array) Örnek Uygulama 2
            /*
            int[] sayi = { 15, 35, 47, 52, 983, 116 };
            double top = 0, ort = 0;

            for (int i = 0; i < sayi.Length; i++)
            {
                top += sayi[i];
            }
            ort = top/sayi.Length;
            Console.WriteLine("Ortalama = " + ort);
            Console.WriteLine("Toplamı = " + top);
            Console.ReadLine();
            */

            // Dizi (Array) Örnek Uygulama 3
            /*
            char[] alfabe = new char[26];
            int sira = 0;

            for (char i = 'a'; i <= 'z'; i++)
            {
                alfabe[sira] = i;
                Console.WriteLine(alfabe[sira]);
                sira++;
            }
            Console.ReadLine();
            */

            // Çok Boyutlu Diziler
            /*
            int[,] isim = new int [3,2];

            veya

            int[,] isim = {{1,2},{3,4},{5,6}};
            isim[0,0] ----> 1
            isim[0,1] ----> 2
            
            int[,] isim = { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            Console.WriteLine(isim[2, 0]);
            Console.ReadLine();
            */

            // Çok Boyutlu Diziler Örnek 1
            /*
            int[,] sinav = { { 20, 80 }, { 40, 70 }, { 55, 63 }, { 75, 12 }, { 57, 50 } };
            int ogrenci = 0, not = 0;
            Console.WriteLine("Hangi Ogrenci = ");
            ogrenci = Convert.ToInt32(Console.ReadLine());
            not = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(sinav[ogrenci, not]);
            Console.ReadLine();
            */

            // Çok Boyutlu Diziler Örnek 2
            /*
            string[,] arac = new string[3, 2]
            {
            { "Corsa","Astra"},
            { "Transit","Fiesta"},
            { "Megane", "Clio"}
            };
            for (int i = 0; i <= arac.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= arac.GetUpperBound(1); j++)
                {
                    Console.WriteLine(arac[i, j]);
                }
                Console.WriteLine("---------");
            }
            Console.ReadLine();
            */
        }
    }
}