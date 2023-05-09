using EquiposDeFutbol.Models;

namespace EquiposDeFutbol.ViewModels
{
    public class EquiposViewModel{
        public List<Equipo> Equipos {get; set;} = new List<Equipo>();

        public string? NameFilter {get; set;}
    }
}