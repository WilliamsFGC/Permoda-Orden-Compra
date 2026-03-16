using MediatR;
using OrdenCompra.Application.Comandos;
using OrdenCompra.Application.Dto;
using OrdenCompra.Application.Recursos;
using OrdenCompra.Domain.Entidades;
using OrdenCompra.Domain.Interfaces;

namespace OrdenCompra.Application.Handler;

public class CrearOrdenHandler(IOrdenRepository ordenRepository) : IRequestHandler<CrearOrdenCommand, RespuestaGenerica<int>>
{
    /// <summary>
    /// Crear orden de compra
    /// </summary>
    /// <param name="request">Registro de la orden de compra</param>
    /// <param name="cancellationToken">Token de cancelación de la tarea</param>
    /// <returns>Respuesta generica con el id insertado</returns>
    public async Task<RespuestaGenerica<int>> Handle(CrearOrdenCommand request, CancellationToken cancellationToken)
    {
        Orden orden = new Orden()
        {
            Descripcion = request.Descripcion
        };
        RespuestaGenerica<int> resultado = new RespuestaGenerica<int>
        {
            Resultado = await ordenRepository.AgregarAsync(orden),
            Mensaje = string.Format(MensajeApplication.Crear, "la orden de compra")
        };
        return resultado;
    }
}
