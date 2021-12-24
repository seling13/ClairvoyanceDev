using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneFin.Models;
using System.Data.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace OneFin.Controllers
{
    public class OptListController : Controller
    {
        private readonly AppDbContext _db;

        public OptListController(AppDbContext context)
        {
            _db = context;
        }

        public IActionResult GetOptList(string OptName)
        {
            var position = OptName;
            var optMasters = from m in _db.OptMaster
                             select m;

            optMasters = optMasters.Where(s => s.OptName.Contains(OptName));

            List<OptMaster> li = new List<OptMaster>();
            li =  optMasters.ToList();
            ViewBag.listofitems = li;

            //return View();

            //List<SelectListItem> drop = new List<SelectListItem>
            //{
            //    new SelectListItem{Value="Superman",Text="Superman"},
            //     new SelectListItem{Value="Batman",Text="Batman"},
            //      new SelectListItem{Value="Wonderwoman",Text="Wonderwoman"}
            //};
            //string json = JsonConvert.SerializeObject(li, Formatting.Indented);
            return Json(new { status = true, data = li });

            }
    }
}
