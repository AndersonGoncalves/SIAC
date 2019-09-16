using System.Collections.Generic;

namespace SiacWeb.Models.ViewModels
{
    public class CodigoDeBarraFormViewModel
    {
        public CodigoDeBarra CodigoDeBarra { get; set; }
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    }
}