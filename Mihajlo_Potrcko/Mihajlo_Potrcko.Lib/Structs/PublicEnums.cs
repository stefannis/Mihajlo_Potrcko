using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mihajlo_Potrcko.Lib.Structs
{
    public enum Kategorija
    {
        // Indeksiranje počinje od 1 da bi bilo analogno sa MYSQL funkcionalnošću
        Hrana = 1,
        Bela_tehnika = 2,
        Market = 3,
        Apoteka = 4,
        NoCategory = 5,
    }

    public static class PublicEnumMethods
    {
        #region Kategorija methods

        public static string ToString(this Kategorija @enum)
        {
            switch (@enum)
            {
                case (Kategorija.Apoteka):
                {
                    return "Apoteka";
                }
                case (Kategorija.Bela_tehnika):
                {
                    return "Bela tehnika";
                }
                case (Kategorija.Hrana):
                {
                    return "Hrana";
                }
                case (Kategorija.Market):
                {
                    return "Market";
                }
                default:
                    return "NoCategory";
            }
        }

        public static  Kategorija ToEnum(string value)
        {
            switch (value.ToLower())
            {
                case ("apoteka"):
                {
                    return Kategorija.Apoteka;
                }
                case ("bela tehnika"):
                {
                    return Kategorija.Bela_tehnika;
                }
                case ("hrana"):
                {
                    return Kategorija.Hrana;
                }
                case ("market"):
                {
                    return Kategorija.Market;
                }
                default:
                    return Kategorija.NoCategory;
            }
        }

        #endregion
    }

}
