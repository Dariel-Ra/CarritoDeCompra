using Microsoft.EntityFrameworkCore;
using CarritoDeCompra.Data.Models;


namespace CarritoDeCompra.Data.Context;

public interface IMyDbContext
{
    DbSet<Usuario> Usuarios { get; set; }
    DbSet<Producto> Productos { set; get; }
    DbSet<Carrito> Carritos { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

public class MyDbContext : DbContext, IMyDbContext
{
    private readonly IConfiguration config;

    public MyDbContext(IConfiguration _config)
    {
        config = _config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(config.GetConnectionString("CRUD"));
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    #region Tablas de mi base de datos
    public DbSet<Usuario> Usuarios { set; get; } = null!;
    public DbSet<Producto> Productos { set; get; } = null!;    
    public DbSet<Carrito> Carritos { get; set; } = null!;
    #endregion
}