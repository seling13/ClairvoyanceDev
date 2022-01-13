using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneFin.Models;
using Newtonsoft.Json;

namespace OneFin.Areas.Clairvoyance.Controllers
{
    [Area("Clairvoyance")]
    public class eKYCController : Controller
    {
        public IActionResult eKYCSearch()
        {
            return View();
        }

        public IActionResult eKYCSearchList(string Name)
        {
            List<CFCustomer> custlist = new List<CFCustomer>();

                var cust1 = new CFCustomer { Name = "John Wick", IMGSource = "/sampleimg/John Wick.jpg",Cifno="000000000001" };
                var cust2 = new CFCustomer { Name = "Datin Leng", IMGSource = "/sampleimg/Datin Leng.jpg", Cifno = "000000000002" };
                var cust3 = new CFCustomer { Name = "John Doe", IMGSource = "/sampleimg/Unknown.jpg", Cifno = "000000000003" };
                var cust = new CFCustomer { Name = "Jason Lee Micheal", IMGSource = "/sampleimg/Jason Lee.jpg", Cifno = "000000000004" };
                custlist.Add(cust1);
                custlist.Add(cust2);
                custlist.Add(cust3);
                custlist.Add(cust);
          
            if( Name !=null && Name !="")
            {


                custlist = custlist.Where(item => item.Name.ToLower().Contains(Name.ToLower())).ToList();


            }


            if (custlist.Count == 0)
            {
                return Json(new { status = false, message = "Record Not Found" });
            }
            else
             return PartialView(custlist);
        }

        public IActionResult eKYCDetailList(string filter, string type, string ekycvalidate)
        {

            try
            {
                List<eKYCValidate> items  = new List<eKYCValidate>();
                var ekycitems = JsonConvert.DeserializeObject<List<eKYCValidate>>(ekycvalidate).ToList();

                if(filter == "Pass" || filter == "Fail")
                {
                    var _filter = filter.ToUpper();
                    ekycitems = ekycitems.Where(item => item.DV07_passOrFail == _filter).ToList();
                }
                else if (filter == "Override")
                {
                    ekycitems = ekycitems.Where(item => item.OV03_overrideFlag == "YES").ToList();

                }

                 items = ekycitems.Where(item => item.eKYCType == type).ToList();

                ViewBag.type = type;


                return PartialView(items);
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }

        }

