﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        public string Name { get; set; }

        public string Surname { get; set; } 

        public List<BlogPost>? Posts { get; set; }

        public List<BlogPostComments>? Comments { get; set; }

        public string? ProfileImage { get; set; }

    }
}
