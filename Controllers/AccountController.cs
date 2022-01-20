using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneFin.Models;
using Microsoft.AspNetCore.Authorization;
using OneFin.Struct.CommonService;
using LamarCodeGeneration.Frames;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace OneFin.Controllers
{

    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _db;

        public AccountController(IMapper mapper, AppDbContext context, UserManager<Users> userManager, SignInManager<Users> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _db = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        //[ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Validate(LoginInput loginInput)
        {

            LoginOutput loginOutput = new LoginOutput();

            //loginOutput = CommonService.Login(loginInput, _db);

            //Remark without database
            //var result = await _signInManager.PasswordSignInAsync(loginInput.userName, loginInput.password, false, false);
            var result = false;
            if (loginInput.userName == "CM0001" && loginInput.password=="Abc_123")
                {
                result = true;
            }

            if (result)
            {
                HttpContext.Session.SetString("username", loginInput.userName);
                //var identity = new ClaimsIdentity(new[] {
                //    new Claim(ClaimTypes.Name,  loginInput.userName),
                //    new Claim(ClaimTypes.Role, "Visitor")
                //}, CookieAuthenticationDefaults.AuthenticationScheme);

                //var principal = new ClaimsPrincipal(identity);

                //var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                //return Json(new { status = true, message = "Login Successfull!" });
                //var users = await _userManager.FindByNameAsync(loginInput.userName);
                //var roles = await _userManager.GetRolesAsync(users);

                return RedirectToAction("eKYCSearch", "eKYC", new { area = "Clairvoyance" });
            }
            else
            {

                TempData["error"] = "Invalid Username or Password!";
                return RedirectToAction("Login", "Account");
                // return Json(new { status = false, message = "Invalid Username or Password!" });
            }
            //var _admin = _db.UserMaster.Where(s => s.UserName == loginInput.userName);
            //if (_admin.Any())
            //{


            // var result = _userManager.CreateAsync(user, Input.Password);


            //     if ( loginInput.password =="Abc_123")
            //     {              

            //         return Json(new { status = true, message = "Login Successfull!" });
            //
            //     }
            //     else
            //     {
            //         return Json(new { status = false, message = "Invalid Password!" });
            //     }
            // }
            // else
            // {
            //    return Json(new { status = false, message = "Invalid Email!" });
            // }
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            var items = _db.AspNetRoles.ToList();
            if (items != null)
            {
                ViewBag.data = items;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterInput userModel)
        {
            //Users users = new Users();
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }

            //var user = _mapper.Map<User>(userModel);
            var users = new Users()
            {
                UserName = userModel.Username,
                FullName = userModel.FullName,
                Email = userModel.Email,
                lastlogin = DateTime.Now,
                CreateDate = DateTime.Now
            };

            var result = await _userManager.CreateAsync(users, userModel.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View(); ;
            }

            //await _userManager.AddToRoleAsync(user, "Visitor");

            IdentityResult roleResult;
            bool adminRoleExists = await _roleManager.RoleExistsAsync(userModel.UserRole);
            if (!adminRoleExists)
            {
                roleResult = await _roleManager.CreateAsync(new IdentityRole(userModel.UserRole));
            }

            // Select the user, and then add the admin role to the user
            if (!await _userManager.IsInRoleAsync(users, userModel.UserRole))
            {
                var userResult = await _userManager.AddToRoleAsync(users, userModel.UserRole);
            }


            TempData["success"] = "User Created Successfully";
            return RedirectToAction(nameof(AccountController.Login), "Account");
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("username");
            //var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await _signInManager.SignOutAsync();

            return RedirectToAction("login", "Account"); ;
        }

    }
}
