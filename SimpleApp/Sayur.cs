using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp
{
    public class Sayur : Buah
    {
        public Sayur(string Nama, int Harga, int Stok) : base(Nama, Harga, Stok)
        {
        }

        public string Kualitas { get; set; }
    }
}
