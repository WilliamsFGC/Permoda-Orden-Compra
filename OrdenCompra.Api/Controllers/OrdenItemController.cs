using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrdenCompra.Application.Comandos;
using OrdenCompra.Application.Dto;

namespace OrdenCompra.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenItemController(IMediator mediator) : ControllerBase
    {
        [HttpDelete("{ordenItemId}")]
        public async Task<IActionResult> EliminarOrdenItem(int ordenItemId)
        {
            RespuestaGenerica<int> resultado = await mediator.Send(new EliminarItemCommand(ordenItemId));
            return StatusCode(resultado.StatusCode, resultado);
        }

        [HttpPatch("{ordenItemId}/{cantidad}")]
        public async Task<IActionResult> ModificarCantidadItem(int ordenItemId, int cantidad)
        {
            RespuestaGenerica<int> resultado = await mediator.Send(new ModificarCantidadCommand(ordenItemId, cantidad));
            return StatusCode(resultado.StatusCode, resultado);
        }
    }
}
