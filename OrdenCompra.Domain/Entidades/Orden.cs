namespace OrdenCompra.Domain.Entidades;

/// <summary>
/// Entidad para definir la orden de compra
/// </summary>
public class Orden
{
    public int Id { get; set; }
    public decimal Total { get; private set; }
    public DateTime Fecha { get; private set; } = DateTime.Now;
    public string Estado { get; private set; } = "CREADA";
    public string Descripcion { get; set; } = "";
    public ICollection<OrdenItem> OrdenItems { get; private set; } = new HashSet<OrdenItem>();

    /// <summary>
    /// Agregar ítem
    /// </summary>
    /// <param name="productoId">Id del producto</param>
    /// <param name="cantidad">Cantidad del producto</param>
    public void AgregarItem(int productoId, int cantidad)
    {
        if (cantidad <= 0)
            return;
        OrdenItems.Add(new OrdenItem { Cantidad = cantidad, ProductoId = productoId });
    }
}
