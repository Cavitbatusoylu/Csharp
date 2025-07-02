namespace bilgiYarismasi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = ("BİLGİ YARIŞMASI");                // Konsol başlığını ayarla
            Console.BackgroundColor = ConsoleColor.White;      // Arka plan beyaz
            Console.ForegroundColor = ConsoleColor.Red;        // Yazı rengi kırmızı
            Console.Clear();                                    // Renk değişikliklerini uygula

            Console.WriteLine("Lütfen Bilgilerinizi Giriniz = ");
            string ad, soyad;
            int puan = 0;                                       // Başlangıç puanı sıfır

            Console.WriteLine("\nLütfen Adınızı Giriniz = ");
            ad = Console.ReadLine();                            // Kullanıcı adı al

            Console.WriteLine("\nLütfen Soyadınızı Giriniz = ");
            soyad = Console.ReadLine();                         // Kullanıcı soyadı al

            Console.WriteLine($"\nSayın {ad} {soyad} yarışmamıza başlayabilirsiniz...\n");

            string cevap1;

            // 1. Soru
            Console.WriteLine("CBS Kimdir ?");
            Console.WriteLine("A - Cevdet Bartu Soyaslan  B - Cavit Batu Soylu  C - Caner Bartu Soylu  D - Caner Batu Soylu");
            cevap1 = Console.ReadLine();
            switch (cevap1.ToUpper())                            // Küçük/büyük harf duyarlılığını kaldır
            {
                case "B":
                    Console.WriteLine("Doğru Cevap!");
                    puan += 2;                                  // Doğruysa 2 puan ekle
                    break;
                default:
                    Console.WriteLine("Yanlış ya da Hatalı");
                    break;
            }

            // 2. Soru
            Console.WriteLine("\nCBS Kaç Yılında Doğmuştur ?");
            Console.WriteLine("A - 2005  B - 2006  C - 2004  D - 2003");
            cevap1 = Console.ReadLine();
            switch (cevap1.ToUpper())
            {
                case "B":
                    Console.WriteLine("Doğru Cevap!");
                    puan += 2;
                    break;
                default:
                    Console.WriteLine("Yanlış ya da Hatalı");
                    break;
            }

            // Yarışma sonu puan gösterimi
            Console.WriteLine($"\nSayın {ad} {soyad} yarışma bitmiştir.");
            Console.WriteLine($"Puanınız : {puan}");

            Console.ReadKey();
        }
    }
}
