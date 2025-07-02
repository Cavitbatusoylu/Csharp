using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Eğitim_8_Sınıf_Class__.Kapsülleme_Get_Set
{
    class Musteri
    {
        private string adSoyad;
        private ulong tcNo;
        private int odaNo;

        public string AdSoyad
        {
            get
            {
                return adSoyad;
            }
            set
            {
                adSoyad = value;
            }
        }

        public ulong TcNo
        {
            get
            {
                return tcNo;
            }
            set
            {
                if (value.ToString().Length == 11)
                {
                    tcNo = value;
                }
                else Console.WriteLine("Hatalı Giriş");
            }
        }

        public int OdaNo
        {
            get
            {
                return odaNo;
            }
            set 
            {
                odaNo = value; 
            }
        }
    }
}
