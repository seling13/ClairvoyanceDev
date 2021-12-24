using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneFin.Comm
{
	public class DateFormat
	{
		public const string RawFormat = "yyyyMMdd";
		public const string DisplayFormat = "yyyy-MM-dd";
		public const string UtcFormat = "yyyy-MM-dd";
	}

	public class TimeFormat
	{
		public const string RawFormat = "HHmmssfff";
		public const string DisplayFormat = "h:mm tt";
		public const string UtcFormat = "HH:mm:ss.fff";
	}

	public class DateTimeFormat
	{
		public const string RawFormat = DateFormat.RawFormat + TimeFormat.RawFormat;
		public const string DisplayFormat = DateFormat.DisplayFormat + " " + TimeFormat.DisplayFormat;
		public const string UtcFormat = DateFormat.UtcFormat + "T" + TimeFormat.UtcFormat;
	}

	public class ReqType
	{
		public const string Payment = "payment";
		public const string Submit = "submit";
		public const string Enquiry = "enquiry";
	}

	public class PaymentMode
	{
		public const string Cash = "1";
		public const string Journal = "2";
		public const string Cheque = "3";
	}

	public class DenoDirection
	{
		public const string In = "I";
		public const string Out = "O";
	}
}
