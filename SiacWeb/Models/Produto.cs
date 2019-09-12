using System;
using SiacWeb.Models.Comum;
using System.ComponentModel.DataAnnotations;

namespace SiacWeb.Models
{
    public class Produto : BaseEmpresa
    {
        [Display(Name = "Fornecedor")]
        public int? FornecedorId { get; set; }

        public Fornecedor Fornecedor { get; set; }

        [Display(Name = "Grupo de Produto")]
        public int? GrupoDeProdutoId { get; set; }

        [Display(Name = "Grupo de Produto")]
        public GrupoDeProduto GrupoDeProduto { get; set; }

        [Display(Name = "SubGrupo de Produto")]
        public int? SubGrupoDeProdutoId { get; set; }

        [Display(Name = "SubGrupo de Produto")]
        public SubGrupoDeProduto SubGrupoDeProduto { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [MaxLength(50, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [MaxLength(20, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Unidade de Medida")]
        public string UnidadeMedida { get; set; }

        [MaxLength(20, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string Marca { get; set; }

        [MaxLength(30, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Local no Estoque")]
        public string LocalNoEstoque { get; set; }

        [MaxLength(20, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Referência")]
        public string Referencia { get; set; }

        [MaxLength(150, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string Detalhe { get; set; }

        [MaxLength(255, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Caracterìsticas")]
        public string Caracteristicas { get; set; }

        [Display(Name = "Última Compra")]
        public DateTime? DataUltimaCompra { get; set; }

        [Display(Name = "Última Venda")]
        public DateTime? DataUltimaVenda { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Preço de Compra")]
        public decimal PrecoCompra { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Preço de Custo")]
        public decimal PrecoCusto { get; set; }

        [Display(Name = "Preço de Mínimo")]
        public decimal PrecoMinimo { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Preço de Venda")]
        public decimal PrecoVenda { get; set; }

        [Display(Name = "Estoque Mínimo")]
        public decimal EstoqueMinimo { get; set; }

        [Display(Name = "Estoque Médio")]
        public decimal EstoqueMedio { get; set; }

        public decimal Volume { get; set; }

        [Display(Name = "Peso Líquido")]
        public decimal PesoLiquido { get; set; }

        [Display(Name = "Comissão")]
        public decimal Comissao { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        public string NCM { get; set; }        
    }
}