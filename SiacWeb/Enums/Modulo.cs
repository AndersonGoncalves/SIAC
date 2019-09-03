using System.ComponentModel.DataAnnotations;

namespace SiacWeb.Enums
{
    public enum Modulo : int
    {
        Compra = 1,
        Venda = 2,
        Caixa = 3,
        Financeiro = 4,
        [Display(Name = "Cobrança")]
        Cobranca = 5,
        Estoque = 6,
        [Display(Name = "Gerência")]
        Gerencia = 7
    }
}