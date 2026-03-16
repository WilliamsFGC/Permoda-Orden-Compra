using OrdenCompra.Domain.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace OrdenCompra.Infrastructure.Mensajeria;

/// <summary>
/// Registrar evento de Orden confirmada
/// </summary>
public class OrdenConfirmadaEventBus : IEventBus
{
    private readonly ConnectionFactory factory;

    public OrdenConfirmadaEventBus()
    {
        factory = new ConnectionFactory
        {
            HostName = "localhost",
            UserName = "admin",
            Password = "admin",
            Port = 5672
        };
    }

    /// <summary>
    /// Publicar evento:
    /// Crea conexión - Crea Canal - publica eveto
    /// </summary>
    /// <typeparam name="T">Tipo genérico</typeparam>
    /// <param name="event">Valor a enviar al RabbitMQ</param>
    /// <returns>Tarea</returns>
    public async Task PublishAsync<T>(T @event)
    {
        await using var connection = await factory.CreateConnectionAsync();
        await using var channel = await connection.CreateChannelAsync();
        string nombreEvento = "ordencompra.confirmada";
        await channel.ExchangeDeclareAsync(
            exchange: nombreEvento,
            type: ExchangeType.Fanout);

        var json = JsonSerializer.Serialize(@event);
        var body = Encoding.UTF8.GetBytes(json);

        await channel.BasicPublishAsync(
            exchange: nombreEvento,
            routingKey: "",
            body: body);
    }
}
