using System;
using System.Collections.Generic;
using System.Linq;

namespace Mihajlo_Potrcko.Models
{
    public class Korpa
    {
        public List<KorpaItem> SadrzajKorpe { get; private set; }

        private int _indexCounter;
        public int IndexCounter => _indexCounter++;

        public Korpa()
        {
            SadrzajKorpe = new List<KorpaItem>();
            var db = new Potrcko();
            var rand = new Random();
            foreach (var partner in db.Partner)
            {
                foreach (var poslovnica in partner.Poslovnica)
                {
                    foreach (var artikalUPoslovnici in poslovnica.Artikal_U_Poslovnici)
                    {
                        var tmpArtikal =
                            db.Artikal.First(artikal => artikal.ArtikalID.Equals(artikalUPoslovnici.ArtikalID));
                        SadrzajKorpe.Add(new KorpaItem(IndexCounter,new KorpaContainer()
                        {
                            KPartner = partner,
                            KArtikal = tmpArtikal,
                            IncInt = new IncInt(rand.Next(0, 40), decimal.Parse(tmpArtikal.Cena_artikla))

                        }));

                    }
                }
            }
        }

        public void Remove(int index)
        {
          if(SadrzajKorpe.First(item => item.Key.Equals(index)) != null)
          {
              SadrzajKorpe.Remove(SadrzajKorpe.First(item => item.Key.Equals(index)));
          }
        }

        public void Set(Korpa value)
        {
            SadrzajKorpe =new List<KorpaItem>();

            foreach (var dic in value.SadrzajKorpe)
            {
                SadrzajKorpe.Add(new KorpaItem(dic.Key,new KorpaContainer()
                {
                    KPartner = dic.Value.KPartner,
                    KArtikal = dic.Value.KArtikal,
                    IncInt = dic.Value.IncInt,
                }));
            }
        }

        public void Update(int index,KorpaContainer value)
        {
            if (SadrzajKorpe.Any(item => item.Key.Equals(index)))
            {
                SadrzajKorpe.First(container => container.Key.Equals(index)).Value.Update(value);
                return;
            }
           SadrzajKorpe.Add(new KorpaItem(index,value));
        }
    }

    public class KorpaItem
    {
        public KorpaItem()
        {
            Key = 0;
            Value = new KorpaContainer();
        }

        public KorpaItem(int indexCounter, KorpaContainer korpaContainer)
        {
            Key = indexCounter;
            Value = korpaContainer;
        }

        public int Key { get; set; }
        public KorpaContainer Value { get; set; }
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

    public class IncInt
    {
        public int Quantity { get; set; }
        public decimal Price { get; private set; }

        public IncInt()
        {
            Quantity = 0;
            Price = 0;
        }

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