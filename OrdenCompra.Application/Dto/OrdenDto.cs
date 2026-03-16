namespace OrdenCompra.Application.Dto;

/// <summary>
/// Dto para ordenes de compra
/// </summary>
public class OrdenDto
{
    public int Id { get; set; }
    public decimal Total { get; set; }
    public DateTime Fecha { get; set; }
    public string Estado { get; set; } = "";
    public string Descripcion { get; set; } = "";
    public List<OrdenItemDto> OrdenItems { get; set; }
}
