﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InanceModels.Models
{
    public class AppUser:IdentityUser
    {
        public string FirtsName { get; set; }
        public string LastName { get; set; }
    }
}
