using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SiacWeb.Models.ViewModels
{
    public class UsuarioFormViewModel
    {
        public Usuario Usuario { get; set; }
        public ICollection<IdentityRole> Roles { get; set; } = new List<IdentityRole>();
    }
}