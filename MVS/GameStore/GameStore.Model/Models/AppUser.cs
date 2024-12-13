using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Model.Models
{
    public class AppUser:IdentityUser
    {
        public ICollection<Comment> Comments { get; set; }
    }
}
