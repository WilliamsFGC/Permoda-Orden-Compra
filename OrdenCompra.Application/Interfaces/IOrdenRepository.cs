using OrdenCompra.Application.Dto;

namespace OrdenCompra.Application.Interfaces;

/// <summary>
/// Repositorio para obtener lista de ordenes de compra
/// </summary>
public interface IOrdenRepository
{
    /// <summary>
    /// Obtener ordenes de compra
    /// </summary>
    /// <returns>Listado de ordenes de compra</returns>
    Task<IEnumerable<OrdenDto>> ObtenerOrdenes();
}
