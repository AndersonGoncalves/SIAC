using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SiacWeb.Models.Comum
{
    [Owned]
    public class DadosBancarios
    {
        [MaxLength(10, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Código do Banco")]
        public string CodigoBanco { get; set; }

        [MaxLength(10, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Agência")]
        public string Agencia { get; set; }

        [MaxLength(20, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string Conta { get; set; }
    }
}
