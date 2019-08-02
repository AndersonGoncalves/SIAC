using SiacWeb.Models.BaseModels;
using System.ComponentModel.DataAnnotations;

namespace SiacWeb.Models
{
    public class Empresa : Base
    {
        [Required(ErrorMessage = "{0} obrigatório")]
        [MaxLength(80, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [MaxLength(50, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [MaxLength(20, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [MaxLength(8, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "CNPJ Base")]
        public string CnpjBase { get; set; }

        [MaxLength(100, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Site")]
        public string Site { get; set; }
    }
}