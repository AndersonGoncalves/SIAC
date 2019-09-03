using System.ComponentModel.DataAnnotations;

namespace SiacWeb.Enums
{
    public enum Operacao : int
    {
        [Display(Name = "Inclusão")]
        Inclusao = 1,
        [Display(Name = "Alteração")]
        Alteracao = 2,
        [Display(Name = "Exclusão")]
        Exclusao = 3
    }
}