using SiacWeb.Models.Comum;
using System.ComponentModel.DataAnnotations;

namespace SiacWeb.Models
{
    public class GrupoDeProduto : BaseEmpresa
    {
        [Required(ErrorMessage = "{0} obrigatório")]
        [MaxLength(50, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}