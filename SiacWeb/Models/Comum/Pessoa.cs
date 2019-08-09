using System;
using SiacWeb.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiacWeb.Models.Comum
{
    public abstract class Pessoa : Base
    {
        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name ="Tipo")]
        public TipoDePessoa TipoDePessoa { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [MaxLength(80, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Nome")]
        public string RazaoSocial { get; set; }

        [MaxLength(50, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Apelido")]
        public string NomeFantasia { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime? DataDeNascimento { get; set; }

        [MaxLength(14, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "CNPJ")]
        public string CNPJ { get; set; }

        [MaxLength(20, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Inscrição Estadual")]
        public string IE { get; set; }

        [MaxLength(11, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [MaxLength(20, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "RG")]
        public string RG { get; set; }        

        [MaxLength(20, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Celular")]
        public string Celular { get; set; }

        [MaxLength(20, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Whatsapp")]
        public string Whatsapp { get; set; }

        [MaxLength(20, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Telegram")]
        public string Telegram { get; set; }

        [MaxLength(100, ErrorMessage = "Tamanho máximo {1} caracteres")]        
        [EmailAddress(ErrorMessage = "{0} inválido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [MaxLength(100, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Site")]
        public string Site { get; set; }

        [MaxLength(100, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Facebook")]
        public string Facebook { get; set; }

        public virtual Endereco Endereco { get; set; } = new Endereco();
    }
}