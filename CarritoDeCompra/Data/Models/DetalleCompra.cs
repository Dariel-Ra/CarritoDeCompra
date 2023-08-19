using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarritoDeCompra.Data.Models;

public class DetalleCompra
{
    [Key]
    public int Id { get; set; }
    public int? UsuarioID { get; set; }
    public int? ProductoID { get; set; }
    public int? Cantidad { get; set; }

    [ForeignKey("UsuarioID")]
    public virtual Usuario Usuario { get; set; } = null!;
    [ForeignKey("ProductoID")]
    public virtual Producto Producto { get; set; } = null!;

}