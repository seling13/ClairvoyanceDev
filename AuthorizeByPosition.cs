using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneFin
{
    public class AuthorizeByPositionAttribute : AuthorizeAttribute
    {
        public void MyAuthorizeAttribute(params string[] roles)
        {
            Roles = String.Join(",", roles);
        }
    }
}
