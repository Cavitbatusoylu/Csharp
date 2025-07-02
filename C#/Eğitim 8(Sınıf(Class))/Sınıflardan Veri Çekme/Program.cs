using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classSinif
{
    class Program
    {
        static void Main(string [] args)
        {
            Manav mnv = new Manav();
            mnv.meyveAdi = "Armut";
            mnv.fiyat = 15;
            mnv.meyveListesi();
            Console.ReadKey();
        }
    }
}