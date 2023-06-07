using System.ComponentModel.DataAnnotations;


namespace EquiposDeFutbol.Models;

public class Jugador {
    public int JugadorId { get; set; }
    public string Nombre { get; set; }
    public virtual List<Equipo> Equipos { get; set; }
}