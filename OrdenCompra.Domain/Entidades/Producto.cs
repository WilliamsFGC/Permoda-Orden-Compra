namespace OrdenCompra.Domain.Entidades;

/// <summary>
/// Entidad de producto
/// </summary>
public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public decimal Precio { get; set; }
    public string ImagenUrl { get; set; } = "";
    public ICollection<OrdenItem> OrdenItems { get; set; } = new HashSet<OrdenItem>();
    public ICollection<Inventario> Inventarios { get; set; } = new HashSet<Inventario>();
}
