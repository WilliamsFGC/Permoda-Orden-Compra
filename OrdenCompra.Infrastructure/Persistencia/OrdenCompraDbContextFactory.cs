using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OrdenCompra.Infrastructure.Persistencia
{
    /// <summary>
    /// Conexión de migraciones
    /// </summary>
    internal class OrdenCompraDbContextFactory : IDesignTimeDbContextFactory<OrdenCompraDbContext>
    {
        /// <summary>
        /// Contexto para migraciones
        /// </summary>
        /// <param name="args">Argumentos</param>
        /// <returns></returns>
        public OrdenCompraDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrdenCompraDbContext>();

            optionsBuilder.UseSqlite("Data Source=D:/Programacion/CSharp/Koaj/OrdenCompra/OrdenCompra.Api/ordencompra.db");

            return new OrdenCompraDbContext(optionsBuilder.Options);
        }
    }
}
