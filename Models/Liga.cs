using System.ComponentModel.DataAnnotations;


namespace EquiposDeFutbol.Models;


public class Liga {
    public int Id { get; set; }
    public string Nombre { get; set; }
    
    public string Pais { get; set; }

     public List<Equipo> Equipos { get; set; }
}