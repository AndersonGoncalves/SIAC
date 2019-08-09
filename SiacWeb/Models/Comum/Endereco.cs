using Microsoft.EntityFrameworkCore;
using SiacWeb.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiacWeb.Models.Comum
{
    [Owned]
    public class Endereco
    {
        [MaxLength(10, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Tipo de Logradouro")]
        public string TipoDeLogradouro { get; set; }

        [MaxLength(150, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [MaxLength(50, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [MaxLength(2, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "UF")]
        public string UF { get; set; }

        [MaxLength(50, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [MaxLength(10, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [MaxLength(20, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }
    }
}