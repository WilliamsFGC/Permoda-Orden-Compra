using MediatR;
using OrdenCompra.Application.Dto;

namespace OrdenCompra.Application.Comandos;

/// <summary>
/// Record para crear la orden de compra
/// </summary>
public record CrearOrdenCommand(string Descripcion) : IRequest<RespuestaGenerica<int>>;
