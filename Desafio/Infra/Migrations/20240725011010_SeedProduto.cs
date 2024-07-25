using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    public partial class SeedProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "id", "created_at", "is_deleted", "nome", "updated_at", "valor" },
                values: new object[] { 1, new DateTime(2024, 7, 24, 22, 10, 10, 513, DateTimeKind.Local).AddTicks(9530), false, "Produto 1", new DateTime(2024, 7, 24, 22, 10, 10, 513, DateTimeKind.Local).AddTicks(9540), 10.00m });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "id", "created_at", "is_deleted", "nome", "updated_at", "valor" },
                values: new object[] { 2, new DateTime(2024, 7, 24, 22, 10, 10, 513, DateTimeKind.Local).AddTicks(9541), false, "Produto 2", new DateTime(2024, 7, 24, 22, 10, 10, 513, DateTimeKind.Local).AddTicks(9542), 20.00m });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "id", "created_at", "is_deleted", "nome", "updated_at", "valor" },
                values: new object[] { 3, new DateTime(2024, 7, 24, 22, 10, 10, 513, DateTimeKind.Local).AddTicks(9542), false, "Produto 3", new DateTime(2024, 7, 24, 22, 10, 10, 513, DateTimeKind.Local).AddTicks(9543), 30.00m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
