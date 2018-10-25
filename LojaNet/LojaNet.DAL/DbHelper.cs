using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace LojaNet.DAL
{
    public static class DbHelper
    {
        //String de conexão 
        public static string conexao
        {
            get
            {
                return @"Data Source=DESKTOP;Initial Catalog=LojaNetDb;Integrated Security=True";
            }
        }

        public static IDataReader ExecuteReader(string storedProcedure, params object[] paramentros)
        {

            var cn = new SqlConnection(conexao);
            var cmd = new SqlCommand(storedProcedure, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            PreencherParamentros(paramentros, cmd);
            cn.Open();
            var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);//CommandBehavior.CloseConnection responsavel pelo fechamento do banco de dados.
            return reader;


        }

        //Primeiro metodo ExecuteNonQuery - Todos providers utiliza isso
        //(string storedProcedure = Nome da Stored Procedure
        //params = Recebe um Array de object[] paramentros )
        public static int ExecuteNonQuery(string storedProcedure, params object[] paramentros)
        {

            int retorno = 0;//Vai retornar esse valor
            using (var cn = new SqlConnection(conexao))//Criando variavel de conexão
            {
                //Vai executar o storedProcedure e cn conexão
                using (var cmd = new SqlCommand(storedProcedure, cn))
                {
                    //Como é uma storeProcedure tem que falar que o CommandType é um Enumerado
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Os paramentros
                    PreencherParamentros(paramentros, cmd);

                    /*Vamos refatorar essa parte do código com o nome PreencherParamentros
                    if (paramentros.Length > 0)
                    {
                        //Vamos de  2 em 2
                        for (int i = 0; i < paramentros.Length; i+=2)
                        {
                            cmd.Parameters.AddWithValue(paramentros[i].ToString(), paramentros[i + 1]);
                        }

                    }
*/

                    cn.Open();
                    retorno = cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }

            return retorno;

        }

        private static void PreencherParamentros(object[] paramentros, SqlCommand cmd)
        {
            if (paramentros.Length > 0)
            {
                //Vamos de  2 em 2
                for (int i = 0; i < paramentros.Length; i += 2)
                {
                    cmd.Parameters.AddWithValue(paramentros[i].ToString(), paramentros[i + 1]);
                }

            }
        }
        
        //Vamos criar um método para lista com Data Reader
        //Listagem de dados

       

    }
}
