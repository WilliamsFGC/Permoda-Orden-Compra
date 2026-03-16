using Microsoft.EntityFrameworkCore;
using OrdenCompra.Domain.Entidades;

namespace OrdenCompra.Infrastructure.Persistencia;

/// <summary>
/// Contexto base de datos
/// </summary>
/// <param name="options"></param>
public class OrdenCompraDbContext(DbContextOptions<OrdenCompraDbContext> options) : DbContext(options)
{
    public DbSet<Producto> Producto => Set<Producto>();
    public DbSet<OrdenItem> OrdenItem => Set<OrdenItem>();
    public DbSet<Orden> Orden => Set<Orden>();
    public DbSet<Inventario> Inventario => Set<Inventario>();

    /// <summary>
    /// Crear modelo
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(e =>
        {
            e.HasKey(e => e.Id);
            e.Property(e => e.Nombre).HasMaxLength(50);
            e.Property(e => e.Precio);
            e.Property(e => e.ImagenUrl);
        });

        modelBuilder.Entity<OrdenItem>(e =>
        {
            e.HasKey(e => e.Id);
            e.Property(e => e.Cantidad);
            e.HasOne(e => e.Producto).WithMany(p => p.OrdenItems).HasForeignKey(f => f.ProductoId);
            e.HasOne(e => e.Orden).WithMany(o => o.OrdenItems).HasForeignKey(f => f.OrdenId);
        });

        modelBuilder.Entity<Orden>(e =>
        {
            e.HasKey(e => e.Id);
            e.Property(e => e.Total).IsRequired();
            e.Property(e => e.Fecha).IsRequired();
            e.Property(e => e.Estado).IsRequired();
            e.Property(e => e.Descripcion).HasMaxLength(50).IsRequired();
        });

        modelBuilder.Entity<Inventario>(e =>
        {
            e.HasKey(e => e.Id);
            e.Property(e => e.Stock);
            e.HasOne(e => e.Producto).WithMany(p => p.Inventarios).HasForeignKey(f => f.ProductoId);
        });
    }
}
