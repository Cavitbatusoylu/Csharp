using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baklavaDilimi
{
    class Program
    {
        static void Main(string[] args)
        {
            int satir;

            Console.Write("Baklava Dilimi Boyutunu Giriniz = ");
            satir = int.Parse(Console.ReadLine());

            // Üst kısım
            for (int i = 1; i <= satir; i++)
            {
                for (int j = i; j < satir; j++)     // Boşlukları yaz
                    Console.Write(" ");
                for (int k = 1; k <= (2 * i - 1); k++)  // Yıldızları yaz
                    Console.Write("*");
                Console.WriteLine(); // Satır sonu
            }

            // Alt kısım
            for (int i = satir - 1; i >= 1; i--)
            {
                for (int j = satir; j > i; j--)     // Boşlukları yaz
                    Console.Write(" ");
                for (int k = 1; k <= (2 * i - 1); k++)  // Yıldızları yaz
                    Console.Write("*");
                Console.WriteLine(); // Satır sonu
            }

            Console.ReadKey();
        }
    }
}
