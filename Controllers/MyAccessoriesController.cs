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
    public class MyAccessoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MyAccessoriesController(ApplicationDbContext ctx,
                          UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = ctx;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: MyAccessories
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyAccessories.ToListAsync());
        }

        // GET: MyAccessories/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myAccessories = await _context.MyAccessories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myAccessories == null)
            {
                return NotFound();
            }

            return View(myAccessories);
        }

        // GET: MyAccessories/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyAccessories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AccessoryName,AccessoryPrice,Quantity")] MyAccessories myAccessories)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myAccessories);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myAccessories);
        }

        // GET: MyAccessories/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myAccessories = await _context.MyAccessories.FindAsync(id);
            if (myAccessories == null)
            {
                return NotFound();
            }
            return View(myAccessories);
        }

        // POST: MyAccessories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AccessoryName,AccessoryPrice,Quantity")] MyAccessories myAccessories)
        {
            if (id != myAccessories.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myAccessories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyAccessoriesExists(myAccessories.Id))
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
            return View(myAccessories);
        }

        // GET: MyAccessories/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myAccessories = await _context.MyAccessories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myAccessories == null)
            {
                return NotFound();
            }

            return View(myAccessories);
        }

        // POST: MyAccessories/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myAccessories = await _context.MyAccessories.FindAsync(id);
            _context.MyAccessories.Remove(myAccessories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyAccessoriesExists(int id)
        {
            return _context.MyAccessories.Any(e => e.Id == id);
        }
    }
}
