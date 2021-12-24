using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneFin.Struct.Base
{
	public class FormData
	{
		public string key { get; set; }
		public string value { get; set; }
		public bool mandatory { get; set; }
		public bool display { get; set; }
		public bool enable { get; set; }
		public string type { get; set; }
		public decimal minval { get; set; }
		public decimal maxval { get; set; }
		public string caption { get; set; }
		public string validationStatus { get; set; }
		public string message { get; set; }

		public FormData()
		{
			mandatory = false;
			display = false;
			enable = false;
			minval = decimal.MinValue;
			maxval = decimal.MaxValue;
		}
	}
}
