using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneFin.Models
{

    public class SearcheKYCResult
    {
        [Key, Column(Order = 0)]
        public string SearchType { get; set; } /*RD RR RA Override */
        public string CF01_CFIndex { get; set; }
        public string BM02_lkIndex { get; set; }
        public string NA03_cifName { get; set; } /* base on LK16 respective channel*/
        public string IM03_avatarImageURL {get; set;} /* base on LK16 respective channel*/
        public string LK03_countPass { get; set; }
        public string LK04_countFail { get; set; }
         public string LK05_countForceOverride { get; set; }
         public string LK15_countIncompleteData { get; set; }
         public string LK17_finalBlazeRecommendation { get; set; }
          public string LK18_finalStatus { get; set; }

    }

}