using MediatR;
using OrdenCompra.Application.Dto;

namespace OrdenCompra.Application.Comandos;

public record ConfirmarOrdenCommand(int ordenId) : IRequest<RespuestaGenerica<bool>>;
