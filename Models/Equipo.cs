using System.ComponentModel.DataAnnotations;


namespace EquiposDeFutbol.Models;


public class Equipo {
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Pais { get; set; }
     [Display(Name ="Fundación")]

    public int AnioFundacion {get; set;}
    public int Titulos { get; set; }
    [Display(Name =" N° Socios")]
    public int CantidadSocios{ get; set; }
    
   public int LigaId { get; set; }
   public Liga Liga {get; set; }
   public virtual List<Jugador> Jugadores { get; set; }
}