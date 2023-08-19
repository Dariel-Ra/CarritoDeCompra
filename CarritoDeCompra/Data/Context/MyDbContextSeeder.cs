using CarritoDeCompra.Data.Models;

namespace CarritoDeCompra.Data.Context
{
    public class MyDbContextSeeder
    {
        public static async Task Inicializar(MyDbContext dbContext)
        {
            if (!dbContext.Productos.Any())
            {
                var mercancias = new List<Producto>() 
                {
                    new Producto()
                    {
                        Nombre = "Lenovo Thinkpad X1 Extreme",
                        Stock = 10,
                        Precio = 92250,
                    },
                    new Producto()
                    {
                        Nombre = "Playstation 5",
                        Stock = 50,
                        Precio = 30000,
                    },
                    new Producto()
                    {
                        Nombre = "Iphone 14 Pro Max",
                        Stock = 50,
                        Precio = 65000,
                    },
                    new Producto()
                    {
                        Nombre = "Nvidia RTX 4090",
                        Stock = 5,
                        Precio = 117960,
                    },
                    new Producto()
                    {
                        Nombre = "Samsung Smart TV Crystal UHD Serie 8",
                        Stock = 10,
                        Precio = 57900,
                    },
                    new Producto()
                    {
                        Nombre = "Teclado Logitech G Pro",
                        Stock = 20,
                        Precio = 2548,
                    }
                };
                dbContext.Productos.AddRange(mercancias);
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Usuarios.Any())
            {
                var mercancias = new List<Usuario>() 
                {
                    new Usuario()
                    {
                        Nombre = "Dariel Rafael",
                        Apellido = "Dariel",
                        Correo = "Dariel@test.com"
                    }
                };
                dbContext.Usuarios.AddRange(mercancias);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
