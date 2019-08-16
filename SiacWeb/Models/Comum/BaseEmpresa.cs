using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiacWeb.Models.Comum
{
    public abstract class BaseEmpresa : Base
    {
        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Empresa")]
        public int EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }
    }
}