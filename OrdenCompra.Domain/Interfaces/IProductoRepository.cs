using OrdenCompra.Domain.Entidades;

namespace OrdenCompra.Domain.Interfaces;

/// <summary>
/// Interfaz repositorio para producto
/// </summary>
public interface IProductoRepository
{
    /// <summary>
    /// Obtener producto por Id
    /// </summary>
    /// <param name="productoId">Id del producto</param>
    /// <returns>Producto</returns>
    Task<Producto> ObtenerPorIdAsync(int productoId);
}
