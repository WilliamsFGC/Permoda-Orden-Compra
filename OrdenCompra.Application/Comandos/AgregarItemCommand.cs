using MediatR;
using OrdenCompra.Application.Dto;

namespace OrdenCompra.Application.Comandos;

/// <summary>
/// Command para agregar item a la orden de compra
/// </summary>
/// <param name="ordenId">Id de la orden de compra</param>
/// <param name="productoId">Id del producto</param>
/// <param name="cantidad">Cantidad del producto</param>
public record AgregarItemCommand(int OrdenId, int ProductoId, int Cantidad) : IRequest<RespuestaGenerica<int>>;
