using SiacWeb.Models.Comum;
using System.ComponentModel.DataAnnotations;

namespace SiacWeb.Models
{
    public class Funcionario : PessoaFisica
    {
        [Required(ErrorMessage = "{0} obrigatório")]
        [Range(0, 100.0, ErrorMessage = "{0} deve ser de {1} até {2}")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Comissão")]
        public double Comissao { get; set; }
    }
}