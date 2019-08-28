using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SiacWeb.Models.ViewModels
{
    public class UsuarioFormViewModel
    {
        public Usuario Usuario { get; set; }
        public ICollection<IdentityRole> Roles { get; set; } = new List<IdentityRole>();
        public ICollection<string> UserRoles { get; set; } = new List<string>();



        public bool ExisteRoles(string role)
        {
            return UserRoles.Contains(role);
        }
    }
}