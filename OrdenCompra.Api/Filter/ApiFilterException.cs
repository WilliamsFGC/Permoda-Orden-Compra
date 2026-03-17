using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OrdenCompra.Application.Dto;
using System.Net;

namespace OrdenCompra.Api.Filter
{
    /// <summary>
    /// Clase de filtro de excepciones
    /// </summary>
    public class ApiFilterException : ExceptionFilterAttribute
    {
        private readonly ILogger<ApiFilterException> logger;

        /// <summary>
        /// Contructor para injectar ILogger
        /// </summary>
        /// <param name="logger">ILogger nativo de .net core</param>
        public ApiFilterException(ILogger<ApiFilterException> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Controlador de excepciones globales
        /// </summary>
        /// <param name="context">Contexto de la excepción</param>
        /// <returns>Tarea a completar</returns>
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            OnException(context);
            RespuestaGenerica<bool> result = new RespuestaGenerica<bool>();
            result.Error = true;
            result.StatusCode = (int)HttpStatusCode.InternalServerError;
#if DEBUG
            result.Mensaje = $"{context.Exception.Message}\n{context.Exception.StackTrace}";
#else
            result.Mensaje = "Ocurrió un error interno del sistema";
#endif
            logger.LogError("Method: {Method}, Path: {Path}, TraceId: {TraceId}\n {Error}\n",
                context.HttpContext.Request.Method,
                context.HttpContext.Request.Path,
                context.HttpContext.TraceIdentifier,
                context.Exception.Message);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(result);
            return Task.CompletedTask;
        }
    }
}
