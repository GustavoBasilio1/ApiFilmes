using ApiFilmes.data;
using ApiGeneros.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFilmes.Models
{
    public class FilmeDAO
    {
        private Database db;
    public void Insert(Filme filme)
        {
            var strQuery = "";
            strQuery += "insert into tbFilme(imdb,titulo,ano,avaliacao,tempo,diretor,poster,FK_generoID) values";
            strQuery += string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7})", filme.imdb, filme.titulo, filme.ano, filme.avaliacao, filme.tempo, filme.diretor, filme.poster, filme.genero.id);


            using (db = new Database())
            {
                db.ExecutaComando(strQuery);
            }
        }
         
     public void Update(Filme filme)
     {
         var strQuery = "";
         strQuery += "update tbFilme set ";
         strQuery += string.Format("titulo='{1}',ano='{2}',avaliacao='{3}',tempo='{4}',diretor='{5}',poster='{6}',FK_generoID={7} WHERE imdb='{0}'", filme.imdb, filme.titulo, filme.ano, filme.avaliacao, filme.tempo, filme.diretor, filme.poster, filme.genero.id);

         using (db = new Database())
         {
             db.ExecutaComando(strQuery);
         }
     }
     public void Delete(string id)
     {
         var strQuery = "";
         strQuery += string.Format(" delete from  tbFilme where imdb = '{0}';", id);

         using (db = new Database())
         {
             db.ExecutaComando(strQuery);
         }
     }
    
        public List<Filme> SelectTodosFilmes()
        {
            using (db = new Database())
            {
                string strQuery = "select * from tbFilme;";
                var leitor = db.RetornaComando(strQuery);

                return GeraListFilme(leitor);
            }
        }

        public Filme SelectFilmePeloImdb(string imdb)
        {
            using (db = new Database())
            {
                string strQuery = string.Format("select * from tbFilme WHERE imdb = '{0}';", imdb);
                var leitor = db.RetornaComando(strQuery);

                return GeraListFilme(leitor).FirstOrDefault();
            }
        }

        public List<Filme> GeraListFilme(MySqlDataReader leitor)
        {
            var filmes = new List<Filme>();
            var generoDAO = new GeneroDAO();

            while (leitor.Read())
            {
                var tempFilme = new Filme()
                {
                    imdb = leitor["imdb"].ToString(),
                    titulo = leitor["titulo"].ToString(),
                    ano = leitor["ano"].ToString(),
                    avaliacao = leitor["avaliacao"].ToString(),
                    tempo = leitor["tempo"].ToString(),
                    diretor = leitor["diretor"].ToString(),
                    poster = leitor["poster"].ToString(),
                    genero = generoDAO.SelectGeneroPeloID(int.Parse(leitor["FK_generoID"].ToString()))

                };
                filmes.Add(tempFilme);
            }
            leitor.Close();
            return filmes;
        }

       
    }
}