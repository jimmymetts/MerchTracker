using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MerchTracker.Data;
using MerchTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace MerchTracker.Controllers
{
    public class MyCapsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MyCapsController(ApplicationDbContext ctx,
                          UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = ctx;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: MyCaps
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyCaps.ToListAsync());
        }

        // GET: MyCaps/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myCaps = await _context.MyCaps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myCaps == null)
            {
                return NotFound();
            }

            return View(myCaps);
        }

        // GET: MyCaps/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyCaps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CapName,CapPrice,Quantity")] MyCaps myCaps)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myCaps);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myCaps);
        }

        // GET: MyCaps/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myCaps = await _context.MyCaps.FindAsync(id);
            if (myCaps == null)
            {
                return NotFound();
            }
            return View(myCaps);
        }

        // POST: MyCaps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CapName,CapPrice,Quantity")] MyCaps myCaps)
        {
            if (id != myCaps.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myCaps);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyCapsExists(myCaps.Id))
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
            return View(myCaps);
        }

        // GET: MyCaps/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myCaps = await _context.MyCaps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myCaps == null)
            {
                return NotFound();
            }

            return View(myCaps);
        }

        // POST: MyCaps/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myCaps = await _context.MyCaps.FindAsync(id);
            _context.MyCaps.Remove(myCaps);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyCapsExists(int id)
        {
            return _context.MyCaps.Any(e => e.Id == id);
        }
    }
}
