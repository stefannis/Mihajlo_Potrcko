

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
                        "Database=mihajlo_Potrcko;Data Source=localhost;User Id=root;Password=");

                //TODO popuniti podatake za bazu podataka
                _konekcija.Open();
                SqlCommand command = _konekcija.CreateCommand();
                command.CommandText = "select * from slika";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    reader.GetString(0);
                  var a =   reader["link"].ToString();
                }

                reader.Close();
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