namespace OrdenCompra.Domain.Interfaces;

public interface IEventBus
{
    /// <summary>
    /// Publicar evento
    /// </summary>
    /// <typeparam name="T">Tipo a publicar</typeparam>
    /// <param name="event">Valor a publicar</param>
    /// <returns>Tarea awaitable</returns>
    Task PublishAsync<T>(T @event);
}
