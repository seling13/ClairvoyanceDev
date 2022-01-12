using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneFin.Models
{

    public class CFCustomer
    {
        [Key, Column(Order = 0)]
        public string Cifno { get; set; }
        public string Name { get; set; }
        public string PrimaryIDno { get; set; }
        public string IMGSource { get; set; }
        public List<CFAddress> AddContentList { get; set; }
        public List<CFPhone> PhoneContentList { get; set; }
        public List<CFEmail> EmailContentList { get; set; }
        public List<CFSocialMedia> SocialMediaContentList { get; set; }

        public List<CFEmploymentCivilianPublicSector> EmploymentCivilianPublicSectorContentList { get; set; }
        public List<CFEmploymentUniformPublicSector> EmploymentUniformPublicSectorContentList { get; set; }
        public List<CFEmploymentSemiGovernmentSector> EmploymentSemiGovernmentSectorContentList { get; set; }
        public List<CFEmploymentPrivateSector> EmploymentPrivateSectorContentList { get; set; }
        public List<CFEmploymentSelfEmployed> EmploymentSelfEmployedContentList { get; set; }
        public List<CFUnemployed> UnemployedContentList { get; set; }

        public List<CFMIncome> MIncomeContentList { get; set; }

        public List<CFYIncome> YIncomeContentList { get; set; }

        public List<CFRelationship> RelationshipContentList { get; set; }


        public CFCustomer()
        {
            AddContentList = new List<CFAddress>();
            PhoneContentList = new List<CFPhone>();
            EmailContentList = new List<CFEmail>();
            SocialMediaContentList = new List<CFSocialMedia>();

            EmploymentCivilianPublicSectorContentList = new List<CFEmploymentCivilianPublicSector>();
            EmploymentUniformPublicSectorContentList = new List<CFEmploymentUniformPublicSector>();
            EmploymentSemiGovernmentSectorContentList = new List<CFEmploymentSemiGovernmentSector>();
            EmploymentPrivateSectorContentList = new List<CFEmploymentPrivateSector>();
            EmploymentSelfEmployedContentList = new List<CFEmploymentSelfEmployed>();
            UnemployedContentList = new List<CFUnemployed>();

            MIncomeContentList = new List<CFMIncome>();
            YIncomeContentList = new List<CFYIncome>();

            RelationshipContentList = new List<CFRelationship>();
        }

    }

    public class CFAddress
    {
        public string TP04_kampong_FPKC { get; set; }
        public string TP05_jalan_FPJC { get; set; }
        public string TP06_simpang_FPSM { get; set; }
        public string TP07_block { get; set; }
        public string TP08_unit { get; set; }
        public string TP09_postalCode_FPPK { get; set; }
        public string TP10_district_FPDK { get; set; }
        public string TP11_mukim { get; set; }
        public string TP12_lot_FPLT { get; set; } 
        public string TP13_building_FPBG { get; set; }
        public string RegHist { get; set; }

        public string TP92_source { get; set; }


    }

    public class CFPhone
    {
        public string PH03_phoneNumber { get; set; }
        public string PH04_phoneType_FPTL { get; set; }
        public string PH05_source { get; set; }
        public string PH06_startDate { get; set; }
        public string PH07_EndDate { get; set; }
        public string PH08_countryNameCountryCode { get; set; }
        public string PH09_countryCallingCode_FPCA { get; set; }
        public string PH87_userID { get; set; }
        public string PH88_lastUpdate { get; set; }
        public string RegHist { get; set; }
        public string OTPHist { get; set; }


    }

    public class CFEmail
    {
        public string EM03_emailAddress { get; set; }
        public string EM04_startDate { get; set; }
        public string EM05_endDate { get; set; }
        public string EM06_source { get; set; }
        public string EM87_userID { get; set; }
        public string EM88_lastUpdate { get; set; }
        public string PH09_countryCallingCode_FPCA { get; set; }
        public string PH87_userID { get; set; }
        public string PH88_lastUpdate { get; set; }

        public string RegHist { get; set; }
        public string OTPHist { get; set; }

    }

    public class CFSocialMedia
    {
        public string SM03_socialMediaType_FKXX { get; set; }
        public string SM04_socialMediaUserID { get; set; }
        public string SM05_startDate { get; set; }
        public string SM06_endDate { get; set; }
        public string SM87_userID { get; set; }
        public string lastUpdateDate { get; set; }
      

    }

    public class CFEmploymentCivilianPublicSector {
        public string CS03_ministryCode_FPMT { get; set; }
        public string CS04_startDate { get; set; }
        public string CS05_endDate { get; set; }
        public string CS87_updatedBy { get; set; }

        public string CS88_lastModifiedDate { get; set; }
        

    }

    public class CFEmploymentUniformPublicSector
    {
        public string US03_UniformCode_FPUF { get; set; }
        public string US04_StartDate { get; set; }
        public string US05_EndDate { get; set; }
        public string US87_UserID { get; set; }

        public string US88_UpdateDate { get; set; }

        

    }

    public class CFEmploymentSemiGovernmentSector
    {
        public string SS03_semiGovernment { get; set; }
        public string SS04_startDate { get; set; }
        public string SS05_endDate { get; set; }
        public string SS87_userID { get; set; }
        public string SS88_updateDate { get; set; }
        

    }

    public class CFEmploymentPrivateSector
    {
        public string PS03_privateCompany { get; set; }
        public string PS04_startDate { get; set; }
        public string PS05_endDate { get; set; }
        public string PS87_userID { get; set; }
        public string PS88_updateDate { get; set; }

    }

    public class CFEmploymentSelfEmployed
    {
        public string BH04_companyName_FPPV { get; set; }
        public string BH05_businessStartDate { get; set; }
        public string BH06_businessEndDate { get; set; }
        public string BH87_UserID { get; set; }
        public string BH88_UpdateDate { get; set; }

    }

    public class CFUnemployed
    {
        public string UH03_unemploymentType_FPUT { get; set; }
        public string UH04_StartDate { get; set; }
        public string UH05_EndDate { get; set; }
        public string UH87_UserID { get; set; }
        public string UH88_UpdateDate { get; set; }

    }

    public class CFMIncome
    {
        public string MI03_totalMonthlyIncome { get; set; }

        public string MI04_period { get; set; }
        
        public string MI04_periodMI05_incomeCatagory_FPSU { get; set; }

    }

    public class CFYIncome
    {
        public string AI03_annualIncome { get; set; }

        public string AI04_YYYY { get; set; }

        public string AI05_incomeCat_FPSU { get; set; }

    }

    public class CFRelationship
    {
        public string SU09_relationshipCIFName { get; set; }
        public string SU05_relationshipType_FPRE { get; set; }

        public string SU06_relationshipStatus { get; set; }

        public string SU07_startDate { get; set; }
        public string SU08_endDate { get; set; }
        public string SU87_updatedBy { get; set; }
        public string SU88_lastModifiedDate { get; set; }

    }

}
