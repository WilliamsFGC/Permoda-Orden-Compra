using MediatR;
using OrdenCompra.Application.Dto;

namespace OrdenCompra.Application.Consultas.OrdenCompra;

/// <summary>
/// Consulta para las ordenes de compra
/// </summary>
public class ObtenerOrdenesCompraQuery() : IRequest<RespuestaGenerica<IEnumerable<OrdenDto>>>;
