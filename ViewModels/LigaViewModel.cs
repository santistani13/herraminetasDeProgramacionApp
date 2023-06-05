using EquiposDeFutbol.Models;

namespace EquiposDeFutbol.ViewModels
{
    public class LigaViewModel{
        public List<Liga> Ligas {get; set;} = new List<Liga>();

        public string? NameFilter {get; set;}
    }
}