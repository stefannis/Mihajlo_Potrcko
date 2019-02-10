using System;
using System.Collections.Generic;
using System.Linq;

namespace Mihajlo_Potrcko.Models
{
    public class Korpa
    {
        public Dictionary<int,KorpaContainer> SadrzajKorpe { get; private set; }

        private readonly object LockObject = new object();
        private int _indexCounter = 0;
        public int IndexCounter
        {
            get
            {
                lock (LockObject)
                {
                    return _indexCounter++;
                }
            }
        }

        public Korpa()
        {
            SadrzajKorpe = new Dictionary<int, KorpaContainer>();
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
                        SadrzajKorpe.Add(IndexCounter,new KorpaContainer()
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
            SadrzajKorpe =new Dictionary<int, KorpaContainer>();

            foreach (var dic in value.SadrzajKorpe)
            {
                SadrzajKorpe.Add(dic.Key,new KorpaContainer()
                {
                    KPartner = dic.Value.KPartner,
                    KArtikal = dic.Value.KArtikal,
                    IncInt = dic.Value.IncInt,
                });
            }
        }

        public void Update(int index,KorpaContainer value)
        {
            if (SadrzajKorpe.ContainsKey(index))
            {
                SadrzajKorpe.First(container => container.Key.Equals(index)).Value.Update(value);
                return;
            }
           SadrzajKorpe.Add(index,value);
        }

        public void Remove(int key)
        {
            if (SadrzajKorpe.ContainsKey(key))
            {
                SadrzajKorpe.Remove(key);
            }
        }
    }

    public class KorpaContainer
    {
        public Partner KPartner { get; set; }
        public Artikal KArtikal { get; set; }
        public IncInt IncInt   { get; set; }

        public void Update(KorpaContainer value)
        {
            KPartner = value.KPartner;
            KArtikal = value.KArtikal;
            IncInt = value.IncInt;
        }
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