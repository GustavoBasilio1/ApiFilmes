using ApiFilmes.data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFilmes.Models
{
    public class GeneroDAO
    {
        private Database db;
        public List<Genero> SelectTodosGenero()
        {
            using (db = new Database())
            {
                string strQuery = "select * from tbGenero;";
                var leitor = db.RetornaComando(strQuery);

                return GeraListGenero(leitor);
            }
        }

        public Genero SelectGeneroPeloID(int id)
        {
            using (db = new Database())
            {
                string strQuery = string.Format("select * from tbGenero WHERE id = {0};", id);
                var leitor = db.RetornaComando(strQuery);

                return GeraListGenero(leitor).FirstOrDefault();
            }
        }

        public List<Genero> GeraListGenero(MySqlDataReader leitor)
        {
            var genero = new List<Genero>();

            while (leitor.Read())
            {
                var tempGenero = new Genero()
                {
                    id = int.Parse( leitor["id"].ToString()),
                    genero = leitor["genero"].ToString()
                   

                };
                genero.Add(tempGenero);
            }
            leitor.Close();
            return genero;
        }
    }
}