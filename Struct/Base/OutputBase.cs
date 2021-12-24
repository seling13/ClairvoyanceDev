using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneFin.Struct.Base
{
	public class OutputBase
	{
		public string code { get; set; }
		public List<string> messageList { get; set; }
		public string detailMessage { get; set; }
		public List<FormData> errorFormData { get; set; }
		public ApprovalData approval { get; set; }

		public OutputBase()
		{
			code = "0"; //success
			messageList = new List<string>();
			errorFormData = new List<FormData>();
			approval = new ApprovalData();
		}
	}
}
