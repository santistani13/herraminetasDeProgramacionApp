namespace EquiposDeFutbol.Services;
using EquiposDeFutbol.Models;

public interface ILigaService {

    void Create(Liga obj);
    List<Liga> GetAll(string nameFilter);
    List<Liga> GetAll();
    void Update(Liga obj);
    void Delete(int id);
    Liga? GetById(int id);
}