using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrdenCompra.Application.Consultas.Producto;
using OrdenCompra.Application.Dto;

namespace OrdenCompra.Api.Controllers
{
    /// <summary>
    /// Controlador de productos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// Obtener productos
        /// </summary>
        /// <returns>Todos los productos</returns>
        [HttpGet]
        public async Task<IActionResult> ObtenerProductos()
        {
            RespuestaGenerica<IEnumerable<ProductoDto>> resultado = await mediator.Send(new ObtenerProductosQuery());
            return StatusCode(resultado.StatusCode, resultado);
        }
    }
}
