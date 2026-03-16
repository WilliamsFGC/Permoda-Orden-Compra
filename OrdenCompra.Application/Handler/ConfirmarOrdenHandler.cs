using MediatR;
using OrdenCompra.Application.Comandos;
using OrdenCompra.Application.Dto;
using OrdenCompra.Application.Interfaces;
using OrdenCompra.Application.Recursos;
using OrdenCompra.Domain.Entidades;
using OrdenCompra.Domain.Eventos;
using OrdenCompra.Domain.Interfaces;

namespace OrdenCompra.Application.Handler;

public class ConfirmarOrdenHandler(Domain.Interfaces.IOrdenRepository ordenRepository, IInventarioService inventarioService, IEventBus eventBus) : IRequestHandler<ConfirmarOrdenCommand, RespuestaGenerica<bool>>
{
    /// <summary>
    /// Confirmar orden
    /// </summary>
    /// <param name="request">Datos de la orden de compra</param>
    /// <param name="cancellationToken"></param>
    /// <returns>true/false si se confirma la orden de compra</returns>
    public async Task<RespuestaGenerica<bool>> Handle(ConfirmarOrdenCommand request, CancellationToken cancellationToken)
    {
        RespuestaGenerica<bool> result = new RespuestaGenerica<bool>();
        Orden orden = await ordenRepository.ObtenerPorId(request.ordenId);

        if (!orden.OrdenItems.Any())
        {
            result.Mensaje = string.Format(MensajeApplication.ConfirmarOrdenCompraError, request.ordenId);
            return result;
        }

        result = await inventarioService.VerificarStockAsync(request.ordenId);
        if (result.Error || !result.Resultado)
        {
            return result;
        }

        result.Mensaje = string.Format(MensajeApplication.ConfirmarOrdenCompra, request.ordenId);

        await eventBus.PublishAsync(new OrdenConfirmadaEvent(request.ordenId, orden.OrdenItems.Select(s => new OrdenItemDto { Cantidad = s.Cantidad, ProductoId = s.ProductoId }).ToList()));

        return result;
    }
}
