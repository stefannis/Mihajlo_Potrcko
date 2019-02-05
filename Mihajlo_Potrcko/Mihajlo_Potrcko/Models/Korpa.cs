using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mihajlo_Potrcko.Models
{
    public class Korpa
    {
        public Dictionary<Artikal, IncInt> SadrzajKorpe { get; set; }

        public Korpa()
        {
            SadrzajKorpe = new Dictionary<Artikal, IncInt>();
        }
    }

    public struct IncInt
    {
        public int Quantity { get; set; }


        public IncInt(int quantity)
        {
            Quantity = quantity;
        }

        public void Increment(int quantity)
        {
            Quantity += quantity;
        }

        public void Set(int quantity)
        {
            Quantity = quantity;
        }
    }
}