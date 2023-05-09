using System.ComponentModel.DataAnnotations;


namespace EquiposDeFutbol.Models;


public class Equipo {
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Pais { get; set; }
    public int AnioFundacion {get; set;}
    public int Titulos { get; set; }
    public int CantidadSocios{ get; set; }
    
   public int LigaId { get; set; }
   public Liga Liga {get; set; }
}