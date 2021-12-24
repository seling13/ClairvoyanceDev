using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace OneFin.Models
{
    public class Users: IdentityUser
    {
        public string FullName { get; set; }
        public DateTime lastlogin { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
