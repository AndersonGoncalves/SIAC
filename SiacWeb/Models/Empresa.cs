using SiacWeb.Models.BaseModels;
using System.ComponentModel.DataAnnotations;

namespace SiacWeb.Models
{
    public class Empresa : Base
    {
        [Required]
        [MaxLength(80)]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required]
        [MaxLength(8)]
        [Display(Name = "CNPJ Base")]
        public string CnpjBase { get; set; }

        [MaxLength(100)]
        [Display(Name = "Site")]
        public string Site { get; set; }
    }
}