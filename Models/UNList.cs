using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneFin.Models
{
    public class UNList
    {
        [Key, Column(Order = 0)] public string ID { get; set; }
        public string FIRST_NAME { get; set; }
        public string SECOND_NAME { get; set; }
        public string THIRD_NAME { get; set; }
        public string FOURTH_NAME { get; set; }
        public string UN_LIST_TYPE { get; set; }
        public string REFERENCE_NUMBER { get; set; }
        public string NAME_ORIGINAL_SCRIPT { get; set; }
        public string COMMENTS1 { get; set; }
        public string TITLE { get; set; }
        public string DESIGNATION { get; set; }
        public string NATIONALITY { get; set; }
        public string INDIVIDUAL_ALIAS { get; set; }
        public string INDIVIDUAL_ADDRESS { get; set; }
        public string INDIVIDUAL_DATE_OF_BIRTH { get; set; }
        public string INDIVIDUAL_PLACE_OF_BIRTH { get; set; }
        public string INDIVIDUAL_DOCUMENT { get; set; }
        public string LAST_DAY_UPDATED { get; set; }
        
    }
}
