using System;
using System.Collections.Generic;
using System.Text;

namespace FundosDataLibrary.Models
{
    public class FundoModel
    {
        public long CodigoDoSistema { get; set; }
        public long CNPJ { get; set; }
        public String RazaoSocial { get; set; }
        public String NomeFantasia { get; set; }
        public String Gestor { get; set; }
        public String Custodiante { get; set; }
        public String Administrador { get; set; }
        public float TaxaDeAdministracao { get; set; }
        public decimal DiasParaLiquidacao { get; set; }
        public bool ResgateAutomatico { get; set; }
    }
}
