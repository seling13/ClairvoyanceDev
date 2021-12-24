using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneFin.Models
{
    public class CustomerCFDetail
    {
        public string Name { get; set; }
        public string IDNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CIFNO { get; set; }

    }
}
