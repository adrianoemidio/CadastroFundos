using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CadastroDeFundosWebApp.Validators;
using System.Linq;
using System.Web;

namespace CadastroDeFundosWebApp.Models
{
    public class FundoModel
    {
        [Display(Name = "CPNJ")]
        [Range(10000000000000, 99999999999999)]
        [Required(ErrorMessage = "O CPNJ é obrigatório", AllowEmptyStrings = false)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###-##-####}")]
        public long CNPJ { get; set; }

        [Display(Name = "Razão Social")]
        [Required(ErrorMessage = "A Razão Social é obrigatória", AllowEmptyStrings = false)]
        [StringLength(255, MinimumLength = 1)]
        public String RazaoSocial { get; set; }

        [Display(Name = "Nome Fantasia")]
        [Required(ErrorMessage = "O Nome Fantasia é obrigatória", AllowEmptyStrings = false)]
        [StringLength(255, MinimumLength = 1)]
        public String NomeFantasia { get; set; }

        [Display(Name = "Código Do Sistema")]
        [Required(ErrorMessage = "O Código Do Sistema é obrigatório", AllowEmptyStrings = false)]
        public long CodigoDoSistema { get; set; }

        [Display(Name = "Gestor")]
        [NotEqualTo(nameof(Custodiante))]
        [Required(ErrorMessage = "O nome do Gestor é obrigatório", AllowEmptyStrings = false)]
        [StringLength(255, MinimumLength = 1)]
        public String Gestor { get; set; }

        [Display(Name = "Custodiante")]
        [Required(ErrorMessage = "O nome do Custodiante é obrigatório", AllowEmptyStrings = false)]
        [StringLength(255, MinimumLength = 1)]
        public String Custodiante { get; set; }

        [Display(Name = "Administrador")]
        [Required(ErrorMessage = "O nome do Administrador é obrigatório", AllowEmptyStrings = false)]
        [StringLength(255, MinimumLength = 1)]
        public String Administrador { get; set; }

        [Display(Name = "Taxa De Administração")]
        [Required(ErrorMessage = "A Taxa De Administração é obrigatório", AllowEmptyStrings = false)]
        public float TaxaDeAdministracao { get; set; }

        [Display(Name = "Dias Para Liquidacao")]
        [Required(ErrorMessage = "O número de Dias Para Liquidacao é obrigatório", AllowEmptyStrings = false)]
        public decimal DiasParaLiquidacao { get; set; }

        [Display(Name = "Resgate Automático")]
        [Required(ErrorMessage = "O Resgate Automático é obrigatório", AllowEmptyStrings = false)]
        public bool ResgateAutomatico { get; set; }


    }
}