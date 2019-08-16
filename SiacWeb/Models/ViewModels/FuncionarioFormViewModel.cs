using System.Collections.Generic;

namespace SiacWeb.Models.ViewModels
{
    public class FuncionarioFormViewModel
    {
        public Funcionario Funcionario { get; set; }
        public ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();
        public ICollection<CentroDeCusto> CentrosDeCustos { get; set; } = new List<CentroDeCusto>();
    }
}