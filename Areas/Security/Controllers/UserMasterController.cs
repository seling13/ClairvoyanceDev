using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneFin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OneFin.Struct;
using PagedList;
using Microsoft.AspNetCore.Authorization;

namespace OneFin.Areas.Security.Controllers
{

    [Authorize]
    [Area("Security")]
    public class UserMasterController : Controller
    {

        private readonly IdentityDbContext _context;
        private readonly UserManager<Users> _userManager;


        public UserMasterController(IdentityDbContext context, UserManager<Users> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewBag.CurrentSort = sortOrder;


            var students = from s in _context.Users
                           select s;

            var usersroles =  (from user in _context.Users
                                    join userRoles in _context.UserRoles on user.Id equals userRoles.UserId
                                    join role in _context.Roles on userRoles.RoleId equals role.Id
                                    select new UserMaster { UserName = user.UserName, FullName = user.FullName, Email = user.Email, Role = role.Name, RoleName = role.NormalizedName, CreateDate = user.CreateDate })
                                 .AsNoTracking()
                                 .AsQueryable();
            
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                usersroles = usersroles.Where(s => s.FullName.Contains(searchString));
            }

            int pageSize = 8;
            return View(await PaginatedList<UserMaster>.CreateAsync(usersroles.AsNoTracking(), pageNumber ?? 1, pageSize));
 

        }

        public IActionResult ChangeRole(string username, string CurrentRole)
        {
            if (username == null)
            {
                return NotFound();
            }
            var items = _context.Roles.ToList();
            if (items != null)
            {
                ViewBag.data = items;
            }
            var usersroles = (from user in _context.Users.Where(item => item.UserName == username)
                              join userRoles in _context.UserRoles on user.Id equals userRoles.UserId
                              join role in _context.Roles.Where(item => item.NormalizedName == CurrentRole) on userRoles.RoleId equals role.Id
                              select new UserMaster { UserName = user.UserName, FullName = user.FullName, Email = user.Email, Role = role.Name, RoleName = role.NormalizedName, CreateDate = user.CreateDate })
                     .FirstOrDefault();

            //var optMaster = await _context.OptMaster
            //    .FirstOrDefaultAsync(m => m.OptName == optname && m.Value == value);
            //if (optMaster == null)
            //{
            //    return NotFound();
            //}

            return  View(usersroles);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeRole(string username, string rolename, [Bind("UserName,RoleName")] UserMaster usermaster)
        {
            if (username != usermaster.UserName)
            {
                return NotFound();
            }


                if (ModelState.IsValid)
            {
                //var users = new Users()
                //{
                //    UserName = username
                //};

                var currentrole = (from user in _context.Users.Where(item => item.UserName == username)
                                    join userRoles in _context.UserRoles on user.Id equals userRoles.UserId
                                    join role in _context.Roles on userRoles.RoleId equals role.Id
                                    select new UserMaster { UserName = user.UserName, FullName = user.FullName, Email = user.Email, Role = role.Name, RoleName = role.NormalizedName, CreateDate = user.CreateDate })
                     .FirstOrDefault();

                var users = await _userManager.FindByNameAsync(username);
                var roles = await _userManager.GetRolesAsync(users);
                var userResult = await _userManager.RemoveFromRoleAsync(users, currentrole.RoleName);
                userResult = await _userManager.AddToRoleAsync(users, rolename);

                return RedirectToAction(nameof(Index));
            }
            return View(usermaster);
        }

    }
}
