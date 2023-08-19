
using CarritoDeCompra.Data.Models;
using CarritoDeCompra.Data.Request;

namespace CarritoDeCompra.Data.Response;

public class ProductoResponse
{
    public ProductoResponse()
    {
    }

    public ProductoResponse(int id, string nombre, decimal precio, int stock)
    {
        ProductoID = id;
        Nombre = nombre;
        Precio = precio;
        Stock = stock;
    }

    public int ProductoID { get; set; }
    public string Nombre { get; set; } = null!;
    public decimal Precio { get; set; }
    public int Stock { get; set; }

    public ProductoRequestUpdate ToRequest()
    {
        return new ProductoRequestUpdate
        {
            ProductoID = ProductoID,
            Nombre = Nombre,
            Precio = Precio,
            Stock = Stock
        };
    }
}