using MySql.Data.MySqlClient;

namespace Mihajlo_Potrcko.Connection
{
    public static class Konekcija
    {
        private static MySqlConnection _konekcija;
        public static int ErrorLevel = 0;

        public static MySqlConnection PKonekcija
        {
            get
            {
                if (_konekcija != null)
                {
                    return _konekcija;
                }

                ErrorLevel = 1;
                return new MySqlConnection();
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
            _konekcija =
                new MySqlConnection(
                    "Database=database_name;Data Source=server_domain_or_ip;User Id=mysql_user;Password=mysql_password");
            //TODO popuniti podatake za bazu podataka

//            MySqlCommand command = connection.CreateCommand();
//            command.CommandText = "select * from mytable";
//            MySqlDataReader reader = command.ExecuteReader();
//            while (reader.Read())
//            {
//                //reader.GetString(0)
//                //reader["column_name"].ToString()
//            }
//            reader.Close();
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