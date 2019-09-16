using System;
using SiacWeb.Models.Comum;
using System.ComponentModel.DataAnnotations;

namespace SiacWeb.Models
{
    public class CodigoDeBarra : BaseEmpresa
    {
        [Display(Name = "Produto")]
        public int? ProdutoId { get; set; }

        public Produto Produto { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Código de barras")]
        public string CodigoBarras { get; set; }
    }
}