using System;
using SiacWeb.Models.Comum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using SiacWeb.Enums;

namespace SiacWeb.Models
{
    public class Inventario : BaseCentroDeCusto
    {
        [Required(ErrorMessage = "{0} obrigatório")]        
        public StatusInventario Status { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de Procesamento")]
        public DateTime? DataProcessamento { get; set; }

        [Display(Name = "Funcionário Responsável")]
        public int? FuncionarioId { get; set; }

        [ForeignKey("FuncionarioId")]
        public Funcionario Funcionario { get; set; }

        public ICollection<InventarioItem> InventarioItens { get; set; } = new List<InventarioItem>();

        [NotMapped]
        [Display(Name = "Total de Produtos")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double TotalDeProdutos
        {
            get { return InventarioItens.Count; }
        }

        [NotMapped]
        [Display(Name = "Valor de Custo")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double ValorDeCusto
        {
            get
            {
                double qtde = 0;
                foreach (InventarioItem item in InventarioItens)
                {
                    qtde += (item.QuantidadeInformada * item.PrecoCusto);
                }

                return qtde;
            }
        }

        [NotMapped]
        [Display(Name = "Valor de Compra")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double ValorDeCompra
        {
            get
            {
                double qtde = 0;
                foreach (InventarioItem item in InventarioItens)
                {
                    qtde += (item.QuantidadeInformada * item.PrecoCompra);
                }

                return qtde;
            }
        }

        [NotMapped]
        [Display(Name = "Valor de Venda")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double ValorDeVenda
        {
            get
            {
                double qtde = 0;
                foreach (InventarioItem item in InventarioItens)
                {
                    qtde += (item.QuantidadeInformada * item.PrecoVenda);
                }

                return qtde;
            }
        }
    }
}