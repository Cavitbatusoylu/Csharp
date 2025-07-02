using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eğitim_8_Sınıf_Class__.Kalıtım_Inheritance_
{
    class Program
    {
        static void Main(string[] args)
        {
            // Kalıtım(Inheritance)
            /*
                kalıtım
                private int a;
                private int b;
                private string c;
            ---------------------
            class program : kalıtım
             */

            veri v = new veri();
            v.Boy = 180;
            v.Kilo = 75;

            Console.WriteLine("Boy: " + v.Boy);
            Console.WriteLine("Kilo: " + v.Kilo);
        }
    }
}
