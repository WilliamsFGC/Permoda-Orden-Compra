using Moq;
using OrdenCompra.Application.Comandos;
using OrdenCompra.Application.Dto;
using OrdenCompra.Application.Handler;
using OrdenCompra.Application.Recursos;
using OrdenCompra.Domain.Interfaces;

namespace OrdenCompra.Test.OrdenCompra.Application.Handler;

[TestClass]
public class EliminarItemHandlerTest
{
    [TestMethod]
    public void Handle()
    {
        Mock<IOrdenItemRepository> ordenItemRepository = new Mock<IOrdenItemRepository>();
        ordenItemRepository.Setup(s => s.EliminarItemAsync(It.IsAny<int>())).ReturnsAsync(1);
        EliminarItemCommand command = new EliminarItemCommand(1);
        EliminarItemHandler handler = new EliminarItemHandler(ordenItemRepository.Object);
        RespuestaGenerica<int> resultado = handler.Handle(command, new CancellationToken()).Result;
        Assert.AreEqual(string.Format(MensajeApplication.Eliminar, "el ítem"), resultado.Mensaje);
    }
}
