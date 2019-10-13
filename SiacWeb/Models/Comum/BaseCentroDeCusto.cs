using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiacWeb.Models.Comum
{
    public abstract class BaseCentroDeCusto : Base
    {
        /*
        [Display(Name = "Empresa")]
        public int? EmpresaId { get; set; }

        public Empresa Empresa { get; set; }
        */

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Centro de Custo")]
        public int CentroDeCustoId { get; set; }

        [ForeignKey("CentroDeCustoId")]
        public CentroDeCusto CentroDeCusto { get; set; }
    }
}