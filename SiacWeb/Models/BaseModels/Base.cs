using System.ComponentModel.DataAnnotations;

namespace SiacWeb.Models.BaseModels
{
    public abstract class Base
    {
        [Display(Name = "Código")]
        public int Id { get; set; }
    }
}
