using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OneFin.Models;

namespace OneFin.Areas.Security.Controllers
{
    [Authorize]
    [Area("Security")]
    public class TransactionMasterController : Controller
    {
        private readonly AppDbContext _context;


        public TransactionMasterController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Security/TransactionMaster
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewBag.CurrentSort = sortOrder;
            var transactionmaster = from m in _context.TransactionMaster  orderby m.TransactionName
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
                transactionmaster = transactionmaster.Where(s => s.TransactionName.Contains(searchString)).OrderBy(s => s.TransactionName);
            }


            //return View(await _context.OptMaster.ToListAsync());
            int pageSize = 8;
            return View(await PaginatedList<TransactionMaster>.CreateAsync(transactionmaster.AsNoTracking(), pageNumber ?? 1, pageSize));
            //return View(await _context.TransactionMaster.ToListAsync());
        }

        // GET: Security/TransactionMaster/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionMaster = await _context.TransactionMaster
                .FirstOrDefaultAsync(m => m.ID == id);
            if (transactionMaster == null)
            {
                return NotFound();
            }

            return View(transactionMaster);
        }

        // GET: Security/TransactionMaster/Create
        public IActionResult Create()
        {
            var items = _context.AspNetRoles.ToList();
            if (items != null)
            {
                ViewBag.data = items;
            }
            return View();
        }

        // POST: Security/TransactionMaster/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Module,TransactionName,Role")] TransactionMaster transactionMaster)
        {
            if (ModelState.IsValid)
            {
                transactionMaster.ID = Utility.GetUniqueId();
                _context.Add(transactionMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transactionMaster);
        }

        // GET: Security/TransactionMaster/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionMaster = await _context.TransactionMaster.FindAsync(id);
            if (transactionMaster == null)
            {
                return NotFound();
            }
            return View(transactionMaster);
        }

        // POST: Security/TransactionMaster/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Module,TransactionName,Role")] TransactionMaster transactionMaster)
        {
            if (id != transactionMaster.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transactionMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionMasterExists(transactionMaster.ID))
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
            return View(transactionMaster);
        }

        // GET: Security/TransactionMaster/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionMaster = await _context.TransactionMaster
                .FirstOrDefaultAsync(m => m.ID == id);
            if (transactionMaster == null)
            {
                return NotFound();
            }

            return View(transactionMaster);
        }

        // POST: Security/TransactionMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var transactionMaster = await _context.TransactionMaster.FindAsync(id);
            _context.TransactionMaster.Remove(transactionMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionMasterExists(string id)
        {
            return _context.TransactionMaster.Any(e => e.ID == id);
        }
    }
}
