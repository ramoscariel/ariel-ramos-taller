﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArielRamos_Taller.Data;
using ArielRamos_Taller.Models;

namespace ArielRamos_Taller.Controllers
{
    public class BurgersController : Controller
    {
        private readonly ArielRamos_TallerContext _context;

        public BurgersController(ArielRamos_TallerContext context)
        {
            _context = context;
        }

        // GET: Burgers
        public async Task<IActionResult> Index()
        {
              return _context.Burger != null ? 
                          View(await _context.Burger.ToListAsync()) :
                          Problem("Entity set 'ArielRamos_TallerContext.Burger'  is null.");
        }

        // GET: Burgers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Burger == null)
            {
                return NotFound();
            }

            var burger = await _context.Burger
                .FirstOrDefaultAsync(m => m.Id == id);
            if (burger == null)
            {
                return NotFound();
            }

            return View(burger);
        }

        // GET: Burgers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Burgers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,WithCheese,Precio")] Burger burger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(burger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(burger);
        }

        // GET: Burgers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Burger == null)
            {
                return NotFound();
            }

            var burger = await _context.Burger.FindAsync(id);
            if (burger == null)
            {
                return NotFound();
            }
            return View(burger);
        }

        // POST: Burgers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,WithCheese,Precio")] Burger burger)
        {
            if (id != burger.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(burger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BurgerExists(burger.Id))
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
            return View(burger);
        }

        // GET: Burgers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Burger == null)
            {
                return NotFound();
            }

            var burger = await _context.Burger
                .FirstOrDefaultAsync(m => m.Id == id);
            if (burger == null)
            {
                return NotFound();
            }

            return View(burger);
        }

        // POST: Burgers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Burger == null)
            {
                return Problem("Entity set 'ArielRamos_TallerContext.Burger'  is null.");
            }
            var burger = await _context.Burger.FindAsync(id);
            if (burger != null)
            {
                _context.Burger.Remove(burger);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BurgerExists(int id)
        {
          return (_context.Burger?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
