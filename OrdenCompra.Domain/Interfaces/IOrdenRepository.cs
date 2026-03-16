using OrdenCompra.Domain.Entidades;

namespace OrdenCompra.Domain.Interfaces;

/// <summary>
/// Repositorio para orden de compra
/// </summary>
public interface IOrdenRepository
{
    /// <summary>
    /// Crear orden de compra
    /// </summary>
    /// <param name="orden">Entidad de la orden de compra</param>
    /// <returns>Id de la orden de compra</returns>
    Task<int> AgregarAsync(Orden orden);

    /// <summary>
    /// Obtener orden por id
    /// </summary>
    /// <param name="ordenId">Id de la orden</param>
    /// <returns>Entidad de la orden</returns>
    Task<Orden> ObtenerPorId(int ordenId);

    /// <summary>
    /// Agregar ítem a la orden de compra
    /// </summary>
    /// <param name="item">Agregar ítem a la orden de compra</param>
    /// <returns></returns>
    Task<int> AgregarItemAsync(OrdenItem item);

    /// <summary>
    /// Eliminar orden de compra
    /// </summary>
    /// <param name="ordenId">Id de la orden de compra</param>
    /// <returns>Id de la orden de compra eliminada</returns>
    Task<int> EliminarOrdenAsync(int ordenId);
}
