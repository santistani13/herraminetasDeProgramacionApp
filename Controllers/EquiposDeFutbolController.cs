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
    public class EquiposDeFutbolController : Controller
    {
        private IEquipoService _EquipoService;
        private ILigaService _LigaService;
        public EquiposDeFutbolController(IEquipoService equipoService, ILigaService ligaService)
        {
            _EquipoService = equipoService;
            _LigaService = ligaService;
        }

        // GET: EquiposDeFutbol
        public  IActionResult Index(string nameFilter)
        {
          
            var equipos = _EquipoService.GetAll(nameFilter);
            var model = new EquiposViewModel {Equipos = equipos};
            return View(model);
                          
        }

        // GET: EquiposDeFutbol/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = _EquipoService.GetById(id.Value);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // GET: EquiposDeFutbol/Create
        public IActionResult Create()
        {
            var ligaList = _LigaService.GetAll();
              ViewData["LigaId"] = new SelectList(ligaList, "Id", "Nombre");
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
            ModelState.Remove("Jugadores");

            if (ModelState.IsValid)
            {
               _EquipoService.Create(equipo);
                return RedirectToAction(nameof(Index));


            }
            var ligaList = _LigaService.GetAll();
         ViewData["LigaId"] = new SelectList(ligaList, "Id", "Id", equipo.LigaId);

            return View(equipo);
        }

        // GET: EquiposDeFutbol/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var equipo = _EquipoService.GetById(id.Value);
            if (equipo == null)
            {
                return NotFound();
            }
            var ligaList = _LigaService.GetAll();
            ViewData["LigaId"] = new SelectList(ligaList, "Id", "Nombre");


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
            ModelState.Remove("Jugadores");


            if (ModelState.IsValid)
            {
                try
                {
                    _EquipoService.Update(equipo);
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
            var ligaList = _LigaService.GetAll();
            ViewData["LigaId"] = new SelectList(ligaList, "Id", "Nombre");
            return View(equipo);
        }

        // GET: EquiposDeFutbol/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var equipo = _EquipoService.GetById(id.Value);
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
           
            _EquipoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool EquipoExists(int id)
        {
          return  _EquipoService.GetById(id) != null;
        }
    }
}
