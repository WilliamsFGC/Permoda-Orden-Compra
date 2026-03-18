using Moq;
using OrdenCompra.Application.Comandos;
using OrdenCompra.Application.Dto;
using OrdenCompra.Application.Handler;
using OrdenCompra.Application.Recursos;
using OrdenCompra.Domain.Interfaces;

namespace OrdenCompra.Test.OrdenCompra.Application.Handler;

[TestClass]
public class EliminarOrdenCompraHandlerTest
{
    [TestMethod]
    public void Handle()
    {
        Mock<IOrdenRepository> ordenRepository = new Mock<IOrdenRepository>();
        ordenRepository.Setup(o => o.EliminarOrdenAsync(It.IsAny<int>())).ReturnsAsync(1);
        EliminarOrdenCompraHandler handler = new EliminarOrdenCompraHandler(ordenRepository.Object);
        EliminarOrdenCompraCommand command = new EliminarOrdenCompraCommand(1);
        RespuestaGenerica<int> resultado = handler.Handle(command, new CancellationToken()).Result;
        Assert.AreEqual(string.Format(MensajeApplication.Eliminar, "la orden de compra"), resultado.Mensaje);
    }
}
