using System;
using SiacWeb.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiacWeb.Models
{
    public class Auditoria
    {
        [Display(Name = "Código")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Empresa")]
        public int EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        [MaxLength(256, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Usuário")]
        public string Usuario { get; set; }

        [MaxLength(256, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Máquina")]
        public string Maquina { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        public Modulo Modulo { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Operação")]
        public Operacao Operacao { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        public string Dados { get; set; }
    }
}