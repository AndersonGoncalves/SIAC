using System.Collections.Generic;

namespace SiacWeb.Models.ViewModels
{
    public class InventarioItensFormViewModel
    {
        public Inventario Inventario { get; set; }
        public InventarioItem InventarioItem { get; set; }
        public ICollection<InventarioItem> InventarioItens { get; set; } = new List<InventarioItem>();
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
        public CentroDeCusto CentroDeCusto { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}