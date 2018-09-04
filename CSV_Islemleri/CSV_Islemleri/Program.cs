using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Islemleri
{
    class Program
    {
        static void Main(string[] args)
        {
            CSVOluşturma();
            CSVOkuma();
        }

        private static void CSVOluşturma()
        {

            List<Kullanici> Kullanicilar = new List<Kullanici>();

            Kullanici k1 = new Kullanici();
            k1.ID = Guid.NewGuid();
            k1.Isim = "Salih";
            k1.Soyisim = "SEKER";
            k1.Numara = 1;
            k1.Github = "github.com/salihseker";

            Kullanicilar.Add(k1);

            Kullanici k2 = new Kullanici();
            k2.ID = Guid.NewGuid();
            k2.Isim = "Kerami";
            k2.Soyisim = "Ozsoy";
            k2.Numara = 2;
            k2.Github = "github.com/keramiozsoy";

            Kullanicilar.Add(k2);

            for (int i = 0; i < 10; i++)
            {
                Kullanicilar.Add(k1);
                Kullanicilar.Add(k2);
            }

            // Yazma işlemi.
            StreamWriter SW = new StreamWriter(@"D:\Kullanicilar.csv");
            CsvHelper.CsvWriter Write = new CsvHelper.CsvWriter(SW);
            Write.WriteHeader(typeof(Kullanici));
            foreach (Kullanici item in Kullanicilar)
            {
                Write.WriteRecord(item);
            }
            SW.Close();

        }

        private static void CSVOkuma()
        {


            // Okuma İşlemi 
            StreamReader SR = new StreamReader(@"D:\Kullanicilar.csv");
            CsvHelper.CsvReader Reader = new CsvHelper.CsvReader(SR);
            List<Kullanici> OkunanData = Reader.GetRecords<Kullanici>().ToList();

            Console.WriteLine("Okuma işlemi tamamlandı");
            SR.Close();

            Console.WriteLine("CSV olarak kayıt işlemi tamamlanmıştır.");
            Console.WriteLine($"Toplam Adet : {OkunanData.Count}");

            foreach (var item in OkunanData)
            {
                Console.WriteLine("ID : " + item.ID);
                Console.WriteLine("Isim : " + item.Isim);
                Console.WriteLine("Soyisim : " + item.Soyisim);
                Console.WriteLine("Numara : " + item.Numara);
                Console.WriteLine("Github : " + item.Github);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
