using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrdenCompra.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ColumnasTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagenUrl",
                table: "Producto",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Orden",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagenUrl",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Orden");
        }
    }
}
