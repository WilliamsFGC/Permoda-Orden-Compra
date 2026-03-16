using MediatR;
using OrdenCompra.Application.Comandos;
using OrdenCompra.Application.Dto;
using OrdenCompra.Application.Recursos;
using OrdenCompra.Domain.Interfaces;

namespace OrdenCompra.Application.Handler;

/// <summary>
/// Handler para eliminar ítem de la orden de compra
/// </summary>
public class EliminarItemHandler(IOrdenItemRepository ordenItemRepository) : IRequestHandler<EliminarItemCommand, RespuestaGenerica<int>>
{
    /// <summary>
    /// Eliminar ítem de la orden de compra
    /// </summary>
    /// <param name="request">Datos de la solicitud</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<RespuestaGenerica<int>> Handle(EliminarItemCommand request, CancellationToken cancellationToken)
    {
        return new RespuestaGenerica<int>
        {
            Resultado = await ordenItemRepository.EliminarItemAsync(request.OrdenItemId),
            Mensaje = string.Format(MensajeApplication.Eliminar, "el ítem")
        };
    }
}
