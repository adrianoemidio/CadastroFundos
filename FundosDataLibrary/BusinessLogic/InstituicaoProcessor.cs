using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundosDataLibrary.DataAccess;
using FundosDataLibrary.Models;

namespace FundosDataLibrary.BusinessLogic
{
    public static class InstituicaoProcessor
    {
        public static int Save(string nome)
        {
            string sql = @"insert into dbo.InstituicoesFinanceiras(Nome) VALUES (@Nome)";
  
            return SqlDataAccess.SaveData(sql, new { Nome = nome });
        }

        public static List<InstituicaoFinaceiraModel> Load()
        {
            string sql = @"select * from dbo.InstituicoesFinanceiras";

            return SqlDataAccess.LoadData<InstituicaoFinaceiraModel>(sql);
        }

        public static List<InstituicaoFinaceiraModel> Load(int id)
        {
            string sql = @"select * from dbo.InstituicoesFinanceiras where @Id = Id";

            return SqlDataAccess.LoadData<InstituicaoFinaceiraModel>(sql, new { Id = id });
        }

        public static int Delete(int id)
        {
            string sql = @"delete from dbo.InstituicoesFinanceiras where @Id = Id";

            return SqlDataAccess.DeleteData<InstituicaoFinaceiraModel>(sql,new { Id = id });
        }

        public static int Edit(string Nome, int Id)
        {
            var param = new Dapper.DynamicParameters();
            param.Add("@Id", Id);
            param.Add("@Nome", Nome);

            string sql = @"update dbo.InstituicoesFinanceiras 
                         set Nome = @Nome where Id = @Id";

            return SqlDataAccess.UpdateData<InstituicaoFinaceiraModel>(sql, param);

        }

    }
}
