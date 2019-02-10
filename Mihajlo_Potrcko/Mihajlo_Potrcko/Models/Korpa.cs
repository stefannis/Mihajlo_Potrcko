using System;
using System.Collections.Generic;
using System.Linq;

namespace Mihajlo_Potrcko.Models
{
    public class Korpa
    {
        public List<KorpaContainer> SadrzajKorpe { get; private set; }

        public Korpa()
        {
            SadrzajKorpe = new List<KorpaContainer>();
            var db = new Potrcko();
            var rand = new Random();
            foreach (Partner partner in db.Partner)
            {
                foreach (var poslovnica in partner.Poslovnica)
                {
                    foreach (var artikalUPoslovnici in poslovnica.Artikal_U_Poslovnici)
                    {
                        var tmpArtikal =
                            db.Artikal.First(artikal => artikal.ArtikalID.Equals(artikalUPoslovnici.ArtikalID));
                        SadrzajKorpe.Add(new KorpaContainer()
                        {
                            KPartner = partner,
                            KArtikal = tmpArtikal,
                            IncInt = new IncInt(rand.Next(0, 40), decimal.Parse(tmpArtikal.Cena_artikla))

                        });

                    }
                }
            }
        }

        public void Set(Korpa value)
        {
            SadrzajKorpe = new List<KorpaContainer>();

            foreach (var dic in value.SadrzajKorpe)
            {
                SadrzajKorpe.Add(new KorpaContainer()
                {
                    KPartner = dic.KPartner,
                    KArtikal = dic.KArtikal,
                    IncInt = dic.IncInt,
                });
            }
        }
    }

    public class KorpaContainer
    {
        public Partner KPartner { get; set; }
        public Artikal KArtikal { get; set; }
        public IncInt IncInt   { get; set; }
    }

    public struct IncInt
    {
        public int Quantity { get; set; }
        public decimal Price { get; private set; }

        public IncInt(int quantity,decimal priceOfUnit)
        {
            Quantity = quantity;
            Price = quantity * priceOfUnit;
        }

        public void SetPriceOfAUnit(int priceOfAUnit)
        {
            Price =  priceOfAUnit * Quantity;
        }

        public void SetQuantity(int quantity)
        { 
            Price = (Price / Quantity) * quantity;
            Quantity = quantity;
        }
    }
}