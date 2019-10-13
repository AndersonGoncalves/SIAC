using System;
using SiacWeb.Models.Comum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace SiacWeb.Models
{
    public class Produto : BaseEmpresa
    {
        [Display(Name = "Fornecedor")]
        public int? FornecedorId { get; set; }

        [ForeignKey("FornecedorId")]
        public Fornecedor Fornecedor { get; set; }

        [Display(Name = "Grupo")]
        public int? GrupoDeProdutoId { get; set; }

        [ForeignKey("GrupoDeProdutoId")]
        [Display(Name = "Grupo")]
        public GrupoDeProduto GrupoDeProduto { get; set; }

        [Display(Name = "SubGrupo")]
        public int? SubGrupoDeProdutoId { get; set; }

        [ForeignKey("SubGrupoDeProdutoId")]
        [Display(Name = "SubGrupo")]
        public SubGrupoDeProduto SubGrupoDeProduto { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [MaxLength(50, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [MaxLength(20, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Unid. Medida")]
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
        [Display(Name = "Características")]
        public string Caracteristicas { get; set; }

        [Display(Name = "Última Compra")]
        public DateTime? DataUltimaCompra { get; set; }

        [Display(Name = "Última Venda")]
        public DateTime? DataUltimaVenda { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Preço de Compra")]
        public double PrecoCompra { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Preço de Custo")]
        public double PrecoCusto { get; set; }

        [Display(Name = "Preço de Mínimo")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? PrecoMinimo { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Preço de Venda")]
        public double PrecoVenda { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Estoque Mínimo")]
        public double? EstoqueMinimo { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Estoque Médio")]
        public double? EstoqueMedio { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? Volume { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Peso Líquido")]
        public double? PesoLiquido { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Comissão")]
        public double? Comissao { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        public string NCM { get; set; }

        public ICollection<CodigoDeBarra> CodigoDeBarras { get; set; } = new List<CodigoDeBarra>();
    }    
}