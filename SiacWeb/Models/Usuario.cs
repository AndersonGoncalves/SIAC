using Microsoft.AspNetCore.Identity;
using SiacWeb.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiacWeb.Models
{
    [Table("AspNetUsers")]
    public class Usuario : IdentityUser
    {
        [MaxLength(256, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string Nome { get; set; }
       
        public SimOuNao Ativo { get; set; }
    }
}