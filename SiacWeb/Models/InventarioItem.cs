using SiacWeb.Models.Comum;
using System.ComponentModel.DataAnnotations;

namespace SiacWeb.Models
{
    public class InventarioItem : BaseCentroDeCusto
    {
        [Display(Name = "Inventário")]
        public int? InventarioId { get; set; }

        public Inventario Inventario { get; set; }

        [Display(Name = "Produto")]
        public int? ProdutoId { get; set; }

        public Produto Produto { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Quantidade no Sistema")]
        public double QuantidadeSistema { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Quantidade Informada")]
        public double QuantidadeInformada { get; set; }
    }
}