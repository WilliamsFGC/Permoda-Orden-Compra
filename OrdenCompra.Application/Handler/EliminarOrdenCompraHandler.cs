
using MediatR;
using OrdenCompra.Application.Comandos;
using OrdenCompra.Application.Dto;
using OrdenCompra.Application.Recursos;
using OrdenCompra.Domain.Interfaces;

namespace OrdenCompra.Application.Handler;

/// <summary>
/// Eliminar orden de compra
/// </summary>
public class EliminarOrdenCompraHandler(IOrdenRepository ordenRepository) : IRequestHandler<EliminarOrdenCompraCommand, RespuestaGenerica<int>>
{
    /// <summary>
    /// Eliminar orden de compra
    /// </summary>
    /// <param name="request">Datos de la solicitud</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Id de la orden de compra eliminada</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<RespuestaGenerica<int>> Handle(EliminarOrdenCompraCommand request, CancellationToken cancellationToken)
    {
        return new RespuestaGenerica<int>
        {
            Resultado = await ordenRepository.EliminarOrdenAsync(request.OrdenId),
            Mensaje = string.Format(MensajeApplication.Eliminar, "la orden de compra")
        };
    }
}
