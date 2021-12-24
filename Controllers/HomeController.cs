using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OneFin.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using OneFin.Struct.Dashboard;

namespace OneFin.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IdentityDbContext _dbIdentity;


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, AppDbContext context, IdentityDbContext dbIdentity)
        {
            _logger = logger;
            _db = context;
            _dbIdentity = dbIdentity;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexBV()
        {
            return View();
        }

        public IActionResult IndexBVeKYC()
        {
            return PartialView();
        }

        public IActionResult IndexBVMLTF()
        {
            return PartialView();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult UnAuthorized()
        {
            TempData["error"] = "UnAuthorized Access";
            return View();
            //return RedirectToAction("Index", "Home"); ;
        }

        public IActionResult Message(string type, string message)
        {
            ViewBag.type = type; //I-infor, E-error
            ViewBag.message = message;
            return PartialView();
        
        }
    }
}