        public IActionResult eKYCDetail(string id)
        {
            /*Display Customer Master*/
            var cust = new CFCustomer();
            List<CFAddress> cfaddresslist = new List<CFAddress>();
            List<CFPhone> cfphonelist = new List<CFPhone>();
            List<CFEmail> cfemaillist = new List<CFEmail>();
            List<CFSocialMedia> cfsocialmedialist = new List<CFSocialMedia>();
            List<CFEmploymentCivilianPublicSector> cfemploymentcivilianpublicsectorlist = new List<CFEmploymentCivilianPublicSector>();
            List<CFEmploymentUniformPublicSector> cfemploymentuniformpublicsectorlist = new List<CFEmploymentUniformPublicSector>();
            List<CFEmploymentSemiGovernmentSector> cfemploymentsemigovernmentsectorlist = new List<CFEmploymentSemiGovernmentSector>();
            List<CFEmploymentPrivateSector> cfemploymentprivatesectolist = new List<CFEmploymentPrivateSector>();
            List<CFEmploymentSelfEmployed> cfemploymentselfemployedlist = new List<CFEmploymentSelfEmployed>();
            List<CFUnemployed> cfunemployed = new List<CFUnemployed>();
            List<CFYIncome> cfyincome = new List<CFYIncome>();
            List<CFMIncome> cfmincome = new List<CFMIncome>();
            List<CFRelationship> cfrelationship = new List<CFRelationship>();


            if (id == "000000000001")
            {
                cust = new CFCustomer { Name = "John Wick", IMGSource = "/sampleimg/John Wick.jpg", Cifno = "000000000001", PrimaryIDno = ""};
            }
            if (id == "000000000002")
                cust = new CFCustomer { Name = "Datin Leng", IMGSource = "/sampleimg/Datin Leng.jpg", Cifno = "000000000002", PrimaryIDno = ""};
            if (id == "000000000003")
                cust = new CFCustomer { Name = "John Doe", IMGSource = "/sampleimg/Unknown.jpg", Cifno = "000000000003", PrimaryIDno = "" };
            if (id == "000000000004")
                cust = new CFCustomer { Name = "Jason Lee Micheal ", IMGSource = "/sampleimg/Jason Lee.jpg", Cifno = "000000000003", PrimaryIDno = "" };

            /*Mock Address*/
            cfaddresslist.Add(new CFAddress { TP04_kampong_FPKC = "MATA-MATA", TP05_jalan_FPJC = "1", TP06_simpang_FPSM = "24", TP07_block = "", TP08_unit = "", TP09_postalCode_FPPK = "TC1234", TP10_district_FPDK = "TUTONG", TP11_mukim = "TUTONG", TP12_lot_FPLT = "", TP13_building_FPBG = "BANGUNAN PERSEKUTUAN PENGAKAP", RegHist = "2" });
            cfaddresslist.Add(new CFAddress { TP04_kampong_FPKC = "SENGKARAI", TP05_jalan_FPJC = "22", TP06_simpang_FPSM = "", TP07_block = "12", TP08_unit = "3", TP09_postalCode_FPPK = "TC1234", TP10_district_FPDK = "TUTONG", TP11_mukim = "TUTONG", TP12_lot_FPLT = "789", TP13_building_FPBG = "" , RegHist = "1" });
            cfaddresslist.Add(new CFAddress { TP04_kampong_FPKC = "KAYANGAN", TP05_jalan_FPJC = "3", TP06_simpang_FPSM = "1", TP07_block = "", TP08_unit = "", TP09_postalCode_FPPK = "BA1234", TP10_district_FPDK = "TUTONG", TP11_mukim = "TUTONG", TP12_lot_FPLT = "", TP13_building_FPBG = "",RegHist="1" });
            cust.AddContentList.AddRange(cfaddresslist);

            cfphonelist.Add(new CFPhone { PH03_phoneNumber= "45454545",PH04_phoneType_FPTL= "HOME", PH05_source="MIBS", PH06_startDate="05-JUL-21 ",PH07_EndDate="", PH87_userID="TESTING USER", PH88_lastUpdate="05-JUL-21 ", RegHist="2",OTPHist= "0" });
            cfphonelist.Add(new CFPhone { PH03_phoneNumber = "8785628", PH04_phoneType_FPTL = "MOBILE", PH05_source = "CREDIT BUREAU", PH06_startDate = "10-JUL-21 ", PH07_EndDate = "", PH87_userID = "TESTING USER", PH88_lastUpdate = "05-JUL-21 ", RegHist = "1", OTPHist = "3" });
            cust.PhoneContentList.AddRange(cfphonelist);
            /*Mock Contact*/

            cfemaillist.Add(new CFEmail { EM03_emailAddress = "james@gmail.com", EM06_source = "MIBS", EM04_startDate = "05-JUL-21 ", EM05_endDate = "", EM87_userID = "TESTING USER", EM88_lastUpdate = "05-JUL-21 ", RegHist = "1", OTPHist = "3"  });
            cfemaillist.Add(new CFEmail { EM03_emailAddress = "jameslee@gmail.com", EM06_source = "MOBILE",  EM04_startDate = "10-JUL-21 ", EM05_endDate = "", PH87_userID = "TESTING USER", EM88_lastUpdate = "05-JUL-21 ", RegHist = "1", OTPHist = "3" });
            cust.EmailContentList.AddRange(cfemaillist);

            cfsocialmedialist.Add(new CFSocialMedia { SM04_socialMediaUserID = "james@gmail.com", SM03_socialMediaType_FKXX = "INSTAGRAM", SM05_startDate = "05-JUL-21 ", SM06_endDate = "", SM87_userID = "TESTING USER", lastUpdateDate = "05-JUL-21 " });
            cfsocialmedialist.Add(new CFSocialMedia { SM04_socialMediaUserID = "jameslee@gmail.com", SM03_socialMediaType_FKXX = "LINKEIN", SM05_startDate = "10-JUL-21 ", SM06_endDate = "", SM87_userID = "TESTING USER", lastUpdateDate = "05-JUL-21 " });
            cust.SocialMediaContentList.AddRange(cfsocialmedialist);

            cfemploymentcivilianpublicsectorlist.Add(new CFEmploymentCivilianPublicSector { CS03_ministryCode_FPMT= "45454545", CS04_startDate= "05-JUL-21 ", CS05_endDate="",CS87_updatedBy= "TESTING USER", CS88_lastModifiedDate= "05-JUL-21 " });
            cfemploymentuniformpublicsectorlist.Add(new CFEmploymentUniformPublicSector { US03_UniformCode_FPUF = "1166111", US04_StartDate = "05-JUL-21 ", US05_EndDate = "", US87_UserID = "TESTING USER", US88_UpdateDate = "05-JUL-21 " });
            cfemploymentsemigovernmentsectorlist.Add(new CFEmploymentSemiGovernmentSector { SS03_semiGovernment = "WaterBoard", SS04_startDate = "05-JUL-21 ",  SS05_endDate= "", SS87_userID = "TESTING USER",  SS88_updateDate= "05-JUL-21 " });
            cfemploymentprivatesectolist.Add(new CFEmploymentPrivateSector { PS03_privateCompany = "Super 888 Company", PS04_startDate = "05-JUL-21 ", PS05_endDate = "", PS87_userID = "TESTING USER", PS88_updateDate = "05-JUL-21 " });
            cfemploymentselfemployedlist.Add(new CFEmploymentSelfEmployed { BH04_companyName_FPPV = "ANT Company", BH05_businessStartDate = "05-JUL-20 ", BH06_businessEndDate = "", BH87_UserID = "TESTING USER", BH88_UpdateDate = "05-JUL-21 " });
            cfunemployed.Add(new CFUnemployed { UH03_unemploymentType_FPUT = "Housewife", UH04_StartDate = "05-JUL-19 ", UH05_EndDate = "", UH87_UserID = "TESTING USER", UH88_UpdateDate = "05-JUL-21 " });


            cust.EmploymentCivilianPublicSectorContentList.AddRange(cfemploymentcivilianpublicsectorlist);
            cust.EmploymentUniformPublicSectorContentList.AddRange(cfemploymentuniformpublicsectorlist);
            cust.EmploymentSemiGovernmentSectorContentList.AddRange(cfemploymentsemigovernmentsectorlist);
            cust.EmploymentPrivateSectorContentList.AddRange(cfemploymentprivatesectolist);
            cust.EmploymentSelfEmployedContentList.AddRange(cfemploymentselfemployedlist);
            cust.UnemployedContentList.AddRange(cfunemployed);


            cfmincome.Add(new CFMIncome { MI04_periodMI05_incomeCatagory_FPSU = "Employment",MI04_period="July-2020",MI03_totalMonthlyIncome="$2000" });
            cfmincome.Add(new CFMIncome { MI04_periodMI05_incomeCatagory_FPSU = "Employment", MI04_period = "July-2000", MI03_totalMonthlyIncome = "$1300" });
            cust.MIncomeContentList.AddRange(cfmincome);


            cfyincome.Add(new CFYIncome { AI05_incomeCat_FPSU = "Employment", AI04_YYYY = "2020", AI03_annualIncome = "$1,000,000" });
            cust.YIncomeContentList.AddRange(cfyincome);

            //cfrelationship.Add(new CFRelationship { SU09_relationshipCIFName= "MARJINA",SU05_relationshipType_FPRE= "SPOUSE",SU06_relationshipStatus="Valid", SU07_startDate= "05-JUL-19 ", SU08_endDate="", SU87_updatedBy="RIHINAH",SU88_lastModifiedDate="" });
            cfrelationship.Add(new CFRelationship { SU09_relationshipCIFName = "THIRD CHILD BIN MD ARNEY FAIZUL", SU05_relationshipType_FPRE = "BIOLOGICAL CHILD", SU06_relationshipStatus = "Valid", SU07_startDate = "05-JUL-19 ", SU08_endDate = "", SU87_updatedBy = "TESTING USER", SU88_lastModifiedDate = "05-JUL-21" });


            cust.RelationshipContentList.AddRange(cfrelationship);


            ViewData["Customer"] = cust;



            /*ekyclist Master*/
            List<eKYCValidate> ekyclist = new List<eKYCValidate>();
            var item1 = new eKYCValidate
            {
                eKYCType = "BIO",
                DV01_lkbmdvIndex = "001",
                DV03_ruleID= "BIO_METRIC9",
                DV04_ruleName = "FacialRecognitionImage",
                DV05_ruleDescription = "Validate if the customer registered for facial recognition",
                DV07_passOrFail = "FAIL",
                DV09_recommendation = "Please capture profile image",
                NA03_expectedVariableName1 = "Transaction Avatar URL",
                NA04_expectedVariableAttribute1= "/sampleimg/images.jpg",
                NA05_expectedVariableSource1="View Source",
                NA06_expectedVariableName2 = "Transaction Avatar Image",
                NA07_expectedVariableAttribute2 = "10.00%",
                NA08_expectedVariableSource2= "View Source",
                NA09_expectedVariableName3 = "Profile Image",
                NA10_expectedVariableAttribute3 = cust.IMGSource,
                //cust.IMGSource,
                NA11_expectedVariableSource3 = "View Source",
                NA88_LastModifiedDate = "30-NOV-21",
                OV03_overrideFlag = "",
                OV04_overrideRemark = "",
                OV87_UpdatedBy = "",
                OV88_LastModifiedDate = "",
                OV05_TP_TN_FP_FN_Flag = "-",
                OV06_overrideStatus = ""

            };
            var item2 = new eKYCValidate
            {
                eKYCType = "BIO",
                DV01_lkbmdvIndex = "002",
                DV03_ruleID = "BIO_METRIC8",
                DV04_ruleName = "Validate Face Image",
                DV05_ruleDescription = "Validate facial similarity score",
                DV07_passOrFail = "FAIL",
                DV09_recommendation = "Profile Image Not Match",
                NA03_expectedVariableName1 = "Transaction Avatar URL",
                NA04_expectedVariableAttribute1 = "/sampleimg/images.jpg",
                NA05_expectedVariableSource1 = "View Source",
                NA06_expectedVariableName2 = "Transaction Avatar Image",
                NA07_expectedVariableAttribute2 = "10.00%",
                NA08_expectedVariableSource2 = "View Source",
                NA09_expectedVariableName3 = "Profile Image",
                NA10_expectedVariableAttribute3 = cust.IMGSource,
                NA11_expectedVariableSource3 = "View Source",
                NA88_LastModifiedDate = "30-NOV-21",
                OV03_overrideFlag = "",
                OV04_overrideRemark = "",
                OV87_UpdatedBy = "",
                OV88_LastModifiedDate = "",
                OV05_TP_TN_FP_FN_Flag = "-",
                OV06_overrideStatus = ""

            };
            var item3 = new eKYCValidate
            {
                eKYCType = "BIO",
                DV01_lkbmdvIndex = "003",
                DV03_ruleID = "BIO_METRIC7",
                DV04_ruleName = "Transaction Avatar x Profile Avatar Match % ",
                DV05_ruleDescription = "Validate Similarity Score % - Transaction Avatar X Profile Avatar",
                DV07_passOrFail = "FAIL",
                DV09_recommendation = "Please verify profile and transaction image",
                NA03_expectedVariableName1 = "Transaction Avatar URL",
                NA04_expectedVariableAttribute1 = "/sampleimg/images.jpg",
                NA05_expectedVariableSource1 = "View Source",
                NA06_expectedVariableName2 = "Transaction Avatar Image",
                NA07_expectedVariableAttribute2 = "10.00%",
                NA08_expectedVariableSource2 = "View Source",
                NA09_expectedVariableName3 = "Profile Image",
                NA10_expectedVariableAttribute3 = cust.IMGSource,
                NA11_expectedVariableSource3 = "View Source",
                NA88_LastModifiedDate = "30-NOV-21",
                OV03_overrideFlag = "YES",
                OV04_overrideRemark = "Verified Correct",
                OV87_UpdatedBy = "Rafhanah",
                OV88_LastModifiedDate = "30-NOV-21",
                OV05_TP_TN_FP_FN_Flag = "FALSE NEGATIVE",
                OV06_overrideStatus = "APPROVED"

            };
            var item4 = new eKYCValidate
            {
                eKYCType = "BIO",
                DV01_lkbmdvIndex = "004",
                DV03_ruleID = "BIO_METRIC11",
                DV04_ruleName = "Transaction Avatar x Profile Avatar Match % ",
                DV05_ruleDescription = "Validate Similarity Score % - Transaction Avatar X Profile Avatar",
                DV07_passOrFail = "PASS",
                DV09_recommendation = "Please verify profile and transaction image",
                NA03_expectedVariableName1 = "Transaction Avatar URL",
                NA04_expectedVariableAttribute1 = "/sampleimg/images.jpg",
                NA05_expectedVariableSource1 = "View Source",
                NA06_expectedVariableName2 = "Transaction Avatar Image",
                NA07_expectedVariableAttribute2 = "10.00%",
                NA08_expectedVariableSource2 = "View Source",
                NA09_expectedVariableName3 = "Profile Image",
                NA10_expectedVariableAttribute3 = cust.IMGSource,
                NA11_expectedVariableSource3 = "View Source",
                NA88_LastModifiedDate = "30-NOV-21",
                OV03_overrideFlag = "",
                OV04_overrideRemark = "",
                OV87_UpdatedBy = "",
                OV88_LastModifiedDate = "",
                OV05_TP_TN_FP_FN_Flag = "",
                OV06_overrideStatus = ""

            };
            ekyclist.Add(item1);
            ekyclist.Add(item2);
            ekyclist.Add(item3);
            ekyclist.Add(item4);

            /*Address*/
            ekyclist.Add(new eKYCValidate
            {
                eKYCType = "Address", //ekyctab:BIO/Address/ID/Contact/Employment/Income/Relationship
                DV01_lkbmdvIndex = "005",
                DV03_ruleID = "ADDRESS6",
                DV04_ruleName = "Bad Address Rule",
                DV05_ruleDescription = "Checking Address which are having bad kampong",
                DV07_passOrFail = "PASS",
                DV09_recommendation = "Address No Longer Exists",
                NA03_expectedVariableName1 = "",
                NA04_expectedVariableAttribute1 = "",
                NA05_expectedVariableSource1 = "",
                NA06_expectedVariableName2 = "",
                NA07_expectedVariableAttribute2 = "",
                NA08_expectedVariableSource2 = "",
                NA09_expectedVariableName3 = "",
                NA10_expectedVariableAttribute3 = "",
                NA11_expectedVariableSource3 = "",
                NA88_LastModifiedDate = "",
                OV03_overrideFlag = "",
                OV04_overrideRemark = "",
                OV87_UpdatedBy = "",
                OV88_LastModifiedDate = "",
                OV05_TP_TN_FP_FN_Flag = "TRUE POSITIVE",
                OV06_overrideStatus = ""

            });
            ekyclist.Add(new eKYCValidate
            {
                eKYCType = "Address", //ekyctab:BIO/Address/ID/Contact/Employment/Income/Relationship
                DV01_lkbmdvIndex = "006",
                DV03_ruleID = "ADDRESS7",
                DV04_ruleName = "Missing CIF Relationship",
                DV05_ruleDescription = "Checks for same address but no relationship define",
                DV07_passOrFail = "PASS",
                DV09_recommendation = "Relationship Not Define",
                NA03_expectedVariableName1 = "",
                NA04_expectedVariableAttribute1 = "",
                NA05_expectedVariableSource1 = "",
                NA06_expectedVariableName2 = "",
                NA07_expectedVariableAttribute2 = "",
                NA08_expectedVariableSource2 = "",
                NA09_expectedVariableName3 = "",
                NA10_expectedVariableAttribute3 = "",
                NA11_expectedVariableSource3 = "",
                NA88_LastModifiedDate = "",
                OV03_overrideFlag = "",
                OV04_overrideRemark = "",
                OV87_UpdatedBy = "",
                OV88_LastModifiedDate = "",
                OV05_TP_TN_FP_FN_Flag = "TRUE POSITIVE",
                OV06_overrideStatus = ""

            });
            ekyclist.Add(new eKYCValidate
            {
                eKYCType = "Address", //ekyctab:BIO/Address/ID/Contact/Employment/Income/Relationship
                DV01_lkbmdvIndex = "007",
                DV03_ruleID = "ADDRESS8",
                DV04_ruleName = "Incomplete or Invalid Address",
                DV05_ruleDescription = "Checks for incomplete or invalid address",
                DV07_passOrFail = "FAIL",
                DV09_recommendation = "Address Not Complete",
                NA03_expectedVariableName1 = "Presented Address",
                NA04_expectedVariableAttribute1 = "NO 26 SPG 73-15 JLN 49 PERUMAHAN NEGARA LAMBAK KANAN BC2315 BRUNEI",
                NA05_expectedVariableSource1 = "View Source",
                NA06_expectedVariableName2 = "",
                NA07_expectedVariableAttribute2 = "",
                NA08_expectedVariableSource2 = "",
                NA09_expectedVariableName3 = "",
                NA10_expectedVariableAttribute3 = "",
                NA11_expectedVariableSource3 = "",
                NA88_LastModifiedDate = "",
                OV03_overrideFlag = "YES",
                OV04_overrideRemark = "Verified Correct",
                OV87_UpdatedBy = "Rafhanah",
                OV88_LastModifiedDate = "30-NOV-21",
                OV05_TP_TN_FP_FN_Flag = "FALSE NEGATIVE",
                OV06_overrideStatus = "APPROVED"

            });

            /*ID*/
            ekyclist.Add(new eKYCValidate
            {
                eKYCType = "ID", //ekyctab:BIO/Address/ID/Contact/Employment/Income/Relationship
                DV01_lkbmdvIndex = "006",
                DV03_ruleID = "ID_VALIDATION53",
                DV04_ruleName = "RootName_X_DLName",
                DV05_ruleDescription = "Compare Root name against name in Driving License",
                DV07_passOrFail = "PASS",
                DV09_recommendation = "Verify the name in the driving license image",
                NA03_expectedVariableName1 = "",
                NA04_expectedVariableAttribute1 = "",
                NA05_expectedVariableSource1 = "",
                NA06_expectedVariableName2 = "",
                NA07_expectedVariableAttribute2 = "",
                NA08_expectedVariableSource2 = "",
                NA09_expectedVariableName3 = "",
                NA10_expectedVariableAttribute3 = "",
                NA11_expectedVariableSource3 = "",
                NA88_LastModifiedDate = "",
                OV03_overrideFlag = "",
                OV04_overrideRemark = "",
                OV87_UpdatedBy = "",
                OV88_LastModifiedDate = "",
                OV05_TP_TN_FP_FN_Flag = "TRUE POSITIVE",
                OV06_overrideStatus = "APPROVED"

            });
            ekyclist.Add(new eKYCValidate
            {
                eKYCType = "ID", //ekyctab:BIO/Address/ID/Contact/Employment/Income/Relationship
                DV01_lkbmdvIndex = "007",
                DV03_ruleID = "ID_VALIDATION51",
                DV04_ruleName = "RootID_X_DLNumberRule",
                DV05_ruleDescription = "Validating Root Driving License number against Driving License number",
                DV07_passOrFail = "FAIL",
                DV09_recommendation = "Verify the driving license number in the driving license image",
                NA03_expectedVariableName1 = "Expected Issue Date",
                NA04_expectedVariableAttribute1 = "23-OCT-2020",
                NA05_expectedVariableSource1 = "View Source",
                NA06_expectedVariableName2 = "ID Type",
                NA07_expectedVariableAttribute2 = "DRIVING LICENSE",
                NA08_expectedVariableSource2 = "View Source",
                NA09_expectedVariableName3 = "Driving License Issue Date",
                NA10_expectedVariableAttribute3 = "21-JAN-2020",
                NA11_expectedVariableSource3 = "View Source",
                NA88_LastModifiedDate = "",
                OV03_overrideFlag = "YES",
                OV04_overrideRemark = "Driving License Issue Date Not Match",
                OV87_UpdatedBy = "RIHANA",
                OV88_LastModifiedDate = "30-NOV-21",
                OV05_TP_TN_FP_FN_Flag = "TRUE NEGATIVE",
                OV06_overrideStatus = "APPROVED"

            });
            ekyclist.Add(new eKYCValidate
            {
                eKYCType = "ID", //ekyctab:BIO/Address/ID/Contact/Employment/Income/Relationship
                DV01_lkbmdvIndex = "008",
                DV03_ruleID = "ID_VALIDATION50",
                DV04_ruleName = "RootIssueDate_X_ICIssueDate Rule",
                DV05_ruleDescription = "Comparing root issue date against OCR issue Date",
                DV07_passOrFail = "FAIL",
                DV09_recommendation = "Verify the issue date in the driving license",
                NA03_expectedVariableName1 = "Expected Issue Date",
                NA04_expectedVariableAttribute1 = "23-OCT-2020",
                NA05_expectedVariableSource1 = "View Source",
                NA06_expectedVariableName2 = "ID Type",
                NA07_expectedVariableAttribute2 = "DRIVING LICENSE",
                NA08_expectedVariableSource2 = "View Source",
                NA09_expectedVariableName3 = "Driving License Issue Date",
                NA10_expectedVariableAttribute3 = "21-JAN-2020",
                NA11_expectedVariableSource3 = "View Source",
                NA88_LastModifiedDate = "",
                OV03_overrideFlag = "YES",
                OV04_overrideRemark = "Driving License Issue Date Not Match",
                OV87_UpdatedBy = "RIHANA",
                OV88_LastModifiedDate = "30-NOV-21",
                OV05_TP_TN_FP_FN_Flag = "TRUE NEGATIVE",
                OV06_overrideStatus = "APPROVED"

            });
            ekyclist.Add(new eKYCValidate
            {
                eKYCType = "ID", //ekyctab:BIO/Address/ID/Contact/Employment/Income/Relationship
                DV01_lkbmdvIndex = "009",
                DV03_ruleID = "ID_VALIDATION54",
                DV04_ruleName = "DL Expiry Date Rule",
                DV05_ruleDescription = "Validate Driving License Expiry Date with System Date",
                DV07_passOrFail = "FAIL",
                DV09_recommendation = "Please renew or get latest driving license",
                NA03_expectedVariableName1 = "Expected Issue Date",
                NA04_expectedVariableAttribute1 = "23-OCT-2020",
                NA05_expectedVariableSource1 = "View Source",
                NA06_expectedVariableName2 = "ID Type",
                NA07_expectedVariableAttribute2 = "DRIVING LICENSE",
                NA08_expectedVariableSource2 = "View Source",
                NA09_expectedVariableName3 = "Driving License Issue Date",
                NA10_expectedVariableAttribute3 = "21-JAN-2020",
                NA11_expectedVariableSource3 = "View Source",
                NA88_LastModifiedDate = "",
                OV03_overrideFlag = "YES",
                OV04_overrideRemark = "Driving License Issue Date Not Match",
                OV87_UpdatedBy = "RIHANA",
                OV88_LastModifiedDate = "30-NOV-21",
                OV05_TP_TN_FP_FN_Flag = "TRUE NEGATIVE",
                OV06_overrideStatus = "APPROVED"

            });

            /*Contact*/
            ekyclist.Add(new eKYCValidate
            {
                eKYCType = "Contact", //ekyctab:BIO/Address/ID/Contact/Employment/Income/Relationship
                DV01_lkbmdvIndex = "006",
                DV03_ruleID = "CONTACT4",
                DV04_ruleName = "Unique Mobile Phone",
                DV05_ruleDescription = "Validate if mobile phone number only link to one CIF",
                DV07_passOrFail = "FAIL",
                DV09_recommendation = "Please check the mobile number provided",
                NA03_expectedVariableName1 = "",
                NA04_expectedVariableAttribute1 = "",
                NA05_expectedVariableSource1 = "",
                NA06_expectedVariableName2 = "",
                NA07_expectedVariableAttribute2 = "",
                NA08_expectedVariableSource2 = "",
                NA09_expectedVariableName3 = "",
                NA10_expectedVariableAttribute3 = "",
                NA11_expectedVariableSource3 = "",
                NA88_LastModifiedDate = "",
                OV03_overrideFlag = "",
                OV04_overrideRemark = "",
                OV87_UpdatedBy = "",
                OV88_LastModifiedDate = "",
                OV05_TP_TN_FP_FN_Flag = "TRUE NEGATIVE",
                OV06_overrideStatus = ""

            });
            ekyclist.Add(new eKYCValidate
            {
                eKYCType = "Contact", //ekyctab:BIO/Address/ID/Contact/Employment/Income/Relationship
                DV01_lkbmdvIndex = "007",
                DV03_ruleID = "CONTACT5",
                DV04_ruleName = "Incomplete Phone No",
                DV05_ruleDescription = "Validating at least one phone number is present",
                DV07_passOrFail = "FAIL",
                DV09_recommendation = "Please provide phone number",
                NA03_expectedVariableName1 = "MOBILE NUMBER",
                NA04_expectedVariableAttribute1 = "8785628",
                NA05_expectedVariableSource1 = "View Source",
                NA06_expectedVariableName2 = "NAME",
                NA07_expectedVariableAttribute2 = "QAYS MATIN BIN HJ AWANG YAHYA",
                NA08_expectedVariableSource2 = "View Source",
                NA09_expectedVariableName3 = "NAME",
                NA10_expectedVariableAttribute3 = "IQBAL",
                NA11_expectedVariableSource3 = "View Source",
                NA88_LastModifiedDate = "",
                OV03_overrideFlag = "YES",
                OV04_overrideRemark = "Contacted the number, belongs to Qays Matin. Delink phone no to Deana.",
                OV87_UpdatedBy = "RIHANA",
                OV88_LastModifiedDate = "30-NOV-21",
                OV05_TP_TN_FP_FN_Flag = "TRUE NEGATIVE",
                OV06_overrideStatus = "APPROVED"

            });
            ekyclist.Add(new eKYCValidate
            {
                eKYCType = "Contact", //ekyctab:BIO/Address/ID/Contact/Employment/Income/Relationship
                DV01_lkbmdvIndex = "008",
                DV03_ruleID = "CONTACT6",
                DV04_ruleName = "Email x OTP",
                DV05_ruleDescription = "At least one OTP",
                DV07_passOrFail = "FAIL",
                DV09_recommendation = "Please verify the email by sending the verification link",
                NA03_expectedVariableName1 = "MOBILE NUMBER",
                NA04_expectedVariableAttribute1 = "8785628",
                NA05_expectedVariableSource1 = "View Source",
                NA06_expectedVariableName2 = "NAME",
                NA07_expectedVariableAttribute2 = "QAYS MATIN BIN HJ AWANG YAHYA",
                NA08_expectedVariableSource2 = "View Source",
                NA09_expectedVariableName3 = "NAME",
                NA10_expectedVariableAttribute3 = "IQBAL",
                NA11_expectedVariableSource3 = "View Source",
                NA88_LastModifiedDate = "",
                OV03_overrideFlag = "YES",
                OV04_overrideRemark = "Contacted the number, belongs to Qays Matin. Delink phone no to Deana.",
                OV87_UpdatedBy = "RIHANA",
                OV88_LastModifiedDate = "30-NOV-21",
                OV05_TP_TN_FP_FN_Flag = "TRUE NEGATIVE",
                OV06_overrideStatus = "APPROVED"

            });
            ekyclist.Add(new eKYCValidate
            {
                eKYCType = "Contact", //ekyctab:BIO/Address/ID/Contact/Employment/Income/Relationship
                DV01_lkbmdvIndex = "009",
                DV03_ruleID = "CONTACT7",
                DV04_ruleName = "Mobile x OTP",
                DV05_ruleDescription = "Validating at least one phone number is present",
                DV07_passOrFail = "FAIL",
                DV09_recommendation = "Please verify the mobile number by requesting OTP",
                NA03_expectedVariableName1 = "MOBILE NUMBER",
                NA04_expectedVariableAttribute1 = "8785628",
                NA05_expectedVariableSource1 = "View Source",
                NA06_expectedVariableName2 = "NAME",
                NA07_expectedVariableAttribute2 = "QAYS MATIN BIN HJ AWANG YAHYA",
                NA08_expectedVariableSource2 = "View Source",
                NA09_expectedVariableName3 = "NAME",
                NA10_expectedVariableAttribute3 = "IQBAL",
                NA11_expectedVariableSource3 = "View Source",
                NA88_LastModifiedDate = "",
                OV03_overrideFlag = "YES",
                OV04_overrideRemark = "Contacted the number, belongs to Qays Matin. Delink phone no to Deana.",
                OV87_UpdatedBy = "RIHANA",
                OV88_LastModifiedDate = "30-NOV-21",
                OV05_TP_TN_FP_FN_Flag = "TRUE NEGATIVE",
                OV06_overrideStatus = "APPROVED"

            });

            /*Employment*/
            ekyclist.Add(new eKYCValidate
            {
                eKYCType = "Employment", //ekyctab:BIO/Address/ID/Contact/Employment/Income/Relationship
                DV01_lkbmdvIndex = "009",
                DV03_ruleID = "EMPLOYMENT17",
                DV04_ruleName = "Vocation is Present",
                DV05_ruleDescription = "Check Employment Sector is Not Missing or Expired",
                DV07_passOrFail = "FAIL",
                DV09_recommendation = "Please update latest employment status",
                NA03_expectedVariableName1 = "Employment Sector",
                NA04_expectedVariableAttribute1 = "MISSING",
                NA05_expectedVariableSource1 = "View Source",
                NA06_expectedVariableName2 = "End Date",
                NA07_expectedVariableAttribute2 = "NULL",
                NA08_expectedVariableSource2 = "View Source",
                NA09_expectedVariableName3 = "",
                NA10_expectedVariableAttribute3 = "",
                NA11_expectedVariableSource3 = "",
                NA88_LastModifiedDate = "",
                OV03_overrideFlag = "YES",
                OV04_overrideRemark = "At Least One Valid Employment Record Present",
                OV87_UpdatedBy = "RIHANA",
                OV88_LastModifiedDate = "30-NOV-21",
                OV05_TP_TN_FP_FN_Flag = "TRUE NEGATIVE",
                OV06_overrideStatus = "APPROVED"

            });
            ekyclist.Add(new eKYCValidate
            {
                eKYCType = "Employment", //ekyctab:BIO/Address/ID/Contact/Employment/Income/Relationship
                DV01_lkbmdvIndex = "010",
                DV03_ruleID = "EMPLOYMENT17",
                DV04_ruleName = "Army ID vs Employment",
                DV05_ruleDescription = "Check for army ID or employment details",
                DV07_passOrFail = "FAIL",
                DV09_recommendation = "Please upload ID or update employment details",
                NA03_expectedVariableName1 = "Employment Sector",
                NA04_expectedVariableAttribute1 = "MISSING",
                NA05_expectedVariableSource1 = "View Source",
                NA06_expectedVariableName2 = "End Date",
                NA07_expectedVariableAttribute2 = "NULL",
                NA08_expectedVariableSource2 = "View Source",
                NA09_expectedVariableName3 = "",
                NA10_expectedVariableAttribute3 = "",
                NA11_expectedVariableSource3 = "",
                NA88_LastModifiedDate = "",
                OV03_overrideFlag = "YES",
                OV04_overrideRemark = "At Least One Valid Employment Record Present",
                OV87_UpdatedBy = "RIHANA",
                OV88_LastModifiedDate = "30-NOV-21",
                OV05_TP_TN_FP_FN_Flag = "TRUE NEGATIVE",
                OV06_overrideStatus = "APPROVED"

            });
            ekyclist.Add(new eKYCValidate
            {
                eKYCType = "Employment", //ekyctab:BIO/Address/ID/Contact/Employment/Income/Relationship
                DV01_lkbmdvIndex = "011",
                DV03_ruleID = "EMPLOYMENT17",
                DV04_ruleName = "Unemployed and No Income Credited",
                DV05_ruleDescription = "Check Employment Sector = “UNEMPLOYED”",
                DV07_passOrFail = "FAIL",
                DV09_recommendation = "Please update latest employment status",
                NA03_expectedVariableName1 = "Employment Sector",
                NA04_expectedVariableAttribute1 = "MISSING",
                NA05_expectedVariableSource1 = "View Source",
                NA06_expectedVariableName2 = "End Date",
                NA07_expectedVariableAttribute2 = "NULL",
                NA08_expectedVariableSource2 = "View Source",
                NA09_expectedVariableName3 = "",
                NA10_expectedVariableAttribute3 = "",
                NA11_expectedVariableSource3 = "",
                NA88_LastModifiedDate = "",
                OV03_overrideFlag = "YES",
                OV04_overrideRemark = "At Least One Valid Employment Record Present",
                OV87_UpdatedBy = "RIHANA",
                OV88_LastModifiedDate = "30-NOV-21",
                OV05_TP_TN_FP_FN_Flag = "TRUE NEGATIVE",
                OV06_overrideStatus = "APPROVED"

            });
            ekyclist.Add(new eKYCValidate
            {
                eKYCType = "Employment", //ekyctab:BIO/Address/ID/Contact/Employment/Income/Relationship
                DV01_lkbmdvIndex = "012",
                DV03_ruleID = "EMPLOYMENT17",
                DV04_ruleName = "Age > 60 and Pension",
                DV05_ruleDescription = "Check Age > “60” but Employment Status <> PENSION",
                DV07_passOrFail = "FAIL",
                DV09_recommendation = "Please update pension status",
                NA03_expectedVariableName1 = "Employment Sector",
                NA04_expectedVariableAttribute1 = "MISSING",
                NA05_expectedVariableSource1 = "View Source",
                NA06_expectedVariableName2 = "End Date",
                NA07_expectedVariableAttribute2 = "NULL",
                NA08_expectedVariableSource2 = "View Source",
                NA09_expectedVariableName3 = "",
                NA10_expectedVariableAttribute3 = "",
                NA11_expectedVariableSource3 = "",
                NA88_LastModifiedDate = "",
                OV03_overrideFlag = "YES",
                OV04_overrideRemark = "At Least One Valid Employment Record Present",
                OV87_UpdatedBy = "RIHANA",
                OV88_LastModifiedDate = "30-NOV-21",
                OV05_TP_TN_FP_FN_Flag = "TRUE NEGATIVE",
                OV06_overrideStatus = "APPROVED"

            });

            /*INCOME*/
            ekyclist.Add(new eKYCValidate
            {
                eKYCType = "Income", //ekyctab:BIO/Address/ID/Contact/Employment/Income/Relationship
                DV01_lkbmdvIndex = "009",
                DV03_ruleID = "INCOME01",
                DV04_ruleName = "Pension vs Employment Sector",
                DV05_ruleDescription = "Check Pension Income vs Employment Sector",
                DV07_passOrFail = "FAIL",
                DV09_recommendation = "Please update pension status",
                NA03_expectedVariableName1 = "Total Monthly Income",
                NA04_expectedVariableAttribute1 = "$800.00",
                NA05_expectedVariableSource1 = "View Source",
                NA06_expectedVariableName2 = "Current Employment Sector",
                NA07_expectedVariableAttribute2 = "CIVILIAN PUBLIC SECTOR",
                NA08_expectedVariableSource2 = "View Source",
                NA09_expectedVariableName3 = "",
                NA10_expectedVariableAttribute3 = "",
                NA11_expectedVariableSource3 = "",
                NA88_LastModifiedDate = "",
                OV03_overrideFlag = "YES",
                OV04_overrideRemark = "Verify customer Income",
                OV87_UpdatedBy = "RIHANA",
                OV88_LastModifiedDate = "30-NOV-21",
                OV05_TP_TN_FP_FN_Flag = "TRUE NEGATIVE",
                OV06_overrideStatus = "APPROVED"

            });

            ekyclist.Add(new eKYCValidate
            {
                eKYCType = "Income", //ekyctab:BIO/Address/ID/Contact/Employment/Income/Relationship
                DV01_lkbmdvIndex = "010",
                DV03_ruleID = "INCOME01",
                DV04_ruleName = "Income is Present",
                DV05_ruleDescription = "Check Salary Credited in the Last 45 Days",
                DV07_passOrFail = "FAIL",
                DV09_recommendation = "Please validate if still employed",
                NA03_expectedVariableName1 = "Total Monthly Income",
                NA04_expectedVariableAttribute1 = "$800.00",
                NA05_expectedVariableSource1 = "View Source",
                NA06_expectedVariableName2 = "Current Employment Sector",
                NA07_expectedVariableAttribute2 = "CIVILIAN PUBLIC SECTOR",
                NA08_expectedVariableSource2 = "View Source",
                NA09_expectedVariableName3 = "",
                NA10_expectedVariableAttribute3 = "",
                NA11_expectedVariableSource3 = "",
                NA88_LastModifiedDate = "",
                OV03_overrideFlag = "YES",
                OV04_overrideRemark = "Verify customer Income",
                OV87_UpdatedBy = "RIHANA",
                OV88_LastModifiedDate = "30-NOV-21",
                OV05_TP_TN_FP_FN_Flag = "TRUE NEGATIVE",
                OV06_overrideStatus = "APPROVED"

            });

            ekyclist.Add(new eKYCValidate
            {
                eKYCType = "Income", //ekyctab:BIO/Address/ID/Contact/Employment/Income/Relationship
                DV01_lkbmdvIndex = "011",
                DV03_ruleID = "INCOME01",
                DV04_ruleName = "Check for Salary Income Supporting Document",
                DV05_ruleDescription = "Check Supporting Document for Manual Input Salary Income",
                DV07_passOrFail = "FAIL",
                DV09_recommendation = "Please submit salary payslip or account statement",
                NA03_expectedVariableName1 = "Total Monthly Income",
                NA04_expectedVariableAttribute1 = "$800.00",
                NA05_expectedVariableSource1 = "View Source",
                NA06_expectedVariableName2 = "Current Employment Sector",
                NA07_expectedVariableAttribute2 = "CIVILIAN PUBLIC SECTOR",
                NA08_expectedVariableSource2 = "View Source",
                NA09_expectedVariableName3 = "",
                NA10_expectedVariableAttribute3 = "",
                NA11_expectedVariableSource3 = "",
                NA88_LastModifiedDate = "",
                OV03_overrideFlag = "YES",
                OV04_overrideRemark = "Verify customer Income",
                OV87_UpdatedBy = "RIHANA",
                OV88_LastModifiedDate = "30-NOV-21",
                OV05_TP_TN_FP_FN_Flag = "TRUE NEGATIVE",
                OV06_overrideStatus = "APPROVED"

            });

            ekyclist.Add(new eKYCValidate
            {
                eKYCType = "Income", //ekyctab:BIO/Address/ID/Contact/Employment/Income/Relationship
                DV01_lkbmdvIndex = "012",
                DV03_ruleID = "INCOME01",
                DV04_ruleName = "Check for Pension Income Supporting Document",
                DV05_ruleDescription = "Check Supporting Document for Manual Input Pension Income",
                DV07_passOrFail = "FAIL",
                DV09_recommendation = "Please submit pension confirmation slip or account statement",
                NA03_expectedVariableName1 = "Total Monthly Income",
                NA04_expectedVariableAttribute1 = "$800.00",
                NA05_expectedVariableSource1 = "View Source",
                NA06_expectedVariableName2 = "Current Employment Sector",
                NA07_expectedVariableAttribute2 = "CIVILIAN PUBLIC SECTOR",
                NA08_expectedVariableSource2 = "View Source",
                NA09_expectedVariableName3 = "",
                NA10_expectedVariableAttribute3 = "",
                NA11_expectedVariableSource3 = "",
                NA88_LastModifiedDate = "",
                OV03_overrideFlag = "YES",
                OV04_overrideRemark = "Verify customer Income",
                OV87_UpdatedBy = "RIHANA",
                OV88_LastModifiedDate = "30-NOV-21",
                OV05_TP_TN_FP_FN_Flag = "TRUE NEGATIVE",
                OV06_overrideStatus = "APPROVED"

            });

            /*Relationship*/
            ekyclist.Add(new eKYCValidate
            {
                eKYCType = "Relationship", //ekyctab:BIO/Address/ID/Contact/Employment/Income/Relationship
                DV01_lkbmdvIndex = "009",
                DV03_ruleID = "RELATIONSHIP1",
                DV04_ruleName = "Presented Address",
                DV05_ruleDescription = "Missing CIF Relationship",
                DV07_passOrFail = "FAIL",
                DV09_recommendation = "Checks for same address but no relationship define",
                NA03_expectedVariableName1 = "Presented Address",
                NA04_expectedVariableAttribute1 = "NO 26 SPG 73-15 JLN 49 PERUMAHAN NEGARA LAMBAK KANAN BC2315 BRUNEI",
                NA05_expectedVariableSource1 = "View Source",
                NA06_expectedVariableName2 = "Name",
                NA07_expectedVariableAttribute2 = "QAYS MATIN BIN HAJI AWANG YAHYA",
                NA08_expectedVariableSource2 = "View Source",
                NA09_expectedVariableName3 = "",
                NA10_expectedVariableAttribute3 = "",
                NA11_expectedVariableSource3 = "",
                NA88_LastModifiedDate = "",
                OV03_overrideFlag = "YES",
                OV04_overrideRemark = "Verify customer Income",
                OV87_UpdatedBy = "RIHANA",
                OV88_LastModifiedDate = "30-NOV-21",
                OV05_TP_TN_FP_FN_Flag = "TRUE NEGATIVE",
                OV06_overrideStatus = "APPROVED"

            });

            return View(ekyclist);
        }

