using System.Collections.Generic;

namespace SiacWeb.Models.ViewModels
{
    public class SubGrupoDeProdutoFormViewModel
    {
        public SubGrupoDeProduto SubGrupoDeProduto { get; set; }
        public ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();
        public ICollection<GrupoDeProduto> GruposDeProdutos { get; set; } = new List<GrupoDeProduto>();
    }
}