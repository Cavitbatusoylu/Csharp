using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace donguler
{
    class Program
    {
        static void Main(string[] args)
        {
            // FOR DÖNGÜSÜ
            /*
            for (int i = 3; i <= 70; i++)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
            */

            // FOR DÖNGÜSÜ ÖRNEK UYGULAMA 1
            /*
            int toplam = 0;
            for (int i = 1; i <= 20; i++)
            {
                if(i % 2 == 0)
                {
                    toplam += i;
                }
            }
            Console.WriteLine("Çift sayıların toplamı = " + toplam);
            Console.ReadLine();
            */

            // FOR DÖNGÜSÜ ÖRNEK UYGULAMA 2
            /*
            for (int i = 1; i <= 9; i++)
            {
                for(int j = 1; j <= 9; j++)
                {
                    Console.WriteLine("{0} * {1} = {2}", i, j, i * j);
                }
                Console.WriteLine("------------------");
            }
            Console.ReadLine();
            */

            // FOREACH DÖNGÜSÜ
            /*
            string[] gunler = { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma" };
            foreach (string haftaici in gunler)
            {
                Console.WriteLine(haftaici);
            }
            Console.ReadLine();
            */

            // FOREACH DÖNGÜSÜ ÖRNEK UYGULAMA
            /*
            int[] dizi = new int[20];
            Random rnd = new Random();
            for(int i = 0; i < dizi.Length; i++)
            {
                dizi[i] = rnd.Next(1,150);
            }
            int kucuk = dizi[0];
            int buyuk = dizi[0];

            foreach (int value in dizi)
            {
                Console.WriteLine(value);
                if(value < kucuk)
                {
                    kucuk = value;
                }
                if(value > buyuk)
                {
                    buyuk = value;
                }
                Console.WriteLine("En Büyük Değer = {0}");
                Console.WriteLine("En Küçük Değer = {0}");
                Console.ReadLine();
            */

            // WHİLE DÖNGÜSÜ
            /*
            int i = 1;
            while (i <= 10) {
                i++;
                Console.WriteLine("CBS C# KODLARI");
            }
            Console.ReadLine();
            */

            // WHİLE DÖNGÜSÜ ÖRNEK UYGULAMA 1
            /*
            int sayi;
            Console.WriteLine("Lütfen bir sayı giriniz = ");
            sayi = Convert.ToInt32(Console.ReadLine());
            while (sayi > 0)
            {
                sayi--;
                Console.WriteLine(sayi);
                System.Threading.Thread.Sleep(1000);
            }
            Console.ReadLine();
            */

            // WHİLE DÖNGÜSÜ ÖRNEK UYGULAMA 2
            /*
            int sayi = 0, toplam = 0;
            while (sayi % 2 == 0) 
            {
                toplam += sayi;
                Console.WriteLine("Bir sayı giriniz = ");
                sayi = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Şimdiye kadar girmiş olduğunuz çift sayıların toplamı = {0}", toplam);
            Console.ReadLine();
            */

            // DO-WHİLE DÖNGÜSÜ
            /*
            int deger = 0;
            do
            {
                Console.WriteLine("Verilen Sayı = {0}", deger);
                ++deger;
            }
            while (deger <= 20);
            Console.ReadLine();
            */

            // DO-WHİLE DÖNGÜSÜ ÖRNEK UYGULAMA
            /*
            int s1, s2;
            char devam, opt;

            do
            {
                Console.WriteLine("1.Sayıyı giriniz = ");
                s1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("2.Sayıyı giriniz = ");
                s2 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("İşleminizi seçin (+,-,*,/) = {0} ", s1 + s2);
                opt = Convert.ToChar(Console.ReadLine());
                switch (opt)
                {
                    case '+': Console.WriteLine("İşleminizin Sonucu = {0} ", s1 + s2); break;
                    case '-': Console.WriteLine("İşleminizin Sonucu = {0} ", s1 - s2); break;
                    case '*': Console.WriteLine("İşleminizin Sonucu = {0} ", s1 * s2); break;
                    case '/': Console.WriteLine("İşleminizin Sonucu = {0} ", s1 / s2); break;
                    default: Console.WriteLine("Hatalı Seçim"); break;
                }
                Console.WriteLine("Devam etmek için tıklayınız (E/e) = ");
                devam = Convert.ToChar(Console.ReadLine());
            } while (devam == 'E' || devam == 'e');
            Console.ReadLine();
            */
        }
    }
}