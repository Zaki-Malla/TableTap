using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableTap.Models
{
    public class UserModel : IdentityUser<int>
    {
        [Required]
        public string FullName { get; set; }
        public virtual EstablishmentModel? Establishment { get; set; }
    }


}
