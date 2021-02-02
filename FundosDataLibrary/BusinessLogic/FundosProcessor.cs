using FundosDataLibrary.DataAccess;
using FundosDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundosDataLibrary.BusinessLogic
{
    /// <summary>
    /// Processamento dos dados dos fundos
    /// </summary>
    public static class FundosProcessor
    {
        /// <summary>
        /// Adiciona um novo fundo ao banco de dados
        /// </summary>
        /// <param name="cpnj"></param>
        /// <param name="razaoSocial"></param>
        /// <param name="nomeFantasia"></param>
        /// <param name="codigoDoSistema"></param>
        /// <param name="gestor"></param>
        /// <param name="custodiante"></param>
        /// <param name="administrador"></param>
        /// <param name="taxaDeAdministracao"></param>
        /// <param name="diasParaLiquidacao"></param>
        /// <param name="resgateAutomatico"></param>
        /// <returns>No de fundos criados </returns>
        public static int CreateFundo(
            long cpnj,
            String razaoSocial,
            String nomeFantasia,
            long codigoDoSistema,
            String gestor,
            String custodiante,
            String administrador,
            float taxaDeAdministracao,
            decimal diasParaLiquidacao,
            bool resgateAutomatico
            )
        {
            FundoModel fundo = new FundoModel
            {
                CNPJ = cpnj,
                RazaoSocial = razaoSocial,
                NomeFantasia = nomeFantasia,
                CodigoDoSistema = codigoDoSistema,
                Gestor = gestor,
                Custodiante = custodiante,
                Administrador = administrador,
                TaxaDeAdministracao = taxaDeAdministracao,
                DiasParaLiquidacao = diasParaLiquidacao,
                ResgateAutomatico = resgateAutomatico
            };

            string sql = @"insert into dbo.Fundos (CNPJ,RazaoSocial,NomeFantasia,CodigoDoSistema,Gestor,Custodiante,
                            Administrador,TaxaDeAdministracao,DiasParaLiquidacao,ResgateAutomatico)
                            values(@CNPJ,@RazaoSocial,@NomeFantasia,@CodigoDoSistema,@Gestor,@Custodiante,
                            @Administrador,@TaxaDeAdministracao,@DiasParaLiquidacao,@ResgateAutomatico)";

            return SqlDataAccess.SaveData(sql, fundo);

        }
        
        public static int UpdateFundo(
            long cnpj,
            String razaoSocial,
            String nomeFantasia,
            long codigoDoSistema,
            String gestor,
            String custodiante,
            String administrador,
            float taxaDeAdministracao,
            decimal diasParaLiquidacao,
            bool resgateAutomatico
            )
        {
  

            var param = new Dapper.DynamicParameters();
            param.Add("@CNPJ",cnpj);
            param.Add("@RazaoSocial",razaoSocial);
            param.Add("@NomeFantasia",nomeFantasia);
            param.Add("@CodigoDoSistema",codigoDoSistema);
            param.Add("@Gestor",gestor);
            param.Add("@Custodiante",custodiante);
            param.Add("@Administrador",administrador);
            param.Add("@TaxaDeAdministracao",taxaDeAdministracao);
            param.Add("@DiasParaLiquidacao",diasParaLiquidacao);
            param.Add("@ResgateAutomatico",resgateAutomatico);


            string sql = @"update dbo.Fundos set Gestor = @Gestor , Custodiante = @Custodiante,
                         Administrador = @Administrador, TaxaDeAdministracao = @TaxaDeAdministracao,
                         DiasParaLiquidacao = @DiasParaLiquidacao,ResgateAutomatico = @ResgateAutomatico
                         where CodigoDoSistema = @CodigoDoSistema";

            return SqlDataAccess.UpdateData<FundoModel>(sql,param);

        }



        /// <summary>
        /// Remove uma linha do banco de dados
        /// </summary>
        /// <param name="id"> Código da entrada a ser removida</param>
        /// <returns>Número de entradas removidas</returns>
        public static int DeleteFundo(long codigoDoSistema)
        {
            object param = new { CodigoDoSistema = codigoDoSistema };     
            
            string sql = @"delete from dbo.Fundos where @CodigoDoSistema = codigoDoSistema";

            return SqlDataAccess.DeleteData<FundoModel>(sql, param);
        }

        /// <summary>
        /// Retorna uma lista com todos os fundos presentes no banco de dados
        /// </summary>
        /// <returns>Lista com todos os fundos</returns>
        public static List<FundoModel> LoadFundos()
        {
            string sql = @"select * from dbo.Fundos";

            return SqlDataAccess.LoadData<FundoModel>(sql);
        }

        /// <summary>
        /// Retorna uma lista de todas as entradas que possuem o CPNJ dado
        /// </summary>
        /// <param name="cnpj">Nome da razão social a se buscada</param>
        /// <returns>Lista com os fundos que atendem o critério de busca</returns>
        public static List<FundoModel> LoadCNPJ(int cnpj)
        {
            object param = new { CNPJ = cnpj };

            string sql = @"select * from dbo.Fundos where @CNPJ = cnpj";

            return SqlDataAccess.LoadData<FundoModel>(sql, param);
        }

        /// <summary>
        /// Retorna uma lista de todas as entradas que possuem o Código do sistema dado
        /// </summary>
        /// <param name="codigoDoSistema">Nome da razão social a se buscada</param>
        /// <returns>Lista com os fundos que atendem o critério de busca</returns>
        public static List<FundoModel> LoadCodigoDoSistema(long codigoDoSistema)
        {
            object param = new { CodigoDoSistema = codigoDoSistema };

            string sql = @"select * from dbo.Fundos where @CodigoDoSistema = codigoDoSistema";

            return SqlDataAccess.LoadData<FundoModel>(sql, param);
        }


        /// <summary>
        /// Retorna uma lista de todas as entradas que possuem a razão social dada
        /// </summary>
        /// <param name="razaoSocial">Nome da razão social a se buscada</param>
        /// <returns>Lista com os fundos que atendem o critério de busca</returns>
        public static List<FundoModel> LoadRazaoSocial(String razaoSocial)
        {
            object param = new { RazaoSocial = razaoSocial};

            string sql = @"select * from dbo.Fundos where @RazaoSocial = razaoSocial";

            return SqlDataAccess.LoadData<FundoModel>(sql,param);
        }

        /// <summary>
        /// Retorna uma lista de todas as entradas que possuem o nome fantasia dado
        /// </summary>
        /// <param name="nomeFantasia">Nome do nome fantasia a se buscada</param>
        /// <returns>Lista com os fundos que atendem o critério de busca</returns>
        public static List<FundoModel> LoadNomeFantasia(String nomeFantasia)
        {
            object param = new { NomeFantasia = nomeFantasia };

            string sql = @"select * from dbo.Fundos where @NomeFantasia = nomeFantasia";

            return SqlDataAccess.LoadData<FundoModel>(sql, param);
        }

        /// <summary>
        /// Retorna uma lista de todas as entradas que possuem o Gestor dado
        /// </summary>
        /// <param name="gestor">Nome do Gestor a se buscada</param>
        /// <returns>Lista com os fundos que atendem o critério de busca</returns>
        public static List<FundoModel> LoadGestor(String gestor)
        {
            object param = new { Gestor = gestor };

            string sql = @"select * from dbo.Fundos where @Gestor = gestor";

            return SqlDataAccess.LoadData<FundoModel>(sql, param);
        }

        /// <summary>
        /// Retorna uma lista de todas as entradas que possuem o Custodiante dado
        /// </summary>
        /// <param name="custodiante">Nome do Custodiante a se buscada</param>
        /// <returns>Lista com os fundos que atendem o critério de busca</returns>
        public static List<FundoModel> LoadCustodiante(String custodiante)
        {
            object param = new { Custodiante = custodiante };

            string sql = @"select * from dbo.Fundos where @Custodiante = custodiante";

            return SqlDataAccess.LoadData<FundoModel>(sql, param);
        }

        /// <summary>
        /// Retorna uma lista de todas as entradas que possuem o Administrador dado
        /// </summary>
        /// <param name="administrador">Nome do Administrador a se buscada</param>
        /// <returns>Lista com os fundos que atendem o critério de busca</returns>
        public static List<FundoModel> LoadAdministrador(String administrador)
        {
            object param = new { Administrador = administrador };

            string sql = @"select * from dbo.Fundos where @Administrador = administrador";

            return SqlDataAccess.LoadData<FundoModel>(sql, param);
        }




    }
}
