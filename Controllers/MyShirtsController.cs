﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MerchTracker.Data;
using MerchTracker.Models;

namespace MerchTracker.Controllers
{
    public class MyShirtsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyShirtsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MyShirts
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyShirts.ToListAsync());
        }

        // GET: MyShirts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myShirts = await _context.MyShirts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myShirts == null)
            {
                return NotFound();
            }

            return View(myShirts);
        }

        // GET: MyShirts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyShirts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShirtName,ShirtPrice,Quantity")] MyShirts myShirts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myShirts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myShirts);
        }

        // GET: MyShirts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myShirts = await _context.MyShirts.FindAsync(id);
            if (myShirts == null)
            {
                return NotFound();
            }
            return View(myShirts);
        }

        // POST: MyShirts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShirtName,ShirtPrice,Quantity")] MyShirts myShirts)
        {
            if (id != myShirts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myShirts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyShirtsExists(myShirts.Id))
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
            return View(myShirts);
        }

        // GET: MyShirts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myShirts = await _context.MyShirts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myShirts == null)
            {
                return NotFound();
            }

            return View(myShirts);
        }

        // POST: MyShirts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myShirts = await _context.MyShirts.FindAsync(id);
            _context.MyShirts.Remove(myShirts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyShirtsExists(int id)
        {
            return _context.MyShirts.Any(e => e.Id == id);
        }
    }
}
