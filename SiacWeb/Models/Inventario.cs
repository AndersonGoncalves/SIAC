using System;
using SiacWeb.Models.Comum;
using System.ComponentModel.DataAnnotations;

namespace SiacWeb.Models
{
    public class Inventario : BaseCentroDeCusto
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de Procesamento")]
        public DateTime? DataProcessamento { get; set; }

        [Display(Name = "Funcionário Responsável")]
        public int? FuncionarioId { get; set; }

        public Funcionario Funcionario { get; set; }
    }
}