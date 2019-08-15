using System.Collections.Generic;

namespace SiacWeb.Models.ViewModels
{
    public class FuncionarioFormViewModel
    {
        public Funcionario Funcionario { get; set; }
        public ICollection<CentroDeCusto> CentroDeCustos { get; set; } = new List<CentroDeCusto>();
    }
}