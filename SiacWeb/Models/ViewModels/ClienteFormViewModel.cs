using System.Collections.Generic;

namespace SiacWeb.Models.ViewModels
{
    public class ClienteFormViewModel
    {
        public Cliente Cliente { get; set; }
        public ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();
    }
}
