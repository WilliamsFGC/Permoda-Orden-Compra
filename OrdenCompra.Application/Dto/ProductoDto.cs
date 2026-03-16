namespace OrdenCompra.Application.Dto;

/// <summary>
/// Dto para productos
/// </summary>
public class ProductoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public decimal Precio { get; set; }
    public string ImagenUrl { get; set; } = "";
}
