using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneFin.Models
{
    public class TaskItemUsers
    {
        public string TaskItemID { get; set; }
        public string TaskID { get; set; }
        public string ItemType { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string ExpectedValue { get; set; }
        public string ExpectedSource { get; set; }
        public string ComparisonValue { get; set; }
        public string ComparisonSource { get; set; }
        public string ComparisonResult { get; set; }
        public string UserId { get; set; }

    }
}
