using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OneFin.Models;
using OneFin.Struct;

namespace OneFin
{
        // or inject it
        public class RoleAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
        {

        private string _filter;

        public RoleAuthorizeAttribute(string filter)
        {
            _filter = filter;
            //_userManager = userManager;
        }


        public void OnAuthorization(AuthorizationFilterContext context )
        {

            var _icontext = context.HttpContext.RequestServices.GetRequiredService<IdentityDbContext>();
            var _context = context.HttpContext.RequestServices.GetRequiredService<AppDbContext>();
            //Custom code ...
            //var username = context.HttpContext.User.Identity.Name;
            //var user =  _userManager.FindByIdAsync(username);
            //var roles = _userManager.GetRolesAsync(user).FirstOrDefault;

            //var user = await _userManager.FindAsync(EmailID, Password);
            //string rolename = await _userManager.GetRoles(user.Id).FirstOrDefault();
            string usr = context.HttpContext.User.Identity.Name;
            var usersroles = (from user in _icontext.Users.Where(item => item.UserName == usr)
                                               join userRoles in _icontext.UserRoles on user.Id equals userRoles.UserId
                                               join role in _icontext.Roles on userRoles.RoleId equals role.Id
                                               select new Struct.UserMaster { UserName = user.UserName, Email = user.Email, Role = role.Name }).Single().Role;

            var access =_context.TransactionMaster.Where(x => x.Role == usersroles && x.TransactionName == _filter);
            //var userId = _context.Users.Where(item => item.UserName == usr).Single().Id;
            //var uroles = _context.Roles.ToList();


            if (!access.Any())
            {
                //actionContext.Response = new HttpResponseMessage((HttpStatusCode)401) { ReasonPhrase = "Unauthorized user" }

                //context.Result = new RedirectResult("/Home/index");
                //TempData["message"] = "User Created Successfully";

                context.Result = new RedirectToActionResult("UnAuthorized", "Home", new { area = "" });
                //context.Result = new RedirectToRouteResult(
                //new RouteValueDictionary
                //{
                //     { "controller", "Home" },
                //     { "action", "UnAuthorized" }
                //});

                //Return based on logic
                //context.Result = new UnauthorizedResult();
            }

        }
        }
}
