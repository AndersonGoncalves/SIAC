using System;
using Microsoft.AspNetCore.Identity;
using SiacWeb.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiacWeb.Models
{
    [Table("AspNetUsers")]
    public class Usuario : IdentityUser
    {
        [MaxLength(256, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string Nome { get; set; }

        [MaxLength(256, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Sobre Nome")]
        public string SobreNome { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public SimOuNao Ativo { get; set; }
    }
}