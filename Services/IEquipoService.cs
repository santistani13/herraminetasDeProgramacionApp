namespace EquiposDeFutbol.Services;
using EquiposDeFutbol.Models;
public interface IEquipoService {

    void Create(Equipo obj);
    List<Equipo> GetAll(string nameFilter);
    void Update(Equipo obj);
    void Delete(int id);
    Equipo? GetById(int id);
}