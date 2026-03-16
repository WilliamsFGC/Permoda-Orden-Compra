namespace OrdenCompra.Domain.Entidades;

/// <summary>
/// Ítem de la orden de compra
/// </summary>
public class OrdenItem
{
    public int Id {  get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public int OrdenId { get; set; }
    public Orden Orden { get; set; } = new Orden();
    public Producto Producto { get; set; } = new Producto();
}
