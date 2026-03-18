using Moq;
using OrdenCompra.Application.Comandos;
using OrdenCompra.Application.Dto;
using OrdenCompra.Application.Handler;
using OrdenCompra.Application.Recursos;
using OrdenCompra.Domain.Entidades;
using OrdenCompra.Domain.Interfaces;

namespace OrdenCompra.Test.OrdenCompra.Application.Comandos;

[TestClass]
public class AgregarItemHandlerTest
{
    [TestMethod]
    public void Handle()
    {
        Mock<IOrdenRepository> ordenRepository = new Mock<IOrdenRepository>();
        Mock<IProductoRepository> productReository = new Mock<IProductoRepository>();
        AgregarItemHandler handler = new AgregarItemHandler(ordenRepository.Object, productReository.Object);

        ordenRepository.Setup(orden => orden.AgregarItemAsync(It.IsAny<OrdenItem>())).ReturnsAsync(1);
        productReository.Setup(p => p.ObtenerPorIdAsync(It.IsAny<int>())).ReturnsAsync(new Producto());
        AgregarItemCommand command = new AgregarItemCommand(1, 1, 1);
        RespuestaGenerica<int> resultado = handler.Handle(command, new CancellationToken()).Result;
        Assert.AreEqual(string.Format(MensajeApplication.Agregar, "el ítem"), resultado.Mensaje);
    }
}