        public IActionResult eKYCDetailBIO(string cfcustomer)
        {

            try
            {
                var items = JsonConvert.DeserializeObject<CFCustomer>(cfcustomer);             
                return PartialView(items);
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }

        public IActionResult eKYCDetailAddress(string cfcustomer)
        {
            try
            {
                var items = JsonConvert.DeserializeObject<CFCustomer>(cfcustomer);
                return PartialView(items);
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }

        public IActionResult eKYCDetailID()
        {
            return PartialView();
        }

        public IActionResult eKYCDetailContact(string cfcustomer)
        {
            try
            {
                var items = JsonConvert.DeserializeObject<CFCustomer>(cfcustomer);
                return PartialView(items);
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }

        public IActionResult eKYCDetailEmployment(string cfcustomer)
        {
            try
            {
                var items = JsonConvert.DeserializeObject<CFCustomer>(cfcustomer);
                return PartialView(items);
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
            
        }

        public IActionResult eKYCDetailIncome(string cfcustomer)
        {
            try
            {
                var items = JsonConvert.DeserializeObject<CFCustomer>(cfcustomer);
                return PartialView(items);
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }

        public IActionResult eKYCDetailRelationship(string cfcustomer)
        {
            try
            {
                var items = JsonConvert.DeserializeObject<CFCustomer>(cfcustomer);
                return PartialView(items);
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }

        public IActionResult eKYCDetailListVerification(string type, string ekycid, string ekycvalidate)
        {
            try
            {
                var item = new eKYCValidate();
                var ekycitems = JsonConvert.DeserializeObject<List<eKYCValidate>>(ekycvalidate).ToList();

                item = ekycitems.Where(item => item.DV01_lkbmdvIndex == ekycid && item.eKYCType == type).SingleOrDefault();

                ViewBag.type = type;

                return PartialView(item);
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }


        }
        public IActionResult eKYCRegisteredHistory()
        {
            return PartialView();
        }

        public IActionResult eKYCOTPHistory()
        {
            return PartialView();
        }

        public IActionResult VueJSSample()
        {
            return View();
        }

    }
}
