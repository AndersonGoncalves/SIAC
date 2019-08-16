using System.Collections.Generic;

namespace SiacWeb.Models.ViewModels
{
    public class TransportadoraFormViewModel
    {
        public Transportadora Transportadora { get; set; }
        public ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();
    }
}
