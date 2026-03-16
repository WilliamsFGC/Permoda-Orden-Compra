using MediatR;
using OrdenCompra.Application.Dto;

namespace OrdenCompra.Application.Consultas.Producto;

/// <summary>
/// Command para obtener todos los productos
/// </summary>
public record ObtenerProductosQuery() : IRequest<RespuestaGenerica<IEnumerable<ProductoDto>>>;
