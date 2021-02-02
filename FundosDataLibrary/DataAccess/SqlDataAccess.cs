using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace FundosDataLibrary.DataAccess
{
    /// <summary>
    /// Acesso de dados ao banco de dados SQL
    /// </summary>
    public static class SqlDataAccess
    {
        /// <summary>
        /// Retorna a string de conecção ao bando de dados
        /// </summary>
        /// <param name="connectionName">Nome da string de conexão dentro das configurações</param>
        /// <returns>String para coneção ao banco de dados</returns>
        public static string connectionString(string connectionName = "Fundos")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        /// <summary>
        /// Retorna uma lista T do banco de dados
        /// </summary>
        /// <typeparam name="T">Modelo do dado</typeparam>
        /// <param name="sql">String de query</param>
        /// <returns>Lista contendo o resultado da query</returns>
        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection connection = new SqlConnection(connectionString()))
            {
                return connection.Query<T>(sql).ToList();
            }

        }

        /// <summary>
        // /Retorna uma lista T do banco de dados que atende o parâmetro
        /// </summary>
        /// <typeparam name="T">Modelo do dado</typeparam>
        /// <param name="sql">String de query</param>
        /// <param name="searchParam">Parâmetro para busca</param>
        /// <returns>Lista contendo o resultado da query</returns>
        public static List<T> LoadData<T>(string sql,object searchParam)
        {
            using (IDbConnection connection = new SqlConnection(connectionString()))
            {
                return connection.Query<T>(sql,searchParam).ToList();
            }

        }

        /// <summary>
        /// Grava dado do tipo T no banco de dados
        /// </summary>
        /// <typeparam name="T">Modelo do dad</typeparam>
        /// <param name="sql">String sql para gravar</param>
        /// <param name="data">Dado a ser gravado</param>
        /// <returns>Sucesso da operação</returns>
        public static int SaveData<T>(string sql, T data) 
        {
            using (IDbConnection connection = new SqlConnection(connectionString()))
            {
                return connection.Execute(sql,data);
            }

        }

        /// <summary>
        /// Atualiza uma linha da tabela
        /// </summary>
        /// <typeparam name="T">Modelo de dados</typeparam>
        /// <param name="sql">String de update</param>
        /// <param name="updateParam">Dados atualizados</param>
        /// <returns>Número de linhas atualizadas</returns>
        public static int UpdateData<T>(string sql,object param)
        {
            using (IDbConnection connection = new SqlConnection(connectionString()))
            {
               return connection.Execute(sql,param);
               
            }

        }

        public static int DeleteData<T>(string sql,object id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString()))
            {
                int c = connection.Execute(sql, id);
                return c;
            }

        }

    }

}
