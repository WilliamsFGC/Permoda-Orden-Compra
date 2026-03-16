using MediatR;
using OrdenCompra.Application.Consultas.Producto;
using OrdenCompra.Application.Dto;
using OrdenCompra.Application.Interfaces;

namespace OrdenCompra.Application.Handler.Consultas;

/// <summary>
/// Handler para obtener productos
/// </summary>
public class ObtenerProductosHandler(IProductoRepository productoRepository) : IRequestHandler<ObtenerProductosQuery, RespuestaGenerica<IEnumerable<ProductoDto>>>
{
    /// <summary>
    /// Obtener productos
    /// </summary>
    /// <param name="request">Datos de la solicitud</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Todos los productos</returns>
    public async Task<RespuestaGenerica<IEnumerable<ProductoDto>>> Handle(ObtenerProductosQuery request, CancellationToken cancellationToken)
    {
        return new RespuestaGenerica<IEnumerable<ProductoDto>>
        {
            Resultado = await productoRepository.ObtenerProductos()
        };
    }
}
