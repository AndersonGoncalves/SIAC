using System.Collections.Generic;
using System.Security.Claims;

namespace SiacWeb.Models.Interface
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}