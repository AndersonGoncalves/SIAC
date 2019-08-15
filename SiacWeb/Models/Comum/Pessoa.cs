using System;
using SiacWeb.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SiacWeb.Models.Comum
{
    public abstract class Pessoa : BaseCentroDeCusto
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
        public string CNPJ { get; set; }

        [MaxLength(14, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Inscrição Estadual")]
        public string IE { get; set; }

        [MaxLength(20, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Inscrição Municipal")]
        public string IM { get; set; }

        [MaxLength(11, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string CPF { get; set; }

        [MaxLength(20, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string RG { get; set; }        

        [MaxLength(20, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string Celular { get; set; }

        [MaxLength(20, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string Whatsapp { get; set; }

        [MaxLength(20, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string Telegram { get; set; }

        [MaxLength(100, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [EmailAddress(ErrorMessage = "{0} inválido")]
        public string Email { get; set; }

        [MaxLength(100, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string Site { get; set; }

        [MaxLength(100, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string Facebook { get; set; }

        [MaxLength(100, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string Instagram { get; set; }

        [MaxLength(80, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Nome da mãe")]
        public string NomeMae { get; set; }

        [MaxLength(80, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Nome do pai")]
        public string NomePai { get; set; }

        public virtual Endereco Endereco { get; set; } = new Endereco();
    }
}