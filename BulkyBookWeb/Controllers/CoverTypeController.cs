﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BulkyBookWeb.Data;
using BulkyBookWeb.Models;

namespace BulkyBookWeb.Controllers
{
    public class CoverTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoverTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CoverType
        public async Task<IActionResult> Index()
        {
              return _context.CoverType != null ? 
                          View(await _context.CoverType.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CoverType'  is null.");
        }

        // GET: CoverType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CoverType == null)
            {
                return NotFound();
            }

            var coverType = await _context.CoverType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coverType == null)
            {
                return NotFound();
            }

            return View(coverType);
        }

        // GET: CoverType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CoverType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CoverType coverType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coverType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coverType);
        }

        // GET: CoverType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CoverType == null)
            {
                return NotFound();
            }

            var coverType = await _context.CoverType.FindAsync(id);
            if (coverType == null)
            {
                return NotFound();
            }
            return View(coverType);
        }

        // POST: CoverType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CoverType coverType)
        {
            if (id != coverType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coverType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoverTypeExists(coverType.Id))
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
            return View(coverType);
        }

        // GET: CoverType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CoverType == null)
            {
                return NotFound();
            }

            var coverType = await _context.CoverType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coverType == null)
            {
                return NotFound();
            }

            return View(coverType);
        }

        // POST: CoverType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CoverType == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CoverType'  is null.");
            }
            var coverType = await _context.CoverType.FindAsync(id);
            if (coverType != null)
            {
                _context.CoverType.Remove(coverType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoverTypeExists(int id)
        {
          return (_context.CoverType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
