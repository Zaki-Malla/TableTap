using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TableTap.Models
{
    public class RoleModel : IdentityRole<int>
    {
        public RoleModel() : base() { }

        public RoleModel(string roleName) : base(roleName) { }
    }
}
