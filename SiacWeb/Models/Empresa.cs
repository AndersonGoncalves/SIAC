using SiacWeb.Models.Comum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SiacWeb.Models
{
    public class Empresa : Identificador
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

        [MaxLength(8, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "CNPJ Base")]
        public string CnpjBase { get; set; }

        [MaxLength(11, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string CPF { get; set; }

        [MaxLength(12, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string CEI { get; set; }

        [MaxLength(100, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string Site { get; set; }

        public ICollection<CentroDeCusto> CentroDeCustos { get; set; } = new List<CentroDeCusto>();
    }
}