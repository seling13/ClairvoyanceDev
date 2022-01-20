using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneFin.Models
{

    public class SearcheKYCCIFMatch
    {
        [Key, Column(Order = 0)]
        public string Cifno { get; set; }
        public string ImageURL{ get;set;}
        public string Name { get; set; }
        public string Id { get; set; }
        public string DOB { get; set; }
        public string MatchCount { get; set; }

    }

}