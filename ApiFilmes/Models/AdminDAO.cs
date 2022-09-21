using ApiFilmes.data;
using ApiFilmes.Models;
using ApiGeneros.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiAdmins.Models
{
    public class AdminDAO
    {
        private Database db;
        public void Insert(Admin admin)
        {
            var strQuery = "";
            strQuery += "insert into tbAdmin(login,senha) values";
            strQuery += string.Format("('{0}','{1}')", admin.login, admin.senha);


            using (db = new Database())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void Update(Admin admin)
        {
            var strQuery = "";
            strQuery += "update tbAdmin set ";
            strQuery += string.Format("senha='{1}' WHERE login='{0}'", admin.login, admin.senha);

            using (db = new Database())
            {
                db.ExecutaComando(strQuery);
            }
        }
        public void Delete(string id)
        {
            var strQuery = "";
            strQuery += string.Format(" delete from  tbAdmin where login = '{0}';", id);

            using (db = new Database())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public List<Admin> SelectTodosAdmins()
        {
            using (db = new Database())
            {
                string strQuery = "select * from tbAdmin;";
                var leitor = db.RetornaComando(strQuery);

                return GeraListAdmin(leitor);
            }
        }

        public Admin SelectAdminPeloImdb(string login)
        {
            using (db = new Database())
            {
                string strQuery = string.Format("select * from tbAdmin WHERE login = '{0}';", login);
                var leitor = db.RetornaComando(strQuery);

                return GeraListAdmin(leitor).FirstOrDefault();
            }
        }

        public List<Admin> GeraListAdmin(MySqlDataReader leitor)
        {
            var admins = new List<Admin>();
            var generoDAO = new GeneroDAO();

            while (leitor.Read())
            {
                var tempAdmin = new Admin()
                {
                    login = leitor["login"].ToString(),
                    senha = leitor["senha"].ToString(),

                };
                admins.Add(tempAdmin);
            }
            leitor.Close();
            return admins;
        }


    }
}
