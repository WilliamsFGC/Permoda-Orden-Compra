using MediatR;
using OrdenCompra.Application.Comandos;
using OrdenCompra.Application.Dto;
using OrdenCompra.Application.Recursos;
using OrdenCompra.Domain.Interfaces;

namespace OrdenCompra.Application.Handler;

/// <summary>
/// Modificar Cantidad del ítem de la orden de compra
/// </summary>
public class ModificarCantidadHandler(IOrdenItemRepository ordenItemRepository) : IRequestHandler<ModificarCantidadCommand, RespuestaGenerica<int>>
{
    public async Task<RespuestaGenerica<int>> Handle(ModificarCantidadCommand request, CancellationToken cancellationToken)
    {
        return new RespuestaGenerica<int>
        {
            Resultado = await ordenItemRepository.ActualizarCantidad(request.OrdenItemId, request.Cantidad),
            Mensaje = string.Format(MensajeApplication.Actualizar, "la cantidad")
        };
    }
}
