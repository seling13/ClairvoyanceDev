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
    //[Authorize(Roles = "Admin,"")]
    [Authorize]
    [Area("Configuration")]

    public class OptMasterController : Controller
    {
        private readonly AppDbContext _context;

        public OptMasterController(AppDbContext context)
        {
            _context = context;
        }

        // GET: OptMaster
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewBag.CurrentSort = sortOrder;
            var optMaster = from m in _context.OptMaster
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
                optMaster = optMaster.Where(s => s.OptName.Contains(searchString));
            }


            //return View(await _context.OptMaster.ToListAsync());
            int pageSize = 8;
            return View(await PaginatedList<OptMaster>.CreateAsync(optMaster.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        // GET: OptMaster/Details/5
        public async Task<IActionResult> Details(string optname, string value)
        {
            if (optname == null || value == null)
            {
                return NotFound();
            }

            var optMaster = await _context.OptMaster
                .FirstOrDefaultAsync(m => m.OptName == optname && m.Value == value);
            if (optMaster == null)
            {
                return NotFound();
            }

            return View(optMaster);
        }

        // GET: OptMaster/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OptMaster/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OptName,Value,Text,Status")] OptMaster optMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(optMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(optMaster);
        }

        // GET: OptMaster/Edit/5
        public async Task<IActionResult> Edit(string optname, string value)
        {
            if (optname == null || value == null)
            {
                return NotFound();
            }

            //var optMaster = await _context.OptMaster.FindAsync(id);
            var optMaster = await _context.OptMaster
               .FirstOrDefaultAsync(m => m.OptName == optname && m.Value == value);
            if (optMaster == null)
            {
                return NotFound();
            }
            return View(optMaster);
        }

        // POST: OptMaster/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string optname, string value, [Bind("OptName,Value,Text,Status")] OptMaster optMaster)
        {
            if (optname != optMaster.OptName || value != optMaster.Value)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(optMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OptMasterExists(optMaster.OptName))
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
            return View(optMaster);
        }

        // GET: OptMaster/Delete/5
        public async Task<IActionResult> Delete(string optname, string value )
        {
            if (optname == null || value==null)
            {
                return NotFound();
            }

            var optMaster = await _context.OptMaster
                .FirstOrDefaultAsync(m => m.OptName == optname && m.Value == value);
            if (optMaster == null)
            {
                return NotFound();
            }

            return View(optMaster);
        }

        // POST: OptMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string optname, string value)
        {
            //var optMaster = await _context.OptMaster.FindAsync(id);

            var optMaster = await _context.OptMaster
                .FirstOrDefaultAsync(m => m.OptName == optname && m.Value == value);
            _context.OptMaster.Remove(optMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OptMasterExists(string id)
        {
            return _context.OptMaster.Any(e => e.OptName == id);
        }
    }
}
