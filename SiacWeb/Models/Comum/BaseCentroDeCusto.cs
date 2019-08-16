using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiacWeb.Models.Comum
{
    public abstract class BaseCentroDeCusto : Base
    {
        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Centro De Custo")]
        public int CentroDeCustoId { get; set; }

        [ForeignKey("CentroDeCustoId")]
        public CentroDeCusto CentroDeCusto { get; set; }
    }
}