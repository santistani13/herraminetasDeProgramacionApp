namespace EquiposDeFutbol.Services;
using EquiposDeFutbol.Models;
using MvcEquiposDeFutbol.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class EquipoService : IEquipoService
{
        private readonly MvcEquiposDeFutbolContext _context;

        public EquipoService(MvcEquiposDeFutbolContext context){
            _context = context;
        }

    public void Create(Equipo obj)
    {
          _context.Add(obj);
        _context.SaveChanges();

    }

    public void Delete(int id)
    {
       var obj = GetById(id);
        
        if (obj != null){
            _context.Remove(obj);
            _context.SaveChanges();
        }
    }

    public List<Equipo> GetAll(string nameFilter)
    {
          var query = from equipo in _context.Equipo select equipo;

            if (!string.IsNullOrEmpty(nameFilter))
            {
                query = query.Where(x => x.Nombre.ToLower().Contains(nameFilter.ToLower()) ||
                x.Pais.ToLower().Contains(nameFilter.ToLower())
                );
            }
            var equipos = query.Include(e => e.Liga).ToList();
            return equipos;
    }

    public Equipo? GetById(int id)
    {
      
            var equipo = _context.Equipo
                .FirstOrDefault(m => m.Id == id);

            return equipo;
    }

    public void Update(Equipo obj)
    {
       _context.Update(obj);
        _context.SaveChanges();
    }
}