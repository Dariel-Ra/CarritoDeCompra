using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarritoDeCompra.Data.Models;

public class Factura
{   
    [Key]
    public int Id { get; set; }
    public int? UsuarioID { get; set; }
    public int? CarritoID { get; set; }
    public int? Cantidad { get; set; }

    [ForeignKey("UsuarioID")]
    public virtual Usuario Usuario { get; set; } = null!;
    [ForeignKey("CarritoID")]
    public virtual Carrito Carrito { get; set; } = null!;
}