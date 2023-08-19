using CarritoDeCompra.Data.Context;
using CarritoDeCompra.Data.Response;
using CarritoDeCompra.Data.Models;
using CarritoDeCompra.Data.Request;
using CarritoDeCompra.Data.Wrapper;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CarritoDeCompra.Data.Services;

public interface IUsuarioService
{
    Task<Result<List<UsuarioResponse>>> Consultar(string filtro);
    Task<Result> Crear(UsuarioRequest request);
    Task<Result> Eliminar(UsuarioRequest request);
}

public class UsuarioService : IUsuarioService
{
    private readonly IMyDbContext dbContext;

    public UsuarioService(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result> Crear(UsuarioRequest request)
    {
        try
        {
            var carrito = Usuario.Crear(request);
            dbContext.Usuarios.Add(carrito);
            await dbContext.SaveChangesAsync();
            return Result<int>.Success(carrito.UsuarioID);
        }
        catch (Exception E)
        {
            return Result.Fail(E.Message);
        }
    }

    public async Task<Result> Eliminar(UsuarioRequest request)
    {
        try
        {
            var carrito = await dbContext.Usuarios
                .FirstOrDefaultAsync(c => c.UsuarioID == request.UsuarioID);
            if (carrito == null)
                return Result.Fail("No se encontro el carrito");

            dbContext.Usuarios.Remove(carrito);
            await dbContext.SaveChangesAsync();
            return Result.Sucess("Ok");
        }
        catch (Exception E)
        {

            return Result.Fail(E.Message);
        }
    }
    public async Task<Result<List<UsuarioResponse>>> Consultar(string filtro)
    {
        try
        {
            var carrito = await dbContext.Usuarios
                .Where(c =>
                    c.UsuarioID
                    .ToString()
                    .Contains(filtro.ToLower()
                    )
                )
                .Select(c => c.ToResponse())
                .ToListAsync();
            return Result<List<UsuarioResponse>>.Success(carrito, "Ok");
        }
        catch (Exception E)
        {
            return Result<List<UsuarioResponse>>.Fail(E.Message);
        }
    }
}
