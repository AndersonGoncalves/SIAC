using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiacWeb.Models.Comum
{
    public abstract class BaseEmpresa : Identificador
    {
        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Empresa")]
        public int EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }
    }

    public abstract class BaseCentroDeCusto : Identificador
    {
        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Centro De Custo")]
        public int CentroDeCustoId { get; set; }

        [ForeignKey("CentroDeCustoId")]
        public CentroDeCusto CentroDeCusto { get; set; }
    }
}