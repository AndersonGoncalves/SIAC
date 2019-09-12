using System.Collections.Generic;

namespace SiacWeb.Models.ViewModels
{
    public class ProdutoFormViewModel
    {
        public Produto Produto { get; set; }
        public ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();
        public ICollection<Fornecedor> Fornecedores { get; set; } = new List<Fornecedor>();
        public ICollection<GrupoDeProduto> GruposDeProdutos { get; set; } = new List<GrupoDeProduto>();
        public ICollection<SubGrupoDeProduto> SubGruposDeProdutos { get; set; } = new List<SubGrupoDeProduto>();
    }
}