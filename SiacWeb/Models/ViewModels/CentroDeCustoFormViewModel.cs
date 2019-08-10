using System.Collections.Generic;

namespace SiacWeb.Models.ViewModels
{
    public class CentroDeCustoFormViewModel
    {
        public CentroDeCusto CentroDeCusto { get; set; }
        public ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();
    }
}