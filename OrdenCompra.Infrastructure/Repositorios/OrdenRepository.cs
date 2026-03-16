using Microsoft.EntityFrameworkCore;
using OrdenCompra.Application.Dto;
using OrdenCompra.Domain.Entidades;
using OrdenCompra.Domain.Interfaces;
using OrdenCompra.Infrastructure.Persistencia;

namespace OrdenCompra.Infrastructure.Repositorios;

/// <summary>
/// Repositorio para orden de compra
/// </summary>
public class OrdenRepository(OrdenCompraDbContext dbContext) : IOrdenRepository, Application.Interfaces.IOrdenRepository
{

    /// <summary>
    /// Crear orden de compra
    /// </summary>
    /// <param name="orden">Entidad de la orden de compra</param>
    /// <returns>Id de la orden de compra</returns>
    public async Task<int> AgregarAsync(Orden orden)
    {
        await dbContext.Orden.AddAsync(orden);
        await dbContext.SaveChangesAsync();
        return orden.Id;
    }

    /// <summary>
    /// Agregar ítem a la orden de compra
    /// </summary>
    /// <param name="item">Agregar ítem a la orden de compra</param>
    /// <returns></returns>
    public async Task<int> AgregarItemAsync(OrdenItem item)
    {
        await dbContext.OrdenItem.AddAsync(item);
        await dbContext.SaveChangesAsync();
        return item.Id;
    }

    /// <summary>
    /// Obtener Orden de compra por Id
    /// </summary>
    /// <param name="ordenId">Id de la orden de compra</param>
    /// <returns>Entidad orden de compra</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Orden> ObtenerPorId(int ordenId)
    {
        return await dbContext.Orden.Include(i => i.OrdenItems).FirstAsync(f => f.Id == ordenId);
    }

    /// <summary>
    /// Eliminar orden de compra
    /// </summary>
    /// <param name="ordenId">Id de la orden de compra</param>
    /// <returns>Id de la orden de compra</returns>
    public async Task<int> EliminarOrdenAsync(int ordenId)
    {
        Orden orden = await dbContext.Orden.FirstAsync(f => f.Id == ordenId);
        dbContext.Entry<Orden>(orden).State = EntityState.Deleted;
        orden.OrdenItems.Clear();
        await dbContext.SaveChangesAsync();
        return ordenId;
    }

    /// <summary>
    /// Obtener ordenes de compra
    /// </summary>
    /// <returns>Listado de ordenes de compra</returns>
    public async Task<IEnumerable<OrdenDto>> ObtenerOrdenes()
    {
        return await dbContext.Orden.Include(i => i.OrdenItems).Select(s => new OrdenDto
        {
            Descripcion = s.Descripcion,
            Estado = s.Estado,
            Fecha = s.Fecha,
            Id = s.Id,
            Total = s.Total,
            OrdenItems = s.OrdenItems.Select(s => new OrdenItemDto
            {
                Cantidad = s.Cantidad,
                ProductoId = s.ProductoId,
                PrecioUnitario = s.PrecioUnitario,
                Id = s.Id,
                OrdenId = s.OrdenId
            }).ToList()
        }).ToListAsync();
    }
}
