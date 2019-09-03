using System.ComponentModel.DataAnnotations;

namespace SiacWeb.Enums
{
    public enum SubModulo : int
    {
        Fornecedor = 1,
        Transportadora = 2,
        [Display(Name = "Pedido de Compra")]
        PedidoDeCompra = 3,
        [Display(Name = "Cotação de Compra")]
        CotacaoDeCompra = 4,
        Cliente = 5,
        [Display(Name = "Pedido de Venda")]
        PedidoDeVenda = 6,
        [Display(Name = "Cotação de Venda")]
        CotacaoDeVenda = 7,
        [Display(Name = "Reabertura de Pedido de Venda")]
        ReaberturaDePedido = 8,
        [Display(Name = "Devolução de Pedido de Venda")]
        DevolucaoDePedido = 9,
        [Display(Name = "Pesquisa de Produto")]
        PesquisaDeProduto = 10,
        Empresa = 11,
        [Display(Name = "Centro de Custo")]
        CentroDeCusto = 12,
        Perfil = 13,
        [Display(Name = "Usuário")]
        Usuario = 14,
        Funcionario = 15,
        [Display(Name = "Autônomo")]
        Autonomo = 16,
        Auditoria = 17,
        [Display(Name = "Configuração")]
        Configuracao = 18
    }
}