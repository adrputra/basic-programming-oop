using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp
{
    public class Program
    {
        public static List<Buah> daftarBuah = new List<Buah>()
        {
            new Buah("Anggur",15000,10),
            new Buah("Semangka",14000,10),
            new Buah("Jambu",4000,10),
            new Buah("Apel",7000,10),
            new Buah("Jeruk",5000,10)
        };

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("============================\nSelamat Datang di MetroFresh\n============================\n\n");
                Console.WriteLine("Pilih Menu :");
                Console.WriteLine("1. Hitung Belanja");
                Console.WriteLine("2. Lihat Katalog");
                Console.WriteLine("3. About");
                int input;
                Console.Write("Input : ");
                while (!Int32.TryParse(Console.ReadLine(), out input))
                {
                    Console.Write("Invalid input! Masukkan Input berupa angka : ");
                }
                //Console.Clear();

                switch (input)
                {
                    case 1:
                        Belanja();
                        break;
                    case 2:
                        ShowKatalog();
                        break;
                    case 3:
                        About();
                        break;
                    default:
                        break;
                }
            }
        }

        static void Belanja()
        {
            Console.Clear();
            List<string> keranjang = new List<string>();
            Console.WriteLine("==============\nHitung Belanja\n==============");
            Console.WriteLine($"| {"No.",-2}| {"Nama Buah",-17}| {"Harga /Kg",-17}| { "Stok",-5}|");
            Console.WriteLine("---------------------------------------------------");
            for (int i = 0; i < daftarBuah.Count; i++)
            {
                Console.Write($"| {i + 1,-2}.");
                daftarBuah[i].ShowBuah();
            }
            Console.WriteLine("\n\n Masukkan Nomor Buah dan Total Berat dalam Kg : (Pisahkan dengan spasi) (\"1 1\") (Input 'q' untuk selesai)");
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "q")
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    keranjang.Add(input);
                }
            }
            Console.WriteLine("==============\nStruk Belanja\n==============");
            Console.WriteLine($"|{"No.",-2}| {"Nama Buah",-17}| { "Jumlah",-5}| {"Total Harga",-10}|");
            Console.WriteLine("----------------------------------------------");
            int total = 0;
            for (int j = 0; j < keranjang.Count; j++)
            {
                string[] a = keranjang[j].Split(' ');

                int jumlahBuah = Convert.ToInt32(a[1]);
                int kodeBuah = Convert.ToInt32(a[0])-1;
                if (daftarBuah[kodeBuah].Stok < jumlahBuah)
                {
                    Console.WriteLine($"Maaf stok {daftarBuah[kodeBuah].Nama} tidak tersedia. Silakan ulangi pesanan (Press any key to continue)");
                    Console.ReadLine();
                    Belanja();
                }
                else
                {
                    daftarBuah[kodeBuah].MinStok(jumlahBuah);
                    total += daftarBuah[kodeBuah].Harga * jumlahBuah;
                    Console.WriteLine($"|{j+1,-2}.| {daftarBuah[kodeBuah].Nama,-17}| {jumlahBuah,-2} {"Kg",-3}| Rp.{jumlahBuah*daftarBuah[kodeBuah].Harga,-8}|");
                }
            }
            Console.WriteLine("\n---------------------------------------------- +");
            Console.WriteLine($"Total Price : {"Rp.",22}{total}");
            Console.ReadLine();
        }

        static void ShowKatalog()
        {
            Console.Clear();
            Console.WriteLine("==============\nStok Buah\n==============");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"|{"No.",-2}| {"Nama Buah",-17}| {"Harga /Kg",-17}| { "Stok",-5}|");
            Console.WriteLine("--------------------------------------------------");
            for (int i = 0; i < daftarBuah.Count; i++)
            {
                Console.Write($"|{i + 1,-2}.");
                daftarBuah[i].ShowBuah();
            }
            Console.WriteLine("\n\n1. Tambah\n2. Edit\n3. Delete\n4. Main Menu");
            int action = Convert.ToInt32(Console.ReadLine());

            switch (action)
            {
                case 1:
                    Tambah();
                    ShowKatalog();
                    break;

                case 2:
                    Edit();
                    ShowKatalog();
                    break;

                case 3:
                    Delete();
                    ShowKatalog();
                    break;

                default:
                    break;
            }
        }
        
        static void Tambah()
        {
            Console.WriteLine("Masukkan Nama Buah, Jumlah Stok dan Harga (Pisahkan dengan Spasi) (\"A 1 1\") : ");
            string[] add = Console.ReadLine().Split(' ');
            daftarBuah.Add(new Buah(add[0], Convert.ToInt32(add[1]), Convert.ToInt32(add[2])));
        }

        static void Edit()
        {
            Console.WriteLine("Masukkan Nomor Buah : ");
            int num = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine("Masukkan Nama Buah, Jumlah Stok dan Harga (Pisahkan dengan Spasi) (\"A 1 1\") : ");
            string[] edit = Console.ReadLine().Split(' ');
            daftarBuah[num].EditBuah(edit[0], Convert.ToInt32(edit[1]), Convert.ToInt32(edit[2]));
        }

        static void Delete()
        {
            Console.WriteLine("Masukkan Nomor Buah : ");
            int delete = Convert.ToInt32(Console.ReadLine()) - 1;
            daftarBuah.RemoveAt(delete);
        }

        static void About()
        {
            Console.Clear();
            Console.WriteLine("\nDitulis oleh Andra");
            Console.WriteLine("Metrodata Coding Camp 64");
            Console.ReadLine();
        }

       
    }
}
