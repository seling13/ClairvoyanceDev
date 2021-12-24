using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneFin.Struct.CommonService
{
	public class LoginInput : Base.InputBase
	{
		public string userName { get; set; }
		public string password { get; set; }
	}
}
