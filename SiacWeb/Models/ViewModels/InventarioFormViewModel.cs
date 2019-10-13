using System.Collections.Generic;

namespace SiacWeb.Models.ViewModels
{
    public class InventarioFormViewModel
    {
        public Inventario Inventario { get; set; }
        public ICollection<InventarioItem> InventarioItens { get; set; } = new List<InventarioItem>();
        public ICollection<CentroDeCusto> CentrosDeCustos { get; set; } = new List<CentroDeCusto>();
        public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
    }
}