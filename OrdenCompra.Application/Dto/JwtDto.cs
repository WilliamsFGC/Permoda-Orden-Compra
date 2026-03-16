namespace OrdenCompra.Application.Dto;

/// <summary>
/// Dto para obtener sección del Jwt
/// </summary>
public class JwtDto
{
    public string JwtKey { get; set; } = "";
    public string Audience { get; set; } = "";
    public string Issuer { get; set; } = "";
}
