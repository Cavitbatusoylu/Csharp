namespace yemekSiparisi
{
    class Program
    {
        static void Main(string[] args)
        {
            int secim;                          // Menüden seçilen ürün numarası
            double miktar, hesap = 0;          // miktar: sipariş adedi, hesap: toplam tutar

            // Menü başlığı ve ürünler listeleniyor
            Console.WriteLine("************************ CBS RESTAURANT MENU ************************");
            Console.WriteLine("***        YİYECEKLER        ***  ***        İÇECEKLER        ***");
            Console.WriteLine("***                          ***  ***                         ***");
            Console.WriteLine("*** 1 - Pilav = 30 TL        ***  ***  7 - Su = 10 TL         ***");
            Console.WriteLine("*** 2 - Kuru Fasulye = 40 TL ***  ***  8 - Çay = 15 TL        ***");
            Console.WriteLine("*** 3 - Adana Kebap = 150 TL ***  ***  9 - Ayran = 15 TL      ***");
            Console.WriteLine("*** 4 - Urfa Kebap = 150 TL  ***  *** 10 - Kola = 20 TL       ***");
            Console.WriteLine("*** 5 - Ezogelin = 30 TL     ***  *** 11 - Fanta = 20 TL      ***");
            Console.WriteLine("*** 6 - Kelle Paça = 50 TL   ***  *** 12 - Sprite = 20 TL     ***");

            while (true) // Sipariş döngüsü
            {
                Console.WriteLine("\nMenüden sipariş vermek istediğiniz ürünün numarasını giriniz:");

                // Kullanıcının geçerli bir sayı girip girmediğini kontrol et
                bool validInput = int.TryParse(Console.ReadLine(), out secim);
                if (!validInput)
                {
                    Console.WriteLine("Lütfen geçerli bir sayı giriniz!");
                    continue;               // Hatalı girişte başa dön
                }

                // Ürün seçimine göre fiyat hesaplama
                switch (secim)
                {
                    case 1:
                        Console.WriteLine("Kaç tabak Pilav alırsınız?");
                        miktar = Convert.ToDouble(Console.ReadLine());
                        hesap += miktar * 30;   // Pilav fiyatı 30 TL
                        break;
                    case 2:
                        Console.WriteLine("Kaç tabak Kuru Fasulye alırsınız?");
                        miktar = Convert.ToDouble(Console.ReadLine());
                        hesap += miktar * 40;   // Kuru Fasulye fiyatı 40 TL
                        break;
                    case 3:
                        Console.WriteLine("Kaç porsiyon Adana Kebap alırsınız?");
                        miktar = Convert.ToDouble(Console.ReadLine());
                        hesap += miktar * 150;  // Adana Kebap fiyatı 150 TL
                        break;
                    case 4:
                        Console.WriteLine("Kaç porsiyon Urfa Kebap alırsınız?");
                        miktar = Convert.ToDouble(Console.ReadLine());
                        hesap += miktar * 150;  // Urfa Kebap fiyatı 150 TL
                        break;
                    case 5:
                        Console.WriteLine("Kaç porsiyon Ezogelin alırsınız?");
                        miktar = Convert.ToDouble(Console.ReadLine());
                        hesap += miktar * 30;   // Ezogelin fiyatı 30 TL
                        break;
                    case 6:
                        Console.WriteLine("Kaç porsiyon Kelle Paça alırsınız?");
                        miktar = Convert.ToDouble(Console.ReadLine());
                        hesap += miktar * 50;   // Kelle Paça fiyatı 50 TL
                        break;
                    case 7:
                        Console.WriteLine("Kaç adet Su alırsınız?");
                        miktar = Convert.ToDouble(Console.ReadLine());
                        hesap += miktar * 10;   // Su fiyatı 10 TL
                        break;
                    case 8:
                        Console.WriteLine("Kaç adet Çay alırsınız?");
                        miktar = Convert.ToDouble(Console.ReadLine());
                        hesap += miktar * 15;   // Çay fiyatı 15 TL
                        break;
                    case 9:
                        Console.WriteLine("Kaç adet Ayran alırsınız?");
                        miktar = Convert.ToDouble(Console.ReadLine());
                        hesap += miktar * 15;   // Ayran fiyatı 15 TL
                        break;
                    case 10:
                        Console.WriteLine("Kaç adet Kola alırsınız?");
                        miktar = Convert.ToDouble(Console.ReadLine());
                        hesap += miktar * 20;   // Kola fiyatı 20 TL
                        break;
                    case 11:
                        Console.WriteLine("Kaç adet Fanta alırsınız?");
                        miktar = Convert.ToDouble(Console.ReadLine());
                        hesap += miktar * 20;   // Fanta fiyatı 20 TL
                        break;
                    case 12:
                        Console.WriteLine("Kaç adet Sprite alırsınız?");
                        miktar = Convert.ToDouble(Console.ReadLine());
                        hesap += miktar * 20;   // Sprite fiyatı 20 TL
                        break;
                    default:
                        Console.WriteLine("Lütfen menüdeki geçerli bir numarayı seçiniz!");
                        break;
                }

                Console.WriteLine("Başka bir arzunuz var mı? (Evet / Hayır)");
                string cevap = Console.ReadLine().ToLower();

                if (cevap == "h" || cevap == "hayır")
                    break;                  // Kullanıcı hayır dediğinde döngüden çık
            }

            Console.WriteLine($"\nToplam ödenmesi gereken tutar: {hesap} TL");
            Console.ReadLine();
        }
    }
}