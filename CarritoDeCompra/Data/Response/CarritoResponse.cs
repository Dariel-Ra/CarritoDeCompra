using CarritoDeCompra.Data.Models;
using CarritoDeCompra.Data.Request;

namespace CarritoDeCompra.Data.Response;

public class CarritoResponse
{
    public int CarritoID { get; set; }
    public int UsuarioID { get; set; }
    public int ProductoID { get; set; }
    public virtual Usuario Usuario { get; set; } = null!;
    public virtual Producto Producto { get; set; } = null!;

    public CarritoRequest ToRequest()
    {
        return new CarritoRequest
        {
            CarritoID = CarritoID,
            UsuarioID = Usuario.UsuarioID,
            ProductoID = Producto.ProductoID
        };
    }
}

