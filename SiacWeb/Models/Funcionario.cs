using SiacWeb.Models.Comum;
using System.ComponentModel.DataAnnotations;

namespace SiacWeb.Models
{
    public class Funcionario : PessoaFisica
    {
        [Display(Name = "Lotação")]
        public int? CentroDeCustoId { get; set; }

        public CentroDeCusto CentroDeCusto { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Range(0, 100.0, ErrorMessage = "{0} deve ser de {1} até {2}")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Comissão")]
        public double Comissao { get; set; }
    }
}