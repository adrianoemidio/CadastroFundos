using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadastroDeFundosWebApp.Models
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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss:fff}",ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss:fff}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }
    }
}