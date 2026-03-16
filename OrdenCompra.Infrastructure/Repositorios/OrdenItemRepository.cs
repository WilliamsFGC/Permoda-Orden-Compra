using Microsoft.EntityFrameworkCore;
using OrdenCompra.Domain.Entidades;
using OrdenCompra.Domain.Interfaces;
using OrdenCompra.Infrastructure.Persistencia;

namespace OrdenCompra.Infrastructure.Repositorios;

/// <summary>
/// Repositorio para los ítem de la orden de compra
/// </summary>
public class OrdenItemRepository(OrdenCompraDbContext dbContext) : IOrdenItemRepository
{
    /// <summary>
    /// Actualizar la cantidad del ítem
    /// </summary>
    /// <param name="ordenItemId">Id del ítem de la orden de compra</param>
    /// <param name="cantidad">Cantidad a pedir</param>
    /// <returns>Cantidad establecida</returns>
    public async Task<int> ActualizarCantidad(int ordenItemId, int cantidad)
    {
        OrdenItem item = await dbContext.OrdenItem.FirstAsync(f => f.Id == ordenItemId);
        item.Cantidad = cantidad;
        await dbContext.SaveChangesAsync();
        return cantidad;
    }

    /// <summary>
    /// Eliminar ítem de la orden de compra
    /// </summary>
    /// <param name="ordenItemId">Id del ítem de la orden de compra</param>
    /// <returns>Id del ítem eliminado</returns>
    public async Task<int> EliminarItemAsync(int ordenItemId)
    {
        OrdenItem item = await dbContext.OrdenItem.FirstAsync(f => f.Id == ordenItemId);
        dbContext.Entry<OrdenItem>(item).State = EntityState.Deleted;
        await dbContext.SaveChangesAsync();
        return ordenItemId;
    }
}
