namespace CarritoDeCompra.Data.Request;

public class ProductoRequest
{
    public string Nombre { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public decimal Precio { get; set; }
    public int Stock { get; set; }
}
public class ProductoRequestUpdate : ProductoRequest
{
    public int ProductoID { get; set; }
}