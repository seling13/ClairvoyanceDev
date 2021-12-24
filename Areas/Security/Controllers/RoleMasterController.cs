using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OneFin.Models;

namespace OneFin.Areas.Security.Controllers
{
    [Authorize]
    [Area("Security")]

    //[Authorize(Roles = "Visitor")]

    //[RoleAuthorize("RolesMaster")]

    public class RoleMasterController : Controller
    {


        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;

        public RoleMasterController(AppDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        // GET: Security/Roles
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewBag.CurrentSort = sortOrder;
            var aspnetroles = from m in _context.AspNetRoles
                              
                              select m;

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
                aspnetroles = aspnetroles.Where(s => s.NormalizedName.Contains(searchString));
            }

            aspnetroles.OrderBy(s => s.Name);

            //return View(await _context.OptMaster.ToListAsync());
            int pageSize = 8;
            return View(await PaginatedList<Roles>.CreateAsync(aspnetroles.AsNoTracking(), pageNumber ?? 1, pageSize));

            //return View(await _context.AspNetRoles.ToListAsync());
        }

        // GET: Security/Roles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roles = await _context.AspNetRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roles == null)
            {
                return NotFound();
            }

            return View(roles);
        }

        // GET: Security/Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Security/Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("Id,Name,NormalizedName,ConcurrencyStamp")] Roles roles)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(roles);
                //await _context.SaveChangesAsync();
                IdentityResult roleResult;
                bool adminRoleExists = await _roleManager.RoleExistsAsync(roles.Name);
                if (!adminRoleExists)
                {
                    roleResult = await _roleManager.CreateAsync(new IdentityRole(roles.Name));
                }


                return RedirectToAction(nameof(Index));
            }
            return View(roles);
        }

        // GET: Security/Roles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roles = await _context.AspNetRoles.FindAsync(id);
            if (roles == null)
            {
                return NotFound();
            }
            return View(roles);
        }

        // POST: Security/Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,NormalizedName,ConcurrencyStamp")] Roles roles)
        {
            if (id != roles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolesExists(roles.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(roles);
        }

        // GET: Security/Roles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roles = await _context.AspNetRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roles == null)
            {
                return NotFound();
            }

            return View(roles);
        }

        // POST: Security/Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var roles = await _context.AspNetRoles.FindAsync(id);
            _context.AspNetRoles.Remove(roles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolesExists(string id)
        {
            return _context.AspNetRoles.Any(e => e.Id == id);
        }
    }
}
