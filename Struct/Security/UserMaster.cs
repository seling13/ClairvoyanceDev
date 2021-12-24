using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneFin.Struct
{
    public class UserMaster
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string RoleName { get; set; }

        public DateTime CreateDate  { get; set; }

        internal static IQueryable<UserMaster> AsNoTracking()
        {
            throw new NotImplementedException();
        }

    }
}
