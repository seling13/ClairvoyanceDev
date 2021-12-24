using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OneFin.Models;
using Microsoft.AspNetCore.Authorization;
using PagedList;

namespace OneFin.Controllers
{
    [Area("Security")]
    //[Authorize(Roles = "Visitor")]
    public class UserMasterv1Controller : Controller
    {
        private readonly AppDbContext _context;

        public UserMasterv1Controller(AppDbContext context)
        {
            _context = context;
        }

        // GET: UserMaster
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewBag.CurrentSort = sortOrder;
            var userMaster = from m in _context.UserMaster
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
                userMaster = userMaster.Where(s => s.FullName.Contains(searchString));
            }


            //List<OptMaster> li = new List<OptMaster>();
            //li = await _context.OptMaster.Where(s => s.OptName == "PositionCode").ToListAsync();
            //ViewBag.listofitems = li;


            var optMasters = from m in _context.OptMaster
                         select m;

            optMasters = optMasters.Where(s => s.OptName.Contains("PositionCode"));

            List<OptMasterV1> li = new List<OptMasterV1>();
            li = await optMasters.ToListAsync();
            ViewBag.listofitems = li;



            int pageSize = 8;
            return View(await PaginatedList<UserMasterV1>.CreateAsync(userMaster.AsNoTracking(), pageNumber ?? 1, pageSize));
            //return View(userMaster.ToPagedList(pageNumber, pageSize));

            //return View(await userMaster.ToListAsync());

            //return View(await _context.UserMaster.ToListAsync());


        }

        // GET: UserMaster/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userMaster = await _context.UserMaster
                .FirstOrDefaultAsync(m => m.ID == id);
            if (userMaster == null)
            {
                return NotFound();
            }

            return View(userMaster);
        }

        // GET: UserMaster/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserMaster/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserName,FullName,PositionCode,Email,LastLoginDate,LastLoginTime")] UserMasterV1 userMaster)
        {

            if (ModelState.IsValid)
            {
                _context.Add(userMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(userMaster);
        }

        // GET: UserMaster/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userMaster = await _context.UserMaster.FindAsync(id);
            if (userMaster == null)
            {
                return NotFound();
            }
            return View(userMaster);
        }

        // POST: UserMaster/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,UserName,FullName,PositionCode,Email,LastLoginDate,LastLoginTime")] UserMasterV1 userMaster)
        {
            if (id != userMaster.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserMasterExists(userMaster.ID))
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
            return View(userMaster);
        }

        // GET: UserMaster/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userMaster = await _context.UserMaster
                .FirstOrDefaultAsync(m => m.ID == id);
            if (userMaster == null)
            {
                return NotFound();
            }

            return View(userMaster);
        }

        // POST: UserMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var userMaster = await _context.UserMaster.FindAsync(id);
            _context.UserMaster.Remove(userMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserMasterExists(string id)
        {
            return _context.UserMaster.Any(e => e.ID == id);
        }
    }

}
