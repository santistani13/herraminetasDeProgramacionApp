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
using Microsoft.AspNetCore.Authorization;

namespace EquiposDeFutbol.Controllers
{
    [Authorize]
    public class LigaController : Controller
    {
        private ILigaService _LigaService;

        public LigaController(ILigaService ligaService)
        {
            _LigaService = ligaService;
            
        }

        // GET: Liga
        public async Task<IActionResult> Index(string nameFilter)
        {
          
           var ligas = _LigaService.GetAll(nameFilter);
            var model = new LigaViewModel {Ligas = ligas};
            return View(model);
        }

        // GET: Liga/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liga = _LigaService.GetById(id.Value);
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
        public async Task<IActionResult> Create([Bind("Id,Nombre,Pais,Equipos")] Liga liga)
        {
            ModelState.Remove("Equipos");
            if (ModelState.IsValid)
            {
                _LigaService.Create(liga);
                return RedirectToAction(nameof(Index));
            }
            return View(liga);
        }

        // GET: Liga/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var liga = _LigaService.GetById(id.Value);
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
            ModelState.Remove("Equipos");

            if (ModelState.IsValid)
            {
                try
                {
                    _LigaService.Update(liga);

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
            if (id == null)
            {
                return NotFound();
            }

            var liga = _LigaService.GetById(id.Value);
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
           
            _LigaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool LigaExists(int id)
        {
          return  _LigaService.GetById(id) != null;
        }
    }
}
