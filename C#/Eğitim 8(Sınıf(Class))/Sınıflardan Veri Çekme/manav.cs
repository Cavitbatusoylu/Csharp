using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classSinif
{
    class Manav
    {
        //Sınıflardan Veri Çekme
        public string meyveAdi;
        public int fiyat;

        public void meyveListesi()
        {
            Console.WriteLine("Meyve Adı = {0}", meyveAdi);
            Console.WriteLine("Meyve Fiyatı = {0}",fiyat);
        }
    }
}
