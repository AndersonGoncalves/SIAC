using System.Collections.Generic;

namespace SiacWeb.Models.ViewModels
{
    public class AutonomoFormViewModel
    {
        public Autonomo Autonomo { get; set; }
        public ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();
    }
}