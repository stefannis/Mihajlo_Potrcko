

using System;
using System.Data.SqlClient;

namespace Mihajlo_Potrcko.Connection
{
    public static class Konekcija
    {
        private static SqlConnection _konekcija;
            public static int ErrorLevel = 0;

        public static SqlConnection PKonekcija
        {
            get
            {
                if (_konekcija != null)
                {
                    return _konekcija;
                }

                ErrorLevel = 1;
                return new SqlConnection();
            }
            set
            {
                if (_konekcija == null)
                {
                    _konekcija = value;
                    _konekcija.Open();
                }
            }
        }

        // GET: Konekcija
        static Konekcija()
        {
            try
            {
                _konekcija =
                    new SqlConnection(
                        @"data source=STEFANMARKOVIC;initial catalog=Mihajlo_Potrcko;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");

                //TODO popuniti podatake za bazu podataka
                _konekcija.Open();
            }
            catch (Exception ex)
            {
                var temp = ex;
            }
        }

        public static bool Reconnect(string databaseName, string address, string username, string password)
        {
            //TODO Povezivanje na bazu opet

           
           
            return true;
        }


    }
    
    public enum TypeOfQuery
    {
        Insert = 0x00,
        Update = 0x01,
        Select = 0x02,
    }


    public static class EnumMethods
    {
        public static string GetStringFromTypeOfQuery(this TypeOfQuery query)
        {
            switch (query)
            {
                case TypeOfQuery.Insert:
                    return "Insert";
                case TypeOfQuery.Update:
                    return "Update";
                case TypeOfQuery.Select:
                    return "Select";
                default:
                    return "???";
            }
        }
    }
}