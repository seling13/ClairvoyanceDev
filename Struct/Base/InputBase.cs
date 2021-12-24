using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneFin.Struct.Base
{
    public class InputBase
	{
		public List<FormData> formData { get; set; }
		public List<ApproverData> approverList { get; set; }
		public List<AdditionalData> additionalData { get; set; }
		public string reqType { get; set; }
		public PaymentData paymentData { get; set; }

		public InputBase()
		{
			formData = new List<FormData>();
			approverList = new List<ApproverData>();
			additionalData = new List<AdditionalData>();
			reqType = "submit";
			//paymentData = new PaymentData();
		}
	}
}
