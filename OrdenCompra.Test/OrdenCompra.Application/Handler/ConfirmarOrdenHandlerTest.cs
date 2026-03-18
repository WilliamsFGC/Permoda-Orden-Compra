using Moq;
using OrdenCompra.Application.Comandos;
using OrdenCompra.Application.Dto;
using OrdenCompra.Application.Handler;
using OrdenCompra.Application.Interfaces;
using OrdenCompra.Application.Recursos;
using OrdenCompra.Domain.Entidades;
using OrdenCompra.Domain.Interfaces;

namespace OrdenCompra.Test.OrdenCompra.Application.Handler;

[TestClass]
public class ConfirmarOrdenHandlerTest
{
    [TestMethod]
    [DataRow(false, false)]
    [DataRow(true, false)]
    [DataRow(true, true)]
    public void Handle(bool conItems, bool conStock)
    {
        Mock<Domain.Interfaces.IOrdenRepository> ordenRepository = new Mock<Domain.Interfaces.IOrdenRepository>();
        Mock<IInventarioService> inventarioService = new Mock<IInventarioService>();
        Mock<IEventBus> eventBus = new Mock<IEventBus>();

        ordenRepository.Setup(o => o.ObtenerPorId(It.IsAny<int>())).ReturnsAsync(new Orden() { OrdenItems = conItems ? new List<OrdenItem> { new OrdenItem() } : new List<OrdenItem>() });
        inventarioService.Setup(i => i.VerificarStockAsync(It.IsAny<int>())).ReturnsAsync(new RespuestaGenerica<bool> {  Resultado = conStock });

        ConfirmarOrdenHandler handler = new ConfirmarOrdenHandler(ordenRepository.Object, inventarioService.Object, eventBus.Object);
        ConfirmarOrdenCommand command = new ConfirmarOrdenCommand(1);
        RespuestaGenerica<bool> resultado = handler.Handle(command, new CancellationToken()).Result;

        if (!conItems)
        {
            string.Format(MensajeApplication.ConfirmarOrdenCompraError, command.ordenId);
        }
        else if (!conStock)
        {
            Assert.AreEqual(false, resultado.Resultado);
        }
        else
        {
            Assert.AreEqual(string.Format(MensajeApplication.ConfirmarOrdenCompra, command.ordenId), resultado.Mensaje);
        }
        
    }
}
