using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrdenCompra.Application.Comandos;
using OrdenCompra.Application.Consultas.OrdenCompra;
using OrdenCompra.Application.Dto;
using OrdenCompra.Application.Handler;

namespace OrdenCompra.Api.Controllers;

/// <summary>
/// Controlador para las ordenes de compra
/// </summary>
/// <param name="mediator">Mediator CQRS</param>
[Route("api/[controller]")]
[ApiController]
public class OrdenCompraController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Crear orden de compra
    /// </summary>
    /// <param name="command">Registro a crear</param>
    /// <returns>Respuesta génerica con el id de la orden de compra</returns>
    [HttpPost]
    public async Task<IActionResult> Crear(CrearOrdenCommand command)
    {
        RespuestaGenerica<int> orden = await mediator.Send(command);
        return StatusCode(orden.StatusCode, orden);
    }

    /// <summary>
    /// Agregar ítem a la orden de compra
    /// </summary>
    /// <param name="command">Datos para agregar ítem a la orden de compra</param>
    /// <returns>Respuesta génerica con el Id del ítem creado</returns>
    [HttpPost("AgregarItem")]
    public async Task<IActionResult> AgregarItem(AgregarItemCommand command)
    {
        RespuestaGenerica<int> item = await mediator.Send(command);
        return StatusCode(item.StatusCode, item);
    }

    /// <summary>
    /// Confirmar orden de compra
    /// </summary>
    /// <param name="command">Datos para la confirmación de la orden de compra</param>
    /// <returns>Respuesta génerica con true/false si se confirma la orden de compra</returns>
    [HttpPost("{ordenId}/confirmar")]
    public async Task<IActionResult> ConfirmarOrden(int ordenId)
    {
        RespuestaGenerica<bool> respuesta = await mediator.Send(new ConfirmarOrdenCommand(ordenId));
        return StatusCode(respuesta.StatusCode, respuesta);
    }

    /// <summary>
    /// Eliminar orden de compra
    /// </summary>
    /// <param name="ordenId">Id de la orden de compra</param>
    /// <returns>Id de la orden de compra eliminada</returns>
    [HttpDelete("{ordenId}")]
    public async Task<IActionResult> EliminarOrdenCompra(int ordenId)
    {
        RespuestaGenerica<int> resultado = await mediator.Send(new EliminarOrdenCompraCommand(ordenId));
        return StatusCode(resultado.StatusCode, resultado);
    }

    /// <summary>
    /// Obtener ordenes de compra
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> ObtenerOrdenesCompra()
    {
        RespuestaGenerica<IEnumerable<OrdenDto>> resultado = await mediator.Send(new ObtenerOrdenesCompraQuery());
        return StatusCode(resultado.StatusCode, resultado);
    }
}
