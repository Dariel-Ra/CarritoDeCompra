using CarritoDeCompra.Data.Request;
using CarritoDeCompra.Data.Response;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarritoDeCompra.Data.Models;

public class Carrito
{
    [Key]
    public int CarritoID { get; set; }
    public int? UsuarioID { get; set; }
    public int? ProductoID { get; set; }

    [ForeignKey("UsuarioID")]
    public virtual Usuario Usuario { get; set; } = null!;

    [ForeignKey("ProductoID")]
    public virtual Producto Producto { get; set; } = null!;

    public static Carrito Crear(CarritoRequest request)
    => new()
    {
        CarritoID = request.CarritoID,
        UsuarioID = request.UsuarioID,
        ProductoID = request.ProductoID
    };

    public CarritoResponse ToResponse()
        => new()
        {
            CarritoID = CarritoID,
            UsuarioID = Usuario.UsuarioID,
            ProductoID = Producto.ProductoID
        };
}

