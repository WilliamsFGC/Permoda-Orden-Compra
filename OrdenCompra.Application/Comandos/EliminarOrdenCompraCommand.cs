using MediatR;
using OrdenCompra.Application.Dto;

namespace OrdenCompra.Application.Comandos;

/// <summary>
/// Eliminar orden de compra
/// </summary>
/// <param name="OrdenId">Id de la orden de compra</param>
public record EliminarOrdenCompraCommand(int OrdenId) : IRequest<RespuestaGenerica<int>>;
