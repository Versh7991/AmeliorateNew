using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Models
{
    public class ApplicationRole : IdentityRole
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
