using OrdenCompra.Application.Dto;

namespace OrdenCompra.Application.Interfaces;

public interface IInventarioService
{
    /// <summary>
    /// Verificar stock disponible de la orden de compra
    /// </summary>
    /// <param name="OrdenId">Id de la orden de compra</param>
    /// <returns>true/false si hay stock disponible</returns>
    Task<RespuestaGenerica<bool>> VerificarStockAsync(int OrdenId);
}
