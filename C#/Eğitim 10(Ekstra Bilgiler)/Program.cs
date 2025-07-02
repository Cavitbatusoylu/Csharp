using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekstralar
{
    class Program
    {
        static void Main(string[] args)
        {
            // goto kullanımı
            /*
            int a, b;
            TEKRAR:
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            int c = a + b;
            Console.WriteLine(c);
            Console.WriteLine("Başka bir işlem yapacak mısın = e - (Evet) / h - (Hayır)");
            string e;
            e = Console.ReadLine();
            if (e == "e")
            {
                Console.Clear();
                goto TEKRAR;
            }
            else
            {
                Console.WriteLine("Bitti");
            }
            Console.ReadLine();
            */

            // DateTime(Kodlamada Zaman) Kullanımı
            /*
            DateTime Gun  = DateTime.Now.AddDays(5);
            DateTime Ay = DateTime.Now.AddMonths(2);
            DateTime Yil = DateTime.Now.AddYears(3);
            DateTime Saat = DateTime.Now.AddHours(2);
            DateTime dakika = DateTime.Now.AddMinutes(1);
            DateTime saniye = DateTime.Now.AddSeconds(5);
            DateTime salise = DateTime.Now.AddMilliseconds(5000);

            Console.WriteLine(Gun.ToString());
            Console.WriteLine(Ay.ToString());
            Console.WriteLine(Yil.ToString());
            Console.WriteLine(Saat.ToString());
            Console.WriteLine(dakika.ToString());
            Console.WriteLine(saniye.ToString());
            Console.WriteLine(salise.ToString());
            */
        }
    }
}