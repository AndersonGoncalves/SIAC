using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SiacWeb.Models.Comum
{
    [Owned]
    public class Endereco
    {
        [MaxLength(10, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Tipo de Logradouro")]
        public string TipoDeLogradouro { get; set; }

        [MaxLength(150, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string Logradouro { get; set; }

        [MaxLength(50, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string Bairro { get; set; }

        [MaxLength(2, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string UF { get; set; }

        [MaxLength(50, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string Cidade { get; set; }

        [MaxLength(10, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string CEP { get; set; }

        [MaxLength(20, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Telefone Fixo")]
        public string Telefone { get; set; }
    }
}