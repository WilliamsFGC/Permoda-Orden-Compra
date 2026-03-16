using MediatR;
using OrdenCompra.Application.Dto;

namespace OrdenCompra.Application.Comandos;

/// <summary>
/// Modificar cantidad del ítem de la orden de compra
/// </summary>
/// <param name="OrdenItemId">Id del ítem de la orden de compra</param>
/// <param name="cantidad">Cantidad a establecer</param>
public record ModificarCantidadCommand(int OrdenItemId, int Cantidad) : IRequest<RespuestaGenerica<int>>;
