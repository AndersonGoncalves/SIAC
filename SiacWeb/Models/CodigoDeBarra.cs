using System;
using SiacWeb.Models.Comum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiacWeb.Models
{
    public class CodigoDeBarra : Base
    {
        [Display(Name = "Produto")]
        public int ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Código de barras")]
        public string CodigoBarras { get; set; }
    }
}