using System;
using SiacWeb.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SiacWeb.Models.Comum;

namespace SiacWeb.Models
{
    public class Auditoria : Identificador
    {
        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Empresa")]
        public int EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}")]
        [Display(Name = "Data/Hora")]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [MaxLength(256, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Usuário")]
        public string Usuario { get; set; }

        [MaxLength(256, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Máquina")]
        public string Maquina { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Módulo")]
        public Modulo Modulo { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "SubMódulo")]
        public SubModulo SubModulo { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Operação")]
        public Operacao Operacao { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        public string Dados { get; set; }

        public Auditoria()
        {
            DataCadastro = DateTime.Now;
            //Maquina = "0";
        }
    }
}