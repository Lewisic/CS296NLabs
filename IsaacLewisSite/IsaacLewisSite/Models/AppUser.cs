using Microsoft.AspNetCore.Identity;
using System;

namespace IsaacLewisSite.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime SignUpDate { get; set; }
    }
}
