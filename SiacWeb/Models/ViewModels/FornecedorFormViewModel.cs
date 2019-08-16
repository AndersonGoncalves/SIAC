using System;
using System.Collections.Generic;

namespace SiacWeb.Models.ViewModels
{
    public class FornecedorFormViewModel
    {
        public Fornecedor Fornecedor { get; set; }
        public ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();
    }
}