using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneFin.Models
{
    public class eKYCValidate
    {
        public string eKYCType { get; set; } /*Refer LK/BK type of deviation (BIO,ADD,etc)*/
        public string DV01_lkbmdvIndex { get; set; }

        public string DV03_ruleID { get; set; }
        public string DV04_ruleName { get; set; }
        public string DV05_ruleDescription { get; set; }
        public string DV07_passOrFail { get; set; }
        public string DV08_deviationRemark { get; set; }
        public string DV09_recommendation { get; set; }
        public string NA03_expectedVariableName1 { get; set; }
        public string NA04_expectedVariableAttribute1 { get; set; }
        public string NA05_expectedVariableSource1 { get; set; }
        public string NA06_expectedVariableName2 { get; set; }
        public string NA07_expectedVariableAttribute2 { get; set; }
        public string NA08_expectedVariableSource2 { get; set; }
        public string NA09_expectedVariableName3 { get; set; }
        public string NA10_expectedVariableAttribute3 { get; set; }
        public string NA11_expectedVariableSource3 { get; set; }
        public string NA88_LastModifiedDate { get; set; }
        public string OV03_overrideFlag { get; set; } /*Yes,NO*/
        public string OV04_overrideRemark { get; set; }
        public string OV87_UpdatedBy { get; set; }
        public string OV88_LastModifiedDate { get; set; }
        public string OV05_TP_TN_FP_FN_Flag { get; set; }
        public string OV06_overrideStatus { get; set; } /*APPROVE*/
        

    }
}
