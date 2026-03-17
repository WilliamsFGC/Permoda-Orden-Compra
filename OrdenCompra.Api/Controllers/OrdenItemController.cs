using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrdenCompra.Application.Comandos;
using OrdenCompra.Application.Dto;

namespace OrdenCompra.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        /// <summary>
        /// Modificar cantidad de los ítems
        /// </summary>
        /// <param name="items">Lista de los ítems</param>
        /// <returns>Número de ítems modificados</returns>
        [HttpPatch]
        public async Task<IActionResult> ModificarCantidadItem(IEnumerable<OrdenItemDto> items)
        {
            RespuestaGenerica<int> resultado = await mediator.Send(new ModificarCantidadCommand(items));
            return StatusCode(resultado.StatusCode, resultado);
        }
    }
}
