using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IsaacLewisSite.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime SignUpDate { get; set; }

        public string Name { get; set; }

        [NotMapped] 
        public IList<string> RoleNames { get; set; } = null!;
    }
}
