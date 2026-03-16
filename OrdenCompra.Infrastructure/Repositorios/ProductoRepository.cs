using Microsoft.EntityFrameworkCore;
using OrdenCompra.Application.Dto;
using OrdenCompra.Domain.Entidades;
using OrdenCompra.Infrastructure.Persistencia;
using OrdenCompra.Application.Interfaces;

namespace OrdenCompra.Infrastructure.Repositorios;

/// <summary>
/// Repositorio para producto
/// </summary>
public class ProductoRepository(OrdenCompraDbContext dbContext) : IProductoRepository, Domain.Interfaces.IProductoRepository
{
    /// <summary>
    /// Obtener Producto por Id
    /// </summary>
    /// <param name="productoId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Producto> ObtenerPorIdAsync(int productoId)
    {
        return await dbContext.Producto.FirstAsync(f => f.Id == productoId);
    }

    /// <summary>
    /// Obtener productos
    /// </summary>
    /// <returns>Lista de productos</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IEnumerable<ProductoDto>> ObtenerProductos()
    {
        return await dbContext.Producto.Select(s => new ProductoDto { Id = s.Id, Nombre = s.Nombre, Precio = s.Precio, ImagenUrl = s.ImagenUrl }).ToListAsync();
    }
}
