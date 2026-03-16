using MediatR;
using OrdenCompra.Application.Consultas.OrdenCompra;
using OrdenCompra.Application.Dto;
using OrdenCompra.Application.Interfaces;

namespace OrdenCompra.Application.Handler.Consultas;

/// <summary>
/// Handler para consulta de ordenes de compra
/// </summary>
/// <param name="ordenRepository"></param>
public class ObtenerOrdenesCompraHandler(IOrdenRepository ordenRepository) : IRequestHandler<ObtenerOrdenesCompraQuery, RespuestaGenerica<IEnumerable<OrdenDto>>>
{
    /// <summary>
    /// Obtener ordenes de compra
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<RespuestaGenerica<IEnumerable<OrdenDto>>> Handle(ObtenerOrdenesCompraQuery request, CancellationToken cancellationToken)
    {
        return new RespuestaGenerica<IEnumerable<OrdenDto>>
        {
            Resultado = await ordenRepository.ObtenerOrdenes()
        };
    }
}
