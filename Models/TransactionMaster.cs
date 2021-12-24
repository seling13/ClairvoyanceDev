using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneFin.Models
{
    public class TransactionMaster
    {
        [Key, Column(Order = 0)] public string ID { get; set; }
        public string Module { get; set; }
        public string TransactionName { get; set; }
        public string Role { get; set; }

    }
}
