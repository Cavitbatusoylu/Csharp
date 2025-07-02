using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eğitim_8_Sınıf_Class__.Kapsülleme_Get_Set
{
     class Program
    {
        static void Main(string[] args)
        {
            // Kapsülleme Get-Set
            /*
            get
            {
                return a;
            }
            set
            {
                a = value;
            }
            */

            Musteri mstr = new Musteri();
            mstr.AdSoyad = "Cavit Batu Soylu";
            mstr.TcNo = 12345678901;
            mstr.OdaNo = 202;

            Console.WriteLine("Ad Soyad: " + mstr.AdSoyad);
            Console.WriteLine("TC No: " + mstr.TcNo);
            Console.WriteLine("Oda No: " + mstr.OdaNo);
        }
    }
}
