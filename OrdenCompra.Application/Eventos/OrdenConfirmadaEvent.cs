using OrdenCompra.Application.Dto;

namespace OrdenCompra.Domain.Eventos;

public record OrdenConfirmadaEvent(int ordenId, List<OrdenItemDto> items);