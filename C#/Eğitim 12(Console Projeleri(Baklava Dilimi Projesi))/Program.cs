namespace hesapMakinesi
{
    class Program
    {
        static void Main(string[] args)
        {
        TEKRAR:
            int secim;
            Console.WriteLine("\n FONKSİYONEL HESAP MAKİNESİ \n");
            Console.WriteLine("**********İŞLEM MENÜSÜ**********");
            Console.WriteLine("1- Aritmatiksel\n2- Üs Alma\n3- Kök Alma\n4- Kare Alanı - Çevre\n5- Daire Alanı - Çevre\n");
            Console.WriteLine("Ne tür bir işlem yapmak istiyorsunuz = ");

            // Kullanıcıdan seçim al, sayı değilse tekrar sor
            bool secimBasarili = int.TryParse(Console.ReadLine(), out secim);
            if (!secimBasarili)
            {
                Console.WriteLine("Geçerli bir sayı giriniz!");
                goto TEKRAR;
            }
            switch (secim)
            {
                case 1:
                    double a, b;
                    Console.WriteLine("\n1. Sayıyı Giriniz = ");
                    a = Convert.ToDouble(Console.ReadLine()); // Girdiği metni double'a dönüştürür
                    Console.WriteLine("2. Sayıyı Giriniz = ");
                    b = Convert.ToDouble(Console.ReadLine()); // Girdiği metni double'a dönüştürür
                    Console.WriteLine($"\nToplam : {a + b}\nFark : {a - b}\nÇarpım : {a * b}\nBölüm : {(b != 0 ? (a / b).ToString() : "Sıfıra bölünemez")}");
                    break;
                case 2:
                    Console.WriteLine("\nSayıyı Giriniz = ");
                    double sayi = Convert.ToDouble(Console.ReadLine()); // Metni double'a dönüştürür
                    Console.WriteLine("Üssü Giriniz = ");
                    double us = Convert.ToDouble(Console.ReadLine());   // Metni double'a dönüştürür
                    double sonuc = Math.Pow(sayi, us);
                    Console.WriteLine("Cevap : {0}", sonuc);
                    break;
                case 3:
                    Console.WriteLine("\nKökü alınacak sayıyı giriniz = ");
                    double deger = Convert.ToDouble(Console.ReadLine()); // Metni double'a dönüştürür
                    if (deger < 0)
                    {
                        Console.WriteLine("Negatif sayının gerçek karekökü alınamaz.");
                    }
                    else
                    {
                        double kok = Math.Sqrt(deger);
                        Console.WriteLine("Cevap : {0}", kok);
                    }
                    break;
                case 4:
                    Console.WriteLine("\nKenar uzunluğunu giriniz = ");
                    double kenar = Convert.ToDouble(Console.ReadLine()); // Metni double'a dönüştürür
                    double alan = kenar * kenar;
                    double cevre = kenar * 4;
                    Console.WriteLine("Karenin Alanı : {0}\nKarenin Çevresi : {1}", alan, cevre);
                    break;
                case 5:
                    Console.WriteLine("\nYarıçapı Giriniz = ");
                    double yaricap = Convert.ToDouble(Console.ReadLine()); // Metni double'a dönüştürür
                    double pi = 3.14;
                    double dAlani = pi * yaricap * yaricap;
                    double dCevresi = 2 * pi * yaricap;
                    Console.WriteLine("Dairenin Alanı = {0}\nDairenin Çevresi = {1}", dAlani, dCevresi);
                    break;

                default:
                    Console.WriteLine("\nLütfen 1 ile 5 arasında bir değer seçiniz ...");
                    break;
            }
            Console.WriteLine("\nBaşka işlem yapmak ister misiniz? (Evet için 'E', çıkmak için başka bir tuş)");
            string evet = Console.ReadLine();

            if (evet.ToLower() == "e" || evet.ToLower() == "evet")
            {
                Console.Clear();
                goto TEKRAR;
            }
            else
            {
                Console.WriteLine("İyi Çalışmalar...");
            }

            Console.ReadLine();
        }
    }
}
