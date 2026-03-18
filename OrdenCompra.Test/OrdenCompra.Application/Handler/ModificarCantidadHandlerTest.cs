using Moq;
using OrdenCompra.Application.Comandos;
using OrdenCompra.Application.Dto;
using OrdenCompra.Application.Handler;
using OrdenCompra.Domain.Interfaces;

namespace OrdenCompra.Test.OrdenCompra.Application.Handler;

[TestClass]
public class ModificarCantidadHandlerTest
{
    [TestMethod]
    public void Handle()
    {
        Mock<IOrdenItemRepository> ordenItemRepository = new Mock<IOrdenItemRepository>();
        ordenItemRepository.Setup(s => s.ActualizarCantidad(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(1);
        ModificarCantidadHandler handler = new ModificarCantidadHandler(ordenItemRepository.Object);
        List<OrdenItemDto> list = new List<OrdenItemDto>
        {
            new OrdenItemDto { Id = 1, Cantidad = 2 },
            new OrdenItemDto { Id = 2, Cantidad = 4 }
        };
        ModificarCantidadCommand command = new ModificarCantidadCommand(list);
        RespuestaGenerica<int> respuesta = handler.Handle(command, new CancellationToken()).Result;
        Assert.AreEqual(list.Count, respuesta.Resultado);
    }
}
