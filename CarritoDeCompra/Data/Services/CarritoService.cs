using CarritoDeCompra.Data.Context;
using CarritoDeCompra.Data.Response;
using CarritoDeCompra.Data.Models;
using CarritoDeCompra.Data.Request;
using CarritoDeCompra.Data.Wrapper;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CarritoDeCompra.Data.Services;

public interface ICarritoServices
{
    Task<Result<List<CarritoResponse>>> Consultar(string filtro);
    Task<Result> Crear(CarritoRequest request);
    Task<Result> Eliminar(CarritoRequest request);
}

public class CarritoServices : ICarritoServices
{
    private readonly IMyDbContext dbContext;

    public CarritoServices(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result> Crear(CarritoRequest request)
    {
        try
        {
            var carrito = Carrito.Crear(request);
            dbContext.Carritos.Add(carrito);
            await dbContext.SaveChangesAsync();
            return Result<int>.Success(carrito.CarritoID);
        }
        catch (Exception E)
        {
            return Result.Fail(E.Message);
        }
    }

    public async Task<Result> Eliminar(CarritoRequest request)
    {
        try
        {
            var carrito = await dbContext.Carritos
                .FirstOrDefaultAsync(c => c.CarritoID == request.CarritoID);
            if (carrito == null)
                return Result.Fail("No se encontro el carrito");

            dbContext.Carritos.Remove(carrito);
            await dbContext.SaveChangesAsync();
            return Result.Sucess("Ok");
        }
        catch (Exception E)
        {

            return Result.Fail(E.Message);
        }
    }
    public async Task<Result<List<CarritoResponse>>> Consultar(string filtro)
    {
        try
        {
            var carrito = await dbContext.Carritos
                .Include(p => p.Producto)
                .Include(p => p.Usuario)
                .Where(c =>
                    c.CarritoID
                    .ToString()
                    .Contains(filtro.ToLower()
                    )
                )
                .Select(c => c.ToResponse())
                .ToListAsync();
            return Result<List<CarritoResponse>>.Success(carrito, "Ok");
        }
        catch (Exception E)
        {
            return Result<List<CarritoResponse>>.Fail(E.Message);
        }
    }
}
