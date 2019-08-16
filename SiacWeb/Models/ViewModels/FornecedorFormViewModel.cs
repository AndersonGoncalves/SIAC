using System;
using System.Collections.Generic;

namespace SiacWeb.Models.ViewModels
{
    public class FornecedorFormViewModel
    {
        public Fornecedor Fornecedor { get; set; }
        public ICollection<CentroDeCusto> CentroDeCustos { get; set; } = new List<CentroDeCusto>();
    }
}