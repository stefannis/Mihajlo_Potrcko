using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace Mihajlo_Potrcko.Models
{
    public abstract class Tabela
    {
        private string ImeIDPolja;

        public string GetImePolja()
        {
            return ImeIDPolja;
        }
        protected Tabela(string Unos)
        {

            ImeIDPolja = Unos;
            var a =
                Assembly.GetCallingAssembly().GetModules().First().GetTypes();
            var db = new Potrcko();

            UzmiTabeluIzTabela<Artikal, Artikal_U_Poslovnici, Poslovnica>(db.Artikal, db.Artikal_U_Poslovnici);
        }


        public static List<T> UzmiTabeluIzTabela<K,L,T>(DbSet<K> unosTabela,DbSet<L> pomocnaTabela1) where T:Tabela where K:Tabela where L:Tabela
        {
            var a = typeof(K).GetFields().Where(field => field.Name.Equals(pomocnaTabela1.First().ImeIDPolja)).Count() > 0;


            return new List<T>();
        }
    }
}
