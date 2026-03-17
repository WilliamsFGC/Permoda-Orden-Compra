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
    /// <summary>
    /// Modificar cantidades
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Número de ítems modificados</returns>
    public async Task<RespuestaGenerica<int>> Handle(ModificarCantidadCommand request, CancellationToken cancellationToken)
    {
        List<OrdenItemDto> items = request.Items.ToList();
        for (int i = 0; i < items.Count; i++)
        {
            OrdenItemDto item = items[i];
            await ordenItemRepository.ActualizarCantidad(item.Id, item.Cantidad);
        }
        return new RespuestaGenerica<int>
        {
            Resultado = items.Count,
            Mensaje = string.Format(MensajeApplication.Actualizar, "la cantidad")
        };
    }
}
