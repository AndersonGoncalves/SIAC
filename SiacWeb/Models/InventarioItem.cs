using SiacWeb.Models.Comum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiacWeb.Models
{
    public class InventarioItem : Base
    {
        [Display(Name = "Inventário")]
        public int InventarioId { get; set; }

        [ForeignKey("InventarioId")]
        public Inventario Inventario { get; set; }

        [Display(Name = "Produto")]
        public int? ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Quantidade no Sistema")]
        public double QuantidadeSistema { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Quantidade")]
        public double QuantidadeInformada { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Preço de Compra")]
        public double PrecoCompra { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Preço de Custo")]
        public double PrecoCusto { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Preço de Venda")]
        public double PrecoVenda { get; set; }
    }
}