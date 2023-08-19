using CarritoDeCompra.Data.Response;
using System.ComponentModel.DataAnnotations;

namespace CarritoDeCompra.Data.Models;

public class Usuario
{
    [Key]
    public int UsuarioID { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string Correo { get; set; } = null!;

    public UsuarioResponse ToResponse()
        => new()
        {
            UsuarioID = UsuarioID,
            Nombre = Nombre,
            Apellido = Apellido,
            Correo = Correo
        };

}

