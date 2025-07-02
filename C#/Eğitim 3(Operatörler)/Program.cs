using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operatorler
{
    class Program
    {
        static void Main(string[] args)
        {
            //ARİTMETİKSEL OPERATÖRLER
            // +,-,*,/,%,++,--
            /*
            //--------------------------------------------------------
            //KULLANIM
            int a, b;
            a = 13;
            b = 8;

            //TOPLAMA İŞLEMİ
            Console.WriteLine("A + B = {0}", a + b);
            //ÇIKARMA İŞLEMİ
            Console.WriteLine("A - B = {1}", a - b);
            //ÇARPMA İŞLEMİ
            Console.WriteLine("A * B = {2}", a * b);
            //BÖLME İŞLEMİ
            Console.WriteLine("A / B = {3}", a / b);
            float bolme;
            bolme = a / b;
            Console.WriteLine(bolme);
            bolme = (float)a / b;
            Console.WriteLine(bolme);

            bolme = 15 / 8f;
            Console.WriteLine(bolme);

            //KALAN SAYI
            Console.WriteLine("A / B'den Kalan = {0}", a % b);
            Console.ReadLine();
            //--------------------------------------------------------

            for (int d = 0; d < 60; d++) { 
             
                for (int s = 0; s < 60; s++) {
                    
                    for (int s1 = 0; s1 < 60; s1++) {
                        if (Console.KeyAvailable) { break; }
                        Console.WriteLine("{0}:{1}:{2}", d, s, s1); 
                        System.Threading.Thread.Sleep(10);
                        Console.Clear();
                    }
                }
            }
            */

            //KARŞILAŞTIRMA OPERATÖRLERİ
            // >, <, <=, >=, =, !=
            /*
            int b = 0, k = 0, s;
            for (int i = 1; i <= 10; i++)
            {
                Console.Write("{0}. Sayıyı Giriniz = ", i);
                s = Convert.ToInt32(Console.ReadLine());
                if (i == 1)
                {
                    b = s;
                    k = s;
                }
                if (k > s) { k = s; }
                if (b < s) { b = s; }
            }
            Console.WriteLine("En Büyük Sayı = {0}", b);
            Console.WriteLine("En Küçük Sayı = {0}", k);
            Console.ReadKey();
            */

            //MANTIKSAL OPERATÖRLER
            // && = VE, || = VEYA, ! = DEĞİL, ^ = YADA
            /*
            // && Göre:
             1.Operand      2.Operand       Sonuç
             True           True            True
             True           False           False
             False          True            False
             False          False           False
            
            // || Göre:
             1.Operand      2.Operand       Sonuç
             True           False           True
             False          True            False
            
            // ! Göre:
             1.Operand     Sonuç
             True          False
             False         True

            // ^ Göre:
             1. Operand	   2. Operand	    Sonuç
             True	       True	            False
             True	       False	        True
             False	       True	            True
             False	       False	        False

            // &&
            int a, b;
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            if (a == 3 && b == 1)
            {
                Console.WriteLine("Koşul Tamam");
            }
            else { Console.WriteLine("Sayılardan biri farklı"); }

            // ||
            int b;
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Girdiğiniz Sayı = ", b);
            if (b == 1 || b == 3)
            {
                Console.WriteLine("Tektir");
            }
            else { Console.WriteLine("1 veya 3'ten farklı bir sayı girildi"); }
            Console.ReadLine();

            // !=
            int a, b , c;
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            c = a + b;
            Console.WriteLine("İki sayının toplamı = ", c);
            if(c != 25)
            {
                Console.WriteLine("2 Sayının Toplamı 25'ten Küçüktür");
            }
            else { Console.WriteLine("2 Sayının Toplamı 25'e eşittir");}
            Console.ReadLine();

            // ^
            int a, b;
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            if ((a == 1) ^ (b == 3))
            {
                Console.WriteLine("Sadece bir koşul sağlandı");
            }
            else
            {
                Console.WriteLine("Her iki koşul aynı anda sağlandı ya da hiçbiri sağlanmadı");
            }
            Console.ReadLine();
            */
        }
    }
}