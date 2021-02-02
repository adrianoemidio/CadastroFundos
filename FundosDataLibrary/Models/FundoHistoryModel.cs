using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundosDataLibrary.Models
{
    public class FundoHistoryModel
    {
        public long CNPJ { get; set; }
        public String RazaoSocial { get; set; }
        public String NomeFantasia { get; set; }
        public long CodigoDoSistema { get; set; }
        public String Gestor { get; set; }
        public String Custodiante { get; set; }
        public String Administrador { get; set; }
        public float TaxaDeAdministracao { get; set; }
        public decimal DiasParaLiquidacao { get; set; }
        public bool ResgateAutomatico { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }



    }

}