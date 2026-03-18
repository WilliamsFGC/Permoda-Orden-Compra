using Moq;
using OrdenCompra.Application.Comandos;
using OrdenCompra.Application.Dto;
using OrdenCompra.Application.Handler;
using OrdenCompra.Application.Recursos;
using OrdenCompra.Domain.Entidades;
using OrdenCompra.Domain.Interfaces;

namespace OrdenCompra.Test.OrdenCompra.Application.Handler
{
    [TestClass]
    public class CrearOrdenHandlerTest
    {
        [TestMethod]
        public void Handler()
        {
            Mock<IOrdenRepository> ordenRepository = new Mock<IOrdenRepository>();
            ordenRepository.Setup(o => o.AgregarAsync(It.IsAny<Orden>())).ReturnsAsync(1);
            CrearOrdenHandler handler = new CrearOrdenHandler(ordenRepository.Object);
            CrearOrdenCommand command = new CrearOrdenCommand("Orden de compra");
            RespuestaGenerica<int> resultado = handler.Handle(command, new CancellationToken()).Result;
            Assert.AreEqual(string.Format(MensajeApplication.Crear, "la orden de compra"), resultado.Mensaje);
        }
    }
}
