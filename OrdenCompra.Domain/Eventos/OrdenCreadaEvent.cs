namespace OrdenCompra.Domain.Eventos;

/// <summary>
/// Registro para enviar a kafka
/// </summary>
/// <param name="OrdenId">Id de la orden de compra</param>
/// <param name="ClienteId">Id del cliente para la orden de compra</param>
/// <param name="Total">Total neto de la orden de compra</param>
public record OrdenCreadaEvent(int OrdenId, int ClienteId, decimal Total);
