using MediatR;
using OrdenCompra.Application.Comandos;
using OrdenCompra.Application.Dto;
using OrdenCompra.Application.Recursos;
using OrdenCompra.Domain.Entidades;
using OrdenCompra.Domain.Interfaces;

namespace OrdenCompra.Application.Handler;

/// <summary>
/// Handler para Agregar ítem
/// </summary>
/// <param name="ordenRepository">Repositorio de orden de compra</param>
/// <param name="productoRepository">Repositorio de producto</param>
public class AgregarItemHandler(IOrdenRepository ordenRepository, IProductoRepository productoRepository) : IRequestHandler<AgregarItemCommand, RespuestaGenerica<int>>
{
    /// <summary>
    /// Agregar item
    /// </summary>
    /// <param name="request">Datos del ítem</param>
    /// <param name="cancellationToken">Token de cancelación de la tarea</param>
    /// <returns>Respuesta Generica con el número de ítem creado</returns>
    public async Task<RespuestaGenerica<int>> Handle(AgregarItemCommand request, CancellationToken cancellationToken)
    {
        return new RespuestaGenerica<int>
        {
            Resultado = await ordenRepository.AgregarItemAsync(new OrdenItem
            {
                OrdenId = request.OrdenId,
                Cantidad = request.Cantidad,
                ProductoId = request.ProductoId,
                PrecioUnitario = (await productoRepository.ObtenerPorIdAsync(request.ProductoId)).Precio
            }),
            Mensaje = string.Format(MensajeApplication.Agregar, "el ítem")
        };
    }
}
