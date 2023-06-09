namespace EquiposDeFutbol.Services;
using EquiposDeFutbol.Models;
using MvcEquiposDeFutbol.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class LigaService : ILigaService
{
        private readonly MvcEquiposDeFutbolContext _context;

        public LigaService(MvcEquiposDeFutbolContext context){
            _context = context;
        }
     public void Create(Liga obj)
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

    public List<Liga> GetAll(string nameFilter)
    {
          var query = from liga in _context.Liga select liga;

            if (!string.IsNullOrEmpty(nameFilter))
            {
                query = query.Where(x => x.Nombre.ToLower().Contains(nameFilter.ToLower()) ||
                x.Pais.ToLower().Contains(nameFilter.ToLower())
                );
            }
            return query.Include(e => e.Equipos).ToList();
    }
 public List<Liga> GetAll()
    {
        var query = from liga in _context.Liga select liga;
        return query.ToList();
    }

    public Liga? GetById(int id)
    {
      
            var liga = _context.Liga
                .FirstOrDefault(m => m.Id == id);

            return liga;
    }

    public void Update(Liga obj)
    {
       _context.Update(obj);
        _context.SaveChanges();
    }
}