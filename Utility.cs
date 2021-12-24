using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneFin
{
    public class Utility
    { 

        public static string GetRandomId()
        {
			return Guid.NewGuid().ToString("N");
        }
    
        public static string GetUniqueId()
        {
            return string.Format("{0:yyyyMMddHHmmss}_{1}", DateTime.Now, Utility.GetRandomId());
        }
    }
}