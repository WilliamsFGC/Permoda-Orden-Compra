namespace OrdenCompra.Application.Dto;

public class OrdenItemDto
{
    public int Id { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public int OrdenId { get; set; }
}
