namespace OrdenCompra.Application.Dto;

/// <summary>
/// Respuesta generica de los servicios
/// </summary>
/// <typeparam name="T">Tipo de resultado a devolver</typeparam>
public class RespuestaGenerica<T>
{
    public T? Resultado { get; set; }
    public string Mensaje { get; set; } = "";
    public bool Error { get; set; }
    public int StatusCode { get; set; } = 200;
}
