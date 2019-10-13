using SiacWeb.Models.Comum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiacWeb.Models
{
    public class SubGrupoDeProduto : BaseEmpresa
    {
        [Display(Name = "Grupo de Produto")]
        public int? GrupoDeProdutoId { get; set; }

        [ForeignKey("GrupoDeProdutoId")]
        [Display(Name = "Grupo de Produto")]
        public GrupoDeProduto GrupoDeProduto { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [MaxLength(50, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}