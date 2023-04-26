using System.ComponentModel.DataAnnotations;


namespace EquiposDeFutbol.Models;


public class Equipo {
    public int Id { get; set; }
    [Display(Name="Id")]
    public string Nombre { get; set; }
     [Display(Name="Nombre")]
    public string Pais { get; set; }
    [Display(Name="Pais")]
    public int AnioFundacion {get; set;}
    [Display(Name="Año de Fundacion")]
    public int Titulos { get; set; }
    [Display(Name="Titulos")]
    public int CantidadSocios{ get; set; }
    
}