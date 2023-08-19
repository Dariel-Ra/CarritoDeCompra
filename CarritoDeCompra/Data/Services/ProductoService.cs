using CarritoDeCompra.Data.Context;
using CarritoDeCompra.Data.Response;
using CarritoDeCompra.Data.Models;
using CarritoDeCompra.Data.Request;
using CarritoDeCompra.Data.Wrapper;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CarritoDeCompra.Data.Services;

public interface IProductoServices
{
    Task<Result<List<ProductoResponse>>> Consultar(string filtro);
    Task<Result> Crear(ProductoRequestUpdate request);
    Task<Result> Eliminar(ProductoRequestUpdate request);
    Task<Result> SoftDeleted(ProductoRequestUpdate request);
    Task<Result> Modificar(ProductoRequestUpdate request);
}

public class ProductoServices : IProductoServices
{
    private readonly IMyDbContext dbContext;

    public ProductoServices(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result> Crear(ProductoRequestUpdate request)
    {
        try
        {
            var producto = Producto.Crear(request);
            dbContext.Productos.Add(producto);
            await dbContext.SaveChangesAsync();
            return Result<int>.Success(producto.ProductoID);
        }
        catch (Exception E)
        {
            return Result.Fail(E.Message);
        }
    }
    public async Task<Result> Modificar(ProductoRequestUpdate request)
    {
        try
        {
            var producto = await dbContext.Productos
                .FirstOrDefaultAsync(c => c.ProductoID == request.ProductoID);
            if (producto == null)
                return Result.Fail("No se encontro el producto");

            if (producto.Mofidicar(request))
                await dbContext.SaveChangesAsync();

            return Result.Sucess("Ok");
        }
        catch (Exception E)
        {

            return Result.Fail(E.Message);
        }
    }
    public async Task<Result> Eliminar(ProductoRequestUpdate request)
    {
        try
        {
            var producto = await dbContext.Productos
                .FirstOrDefaultAsync(c => c.ProductoID == request.ProductoID);
            if (producto == null)
                return Result.Fail("No se encontro el producto");

            dbContext.Productos.Remove(producto);
            await dbContext.SaveChangesAsync();
            return Result.Sucess("Ok");
        }
        catch (Exception E)
        {

            return Result.Fail(E.Message);
        }
    }

    public async Task<Result> SoftDeleted(ProductoRequestUpdate request)
    {
        try
        {
            var producto = await dbContext.Productos
                .FirstOrDefaultAsync(c => c.ProductoID == request.ProductoID);
            if (producto == null)
                return Result.Fail("No se encontro el producto");
            
            
            await dbContext.SaveChangesAsync();
            return Result.Sucess("Ok");
        }
        catch (Exception E)
        {

            return Result.Fail(E.Message);
        }
    }

    public async Task<Result<List<ProductoResponse>>> Consultar(string filtro)
    {
        try
        {
            var producto = await dbContext.Productos
                .Where(c =>
                    (c.Nombre)
                    .ToLower()
                    .Contains(filtro.ToLower()
                    )
                )
                .Select(c => c.ToResponse())
                .ToListAsync();
            return Result<List<ProductoResponse>>.Success(producto, "Ok");
        }
        catch (Exception E)
        {
            return Result<List<ProductoResponse>>.Fail(E.Message);
        }
    }
}
