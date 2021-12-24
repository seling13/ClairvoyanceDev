using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneFin.Struct.Base
{
	public class PaymentData
	{
		public decimal amount { get; set; }
		public string type { get; set; }
		public string mode { get; set; }
		public decimal payamt { get; set; }
		public List<PaymentDenoData> denoIn { get; set; }
		public List<PaymentDenoData> denoOut { get; set; }

		public PaymentData()
		{
			denoIn = new List<PaymentDenoData>();
			denoOut = new List<PaymentDenoData>();
		}
	}

	public class PaymentDenoData
	{
		public decimal value { get; set; }
		public int count { get; set; }
	}

}
