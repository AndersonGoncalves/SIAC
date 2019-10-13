using System;
using SiacWeb.Enums;
using System.ComponentModel.DataAnnotations;

namespace SiacWeb.Models.Comum
{
    public abstract class Base : Identificador
    {
        public SimOuNao Ativo { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de Alteração")]
        public DateTime? DataAlteracao { get; set; }

        [MaxLength(256, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Usuário")]
        public string Usuario { get; set; }

        [MaxLength(256, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Máquina")]
        public string Maquina { get; set; }

        [Display(Name = "Em Uso")]
        public SimOuNao EmUso { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        public Base()
        {
            Ativo = SimOuNao.Sim;
            DataCadastro = DateTime.Now;
            EmUso = SimOuNao.Nao;
            //Maquina = "0";
        }
    }
}