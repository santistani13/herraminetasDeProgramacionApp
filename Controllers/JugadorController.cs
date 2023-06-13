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
using EquiposDeFutbol.Services;


namespace EquiposDeFutbol.Controllers
{
    public class JugadorController : Controller
    
    {
        private readonly MvcEquiposDeFutbolContext _context;
        private IEquipoService _EquipoService;


        public JugadorController(MvcEquiposDeFutbolContext context, IEquipoService equipoService)
        {
            _context = context;
            _EquipoService = equipoService;

        }

        // GET: Jugador
        public async Task<IActionResult> Index()
        {

            var query = from jugador in _context.Jugador select jugador;
            // var context = _context.Jugador.Include(r => r.Equipos);
            var jugadores = query.Include(e => e.Equipos).ToList();

            var model = new JugadorViewModel {Jugadores = jugadores};


              return _context.Jugador != null ? 
                          View(model) :
                          Problem("Entity set 'MvcEquiposDeFutbolContext.Jugador'  is null.");
        }

        // GET: Jugador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Jugador == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugador
                .FirstOrDefaultAsync(m => m.JugadorId == id);
            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }

        // GET: Jugador/Create
        public IActionResult Create()
        {
            var equipos = _EquipoService.GetAll();
            ViewData["Equipos"] = equipos;
            return View();
        }

        // POST: Jugador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Nacionalidad,Edad,EquiposIds")] JugadorViewModel jugadorView)
        {
            if (ModelState.IsValid)
            {
                 var jugadores = _context.Equipo.Where(x=> jugadorView.EquiposIds.Contains(x.Id)).ToList();

                var jugador = new Jugador {
                   Nombre = jugadorView.Name,
                    Equipos = jugadores
                };
               _context.Add(jugador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jugadorView);
             
        }

        // GET: Jugador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Jugador == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugador.FindAsync(id);
            if (jugador == null)
            {
                return NotFound();
            }
            return View(jugador);
        }

        // POST: Jugador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JugadorId,Nombre")] Jugador jugador)
        {
            if (id != jugador.JugadorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jugador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JugadorExists(jugador.JugadorId))
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
            return View(jugador);
        }

        // GET: Jugador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Jugador == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugador
                .FirstOrDefaultAsync(m => m.JugadorId == id);
            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }

        // POST: Jugador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Jugador == null)
            {
                return Problem("Entity set 'MvcEquiposDeFutbolContext.Jugador'  is null.");
            }
            var jugador = await _context.Jugador.FindAsync(id);
            if (jugador != null)
            {
                _context.Jugador.Remove(jugador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JugadorExists(int id)
        {
          return (_context.Jugador?.Any(e => e.JugadorId == id)).GetValueOrDefault();
        }
    }
}
