using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneFin.Models
{
	[Table("OptMaster")]
	public class OptMaster
	{
		[Key, Column(Order = 0)] public string OptName { get; set; }
		[Key, Column(Order = 1)] public string Value { get; set; }
		public string Text { get; set; }
		public string Status { get; set; }

        internal static IQueryable<OptMaster> AsNoTracking()
        {
            throw new NotImplementedException();
        }
    }
}
