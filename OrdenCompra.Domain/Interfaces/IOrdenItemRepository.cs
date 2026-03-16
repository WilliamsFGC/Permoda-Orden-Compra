namespace OrdenCompra.Domain.Interfaces;

/// <summary>
/// Interfaz para los ítem de la orden de compra
/// </summary>
public interface IOrdenItemRepository
{
    /// <summary>
    /// Eliminar ítem de la orden de compra
    /// </summary>
    /// <param name="ordenItemId">Id del ítem de la orden de compra</param>
    /// <returns>Id del ítem eliminado</returns>
    Task<int> EliminarItemAsync(int ordenItemId);

    /// <summary>
    /// Actualizar la cantidad del ítem
    /// </summary>
    /// <param name="ordenItemId">Id del ítem de la orden de compra</param>
    /// <param name="cantidad">Cantidad a pedir</param>
    /// <returns>Cantidad establecida</returns>
    Task<int> ActualizarCantidad(int ordenItemId, int cantidad);
}
