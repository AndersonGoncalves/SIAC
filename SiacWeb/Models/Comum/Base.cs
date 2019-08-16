using System;
using SiacWeb.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiacWeb.Models.Comum
{
    public abstract class Base
    {
        [Display(Name = "Código")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de Alteração")]
        public DateTime? DataAlteracao { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [MaxLength(256, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Usuário")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [MaxLength(256, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Máquina")]
        public string Maquina { get; set; }

        [Display(Name = "Em Uso")]
        public SimOuNao EmUso { get; set; }

        public Base()
        {
            EmUso = SimOuNao.Nao;
            DataCadastro = DateTime.Now;
            Usuario = "TODO";
            Maquina = "TODO";
        }
    }
}