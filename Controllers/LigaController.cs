using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EquiposDeFutbol.Models;
using MvcEquiposDeFutbol.Data;

namespace EquiposDeFutbol.Controllers
{
    public class LigaController : Controller
    {
        private readonly MvcEquiposDeFutbolContext _context;

        public LigaController(MvcEquiposDeFutbolContext context)
        {
            _context = context;
        }

        // GET: Liga
        public async Task<IActionResult> Index()
        {
              return _context.Liga != null ? 
                          View(await _context.Liga.ToListAsync()) :
                          Problem("Entity set 'MvcEquiposDeFutbolContext.Liga'  is null.");
        }

        // GET: Liga/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Liga == null)
            {
                return NotFound();
            }

            var liga = await _context.Liga
                .FirstOrDefaultAsync(m => m.Id == id);
            if (liga == null)
            {
                return NotFound();
            }

            return View(liga);
        }

        // GET: Liga/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Liga/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Pais")] Liga liga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(liga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(liga);
        }

        // GET: Liga/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Liga == null)
            {
                return NotFound();
            }

            var liga = await _context.Liga.FindAsync(id);
            if (liga == null)
            {
                return NotFound();
            }
            return View(liga);
        }

        // POST: Liga/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Pais")] Liga liga)
        {
            if (id != liga.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(liga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LigaExists(liga.Id))
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
            return View(liga);
        }

        // GET: Liga/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Liga == null)
            {
                return NotFound();
            }

            var liga = await _context.Liga
                .FirstOrDefaultAsync(m => m.Id == id);
            if (liga == null)
            {
                return NotFound();
            }

            return View(liga);
        }

        // POST: Liga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Liga == null)
            {
                return Problem("Entity set 'MvcEquiposDeFutbolContext.Liga'  is null.");
            }
            var liga = await _context.Liga.FindAsync(id);
            if (liga != null)
            {
                _context.Liga.Remove(liga);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LigaExists(int id)
        {
          return (_context.Liga?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
