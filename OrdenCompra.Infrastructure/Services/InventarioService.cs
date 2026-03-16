using OrdenCompra.Application.Dto;
using OrdenCompra.Application.Interfaces;
using System.Text.Json;

namespace OrdenCompra.Infrastructure.Services;

public class InventarioService(HttpClient httpClient) : IInventarioService
{
    /// <summary>
    /// Consumir servicio para saber si hay disponibilidad de stock
    /// </summary>
    /// <param name="OrdenId">Id de la orden de compra</param>
    /// <returns>Respuesta generica con true/false indicando si hay stock disponible</returns>
    public async Task<RespuestaGenerica<bool>> VerificarStockAsync(int OrdenId)
    {
        HttpResponseMessage response = await httpClient.GetAsync($"/api/Inventario/{OrdenId}/verificar");
        RespuestaGenerica<bool> resultado = new RespuestaGenerica<bool>()
        {
            Error = !response.IsSuccessStatusCode
        };

        if (resultado.Error)
        {
            return resultado;
        }

        string json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<RespuestaGenerica<bool>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
    }
}
