using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hataAyiklama
{
    class Program
    {
        static void Main(string[] args)
        {

            //Hata Ayıklama ve Exception Türler
            /*
                try{
                   // Herhangi bir sıkıntı yoksa işlemlerinizi çalıştırır
                }
                catch{
                   // Hata alındığı zaman çözüm önerir
                }
                finally{
                   // İki durumda da çalışır
                }

                exception : Varsayılan tiptir. İlk başlangıçta kullanılır. Tek başına kullanılabilir
                FormatException : Formata uygun veri tipi
                OverFlowException : Girilen veride taşma var mı yok mu?
                DivideByZeroException : Sıfıra bölünebilme olaylarında harekete geçer.
             */

            //Try - Catch Kullanımı
            /*
            try
            {
                int a = 5;
                int b = 2;
                int c = a / b;
                Console.WriteLine(c);
            }
            catch
            {
                Console.WriteLine("0 ile Bölme Yapılmaz!");
            }

            Console.ReadKey();
            */

            //İç İçe Catch Kullanımı
            /*
            try
            {
                int a;
                Console.WriteLine("1 Sayı Girin = ");
                a = Convert.ToInt32(Console.ReadLine());
                int b;
                Console.WriteLine("1 Sayı Girin = ");
                b = Convert.ToInt32(Console.ReadLine());
                int c = a / b;
                Console.WriteLine(c);
            }
            catch (FormatException)
            {
                Console.WriteLine("Bir tam sayı giriniz!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("int 32 için değerleri aştınız! Lütfen 11 haneden fazla girmeyin");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("0 ile bölme işlemi yapılamaz");
            }
            catch
            {
                Console.WriteLine("Hata Oluştu!");
            }
            Console.ReadLine();
            */

            //Finally Kullanımı ve Mantığı
            /*
            try
            {
                string kAdi;
                Console.WriteLine("Kullanıcı Adi Giriniz = ");
                kAdi = Console.ReadLine();
                int sifre;
                Console.WriteLine("Şifrenizi Giriniz = ");
                sifre = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Hata Oluştu");
            }
            finally
            {
                string kAdi;
                Console.WriteLine("Kullanıcı Adını Giriniz = ");
                kAdi = Console.ReadLine();
                int sifre;
                Console.WriteLine("Şifrenizi Giriniz = ");
                sifre = Convert.ToInt32(Console.ReadLine());
            }
            Console.ReadLine();
            */
        }
    }
}