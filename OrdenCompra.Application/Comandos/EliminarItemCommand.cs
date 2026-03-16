using MediatR;
using OrdenCompra.Application.Dto;

namespace OrdenCompra.Application.Comandos;

/// <summary>
/// Comando para eliminar item de la orden de compra
/// </summary>
public record class EliminarItemCommand(int OrdenItemId) : IRequest<RespuestaGenerica<int>>;
