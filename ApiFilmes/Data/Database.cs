using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiFilmes.data
{
    public class Database : IDisposable
    {
        private readonly MySqlConnection conexao;

        public Database()
        {
            conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
            conexao.Open();
        }
        public void ExecutaComando(string StrQuery)
        {
            var vComando = new MySqlCommand
            {
                CommandText = StrQuery,
                CommandType = CommandType.Text,
                Connection = conexao
            };
            vComando.ExecuteNonQuery();
        }

        public MySqlDataReader RetornaComando(string StrQuery)
        {
            var Comando = new MySqlCommand(StrQuery, conexao);

            return Comando.ExecuteReader();
        }

        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
                conexao.Close();
        }
    }
}