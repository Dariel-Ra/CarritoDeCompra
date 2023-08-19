
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
using CarritoDeCompra.Data.Request;
using CarritoDeCompra.Data.Response;
    using Microsoft.EntityFrameworkCore;

    namespace CarritoDeCompra.Data.Models;
    public class Producto
    {
        [Key]
        public int ProductoID { get; set; }
        public string Nombre { get; set; } = null!;
        public int Stock { get; set; }
        [Precision(18, 2)]
        public decimal Precio { get; set; }

        public static Producto Crear(ProductoRequest request)
        {
            return new Producto()
            {
                Nombre = request.Nombre,
                Stock = request.Stock,
                Precio = request.Precio
            };
        }
        public bool Mofidicar(ProductoRequest proveedor)
        {
            var cambio = false;
            if (Nombre != proveedor.Nombre)
            {
                Nombre = proveedor.Nombre;
                cambio = true;
            }
            if (Stock != proveedor.Stock)
            {
                Stock = proveedor.Stock;
                cambio = true;
            }
            if (Precio != proveedor.Precio)
            {
                Precio = proveedor.Precio;
                cambio = true;
            }
            return cambio;
        }

        public ProductoResponse ToResponse()
        {
            return new ProductoResponse(ProductoID, Nombre, Precio, Stock);
        }
    }
