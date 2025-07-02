using System;                         // Temel .NET sınıflarını içerir (Console gibi)
using System.Collections.Generic;     // List, Dictionary gibi koleksiyonları içerir
using System.Linq;                    // LINQ sorguları için kullanılır
using System.Text;                    // Metin işleme sınıflarını içerir (örneğin: UTF8Encoding)
using System.Threading.Tasks;         // Asenkron programlama için kullanılır

namespace ilk_giris                  // Proje/uygulama ad alanı
{
    class Program                    // Program sınıfı (ana sınıf)
    {
        static void Main(string[] args)  // Programın giriş noktası
        {
            UTF8Encoding encoding = new UTF8Encoding();  // UTF-8 kodlama sınıfı örneği (şu an kullanılmıyor)

            Console.WriteLine("CBS");   // Ekrana "CBS" yazdırır
            Console.ReadKey();          // Kullanıcının bir tuşa basmasını bekler (konsol hemen kapanmasın diye)
        }
    }
}
