using OrdenCompra.Application.Dto;

namespace OrdenCompra.Application.Interfaces;

/// <summary>
/// Repositorio service para implementar dto
/// </summary>
public interface IProductoRepository
{
    /// <summary>
    /// Obtener productos
    /// </summary>
    /// <returns>Lista de productos</returns>
    /// <exception cref="NotImplementedException"></exception>
    Task<IEnumerable<ProductoDto>> ObtenerProductos();
}
