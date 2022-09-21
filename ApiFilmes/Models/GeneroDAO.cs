using ApiFilmes.data;
using ApiFilmes.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiGeneros.Models
{
    public class GeneroDAO
    {
        private Database db;
        public void Insert(Genero genero)
        {
            var strQuery = "";
            strQuery += "insert into tbGenero(id,genero) values";
            strQuery += string.Format("('{0}','{1}')", genero.id, genero.genero);


            using (db = new Database())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void Update(Genero genero)
        {
            var strQuery = "";
            strQuery += "update tbGenero set ";
            strQuery += string.Format("genero='{1}' WHERE id='{0}'", genero.id, genero.genero);

            using (db = new Database())
            {
                db.ExecutaComando(strQuery);
            }
        }
        public void Delete(int id)
        {
            var strQuery = "";
            strQuery += string.Format(" delete from  tbGenero where id = '{0}';", id);

            using (db = new Database())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public List<Genero> SelectTodosGeneros()
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
                string strQuery = string.Format("select * from tbGenero WHERE id = '{0}';", id);
                var leitor = db.RetornaComando(strQuery);

                return GeraListGenero(leitor).FirstOrDefault();
            }
        }

        public List<Genero> GeraListGenero(MySqlDataReader leitor)
        {
            var generos = new List<Genero>();
            var generoDAO = new GeneroDAO();

            while (leitor.Read())
            {
                var tempGenero = new Genero()
                {
                    id = int.Parse(leitor["id"].ToString()),
                    genero = leitor["genero"].ToString(),

                };
                generos.Add(tempGenero);
            }
            leitor.Close();
            return generos;
        }


    }
}