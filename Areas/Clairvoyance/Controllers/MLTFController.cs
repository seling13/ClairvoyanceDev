using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using OneFin.Models;
using Newtonsoft.Json;

namespace OneFin.Areas.Clairvoyance.Controllers
{
    [Area("Clairvoyance")]
    public class MLTFController : Controller
    {
        private readonly AppDbContext _context;
        public MLTFController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MLTFUNXML(string type, string searchname)
        {
            List<UNList> unlists = new List<UNList>();
            try
            {

                if (type == "XML") 
                {
                    XDocument xdoc = XDocument.Load("https://scsanctions.un.org/resources/xml/en/consolidated.xml");



                    unlists = xdoc.Descendants("CONSOLIDATED_LIST").Descendants("INDIVIDUALS").Descendants("INDIVIDUAL").Select(item => new UNList()
                    {
                        ID = Utility.GetUniqueId(),
                        FIRST_NAME = (string)item.Element("FIRST_NAME").Value ?? String.Empty,
                        SECOND_NAME = item.Element("SECOND_NAME") != null ? item.Element("SECOND_NAME").Value : String.Empty,
                        DESIGNATION = (item.Element("DESIGNATION") != null ? item.Element("DESIGNATION").Value : String.Empty).Replace('\n', ' ').Replace('"', ' '),
                        NATIONALITY = (item.Element("NATIONALITY") != null ? item.Element("NATIONALITY").Value : String.Empty).Replace(System.Environment.NewLine, " "),
                        INDIVIDUAL_ALIAS = (string.Concat(item.Elements("INDIVIDUAL_ALIAS").Select(x => x.Element("QUALITY").Value != "" ? x.Element("QUALITY").Value +
                          ": " + x.Element("ALIAS_NAME").Value + "; " : "")
                        .ToArray())).Replace('\n', ' ').Replace('"', ' '),
                        LAST_DAY_UPDATED = item.Element("LAST_DAY_UPDATED") != null ? item.Element("LAST_DAY_UPDATED").Value : String.Empty

                    }).ToList();
                    ViewBag.type = "XML";
                }
                else {
                    ViewBag.type = "Search";

                    unlists =  _context.UNlist.Where(item => 
                    item.INDIVIDUAL_ALIAS.Contains(searchname) || 
                    item.FIRST_NAME.Contains(searchname) ||
                     item.SECOND_NAME.Contains(searchname) ||
                     item.THIRD_NAME.Contains(searchname) ||
                     item.FOURTH_NAME.Contains(searchname)
                    ).ToList(); 
                }

                if (unlists.Count == 0)
                {
                    return Json(new { status = false, message = "Record Not Found" });
                }
                else
                    return PartialView(unlists);


                //foreach (var items in temp)
                //{
                //    var names = "";
                //    var unlist = new UNList();
                //    foreach (var INDIVIDUAL_ALIAS in items.INDIVIDUAL_ALIASs)
                //    {
                //        foreach (var name in INDIVIDUAL_ALIAS.Elements("ALIAS_NAME"))
                //        {
                //               names += name.Value + " \n";
                //        }
                //    }
                //   unlist.FIRST_NAME = items.FIRST_NAME;
                //   unlist.SECOND_NAME = items.SECOND_NAME;
                //   unlist.NATIONALITY = items.NATIONALITY;
                //   unlist.INDIVIDUAL_ALIAS = names;

                // unlists.Add(unlist);

                //}
                //ar view = items.ToList();
                //return Json(new { status = true, message = "", view = PartialView(temp) });

            }
            catch (Exception ex)
            {
                return Json(new { status = false,message = ex.Message });
            }
        }

        public IActionResult MLTFUNListAdd(string _unlist )
        {
            try
            {
                var items = JsonConvert.DeserializeObject<List<UNList>>(_unlist);

                //IEnumerable<UNList> delunlist = _context.UNlist.ToList();

                _context.UNlist.RemoveRange(_context.UNlist.ToList());

                foreach (var unlist in items)
                {
                    _context.Add(unlist);
                    _context.SaveChanges();
                }


                return Json(new {status =true, message = "UN Consolidate list added to Database" });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }

                public IActionResult MLTFUNIndex()
        {
            return View();
        }
    }
}
