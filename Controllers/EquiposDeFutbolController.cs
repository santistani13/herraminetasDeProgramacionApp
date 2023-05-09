using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EquiposDeFutbol.Models;
using MvcEquiposDeFutbol.Data;
using EquiposDeFutbol.ViewModels;

namespace EquiposDeFutbol.Controllers
{
    public class EquiposDeFutbolController : Controller
    {
        private readonly MvcEquiposDeFutbolContext _context;

        public EquiposDeFutbolController(MvcEquiposDeFutbolContext context)
        {
            _context = context;
        }

        // GET: EquiposDeFutbol
        public async Task<IActionResult> Index(string nameFilter)
        {
              var query = from equipo in _context.Equipo select equipo;

            if (!string.IsNullOrEmpty(nameFilter))
            {
                query = query.Where(x => x.Nombre.ToLower().Contains(nameFilter) ||
                x.Pais.ToLower().Contains(nameFilter)
                );
            }

            var model = new EquiposViewModel();
            model.Equipos = await query.ToListAsync();


            return _context.Equipo != null ? 
                          View(model) :
                          Problem("Entity set 'MenuContext.Equipo'  is null.");
        }

        // GET: EquiposDeFutbol/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Equipo == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // GET: EquiposDeFutbol/Create
        public IActionResult Create()
        {
              ViewData["LigaId"] = new SelectList(_context.Liga, "Id", "Nombre");
            return View();
        }

        // POST: EquiposDeFutbol/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Pais,AnioFundacion,Titulos,CantidadSocios,LigaId")] Equipo equipo)
        {
            ModelState.Remove("Liga");

            if (ModelState.IsValid)
            {
                _context.Add(equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
         ViewData["LigaId"] = new SelectList(_context.Liga, "Id", "Id", equipo.LigaId);

            return View(equipo);
        }

        // GET: EquiposDeFutbol/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Equipo == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipo.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }
         ViewData["LigaId"] = new SelectList(_context.Liga, "Id", "Nombre", equipo.LigaId);

            return View(equipo);
        }

        // POST: EquiposDeFutbol/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Pais,AnioFundacion,Titulos,CantidadSocios,LigaId")] Equipo equipo)
        {
            if (id != equipo.Id)
            {
                return NotFound();
            }
            ModelState.Remove("Liga");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoExists(equipo.Id))
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
         ViewData["LigaId"] = new SelectList(_context.Liga, "Id", "Nombre", equipo.LigaId);

            return View(equipo);
        }

        // GET: EquiposDeFutbol/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Equipo == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // POST: EquiposDeFutbol/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Equipo == null)
            {
                return Problem("Entity set 'MvcEquiposDeFutbolContext.Equipo'  is null.");
            }
            var equipo = await _context.Equipo.FindAsync(id);
            if (equipo != null)
            {
                _context.Equipo.Remove(equipo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipoExists(int id)
        {
          return (_context.Equipo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
