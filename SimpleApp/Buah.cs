using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp
{
    public class Buah
    {
        public string Nama { get; set; }
        public int Harga { get; set; }
        public int Stok { get; set; }

        public Buah(string Nama, int Harga, int Stok)
        {
            this.Nama = Nama;  
            this.Harga = Harga;
            this.Stok = Stok;
        }

        public void EditBuah(string newNama, int newHarga, int newStok)
        {
            this.Nama = newNama;
            this.Harga = newHarga;
            this.Stok = newStok;
        }

        public void ShowBuah()
        {
            Console.WriteLine($"| {Nama,-17}| Rp.{Harga,-5} {"/ Kg",2} {"|",4} {Stok,2} Kg|");
        }

        public void MinStok(int n)
        {
            Stok -= n;
        }
    }
}
