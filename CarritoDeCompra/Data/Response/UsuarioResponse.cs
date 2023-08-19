using CarritoDeCompra.Data.Request;

namespace CarritoDeCompra.Data.Response;

public class UsuarioResponse
{
    public int UsuarioID { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string Correo { get; set; } = null!;

    public UsuarioRequest ToRequest()
    {
        return new UsuarioRequest
        {
            UsuarioID = UsuarioID,
            Nombre = Nombre,
            Apellido = Apellido,
            Correo = Correo
        };
    }
}

