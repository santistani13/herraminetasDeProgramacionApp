using System.ComponentModel.DataAnnotations;

using EquiposDeFutbol.Models;

namespace EquiposDeFutbol.ViewModels;

public class JugadorViewModel {
    public int Id { get; set; }
    public List<Jugador> Jugadores {get; set;} = new List<Jugador>();
     [Display(Name ="Nombre")]

    public string Name { get; set; }

    public string? Nacionalidad { get; set; }

    public int Edad { get; set; }
    public List<int> EquiposIds { get; set; }

}