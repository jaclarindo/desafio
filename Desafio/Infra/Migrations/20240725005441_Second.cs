using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedido_Pedidos_id_pedido",
                table: "ItensPedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos");

            migrationBuilder.RenameTable(
                name: "Pedidos",
                newName: "Pedido");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ItensPedido",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ItensPedido",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ItensPedido",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ItensPedido",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Pago",
                table: "Pedido",
                newName: "pago");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pedido",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Pedido",
                newName: "update_at");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Pedido",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "EmailCliente",
                table: "Pedido",
                newName: "email_cliente");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Pedido",
                newName: "data_criacao");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Pedido",
                newName: "create_at");

            migrationBuilder.AlterColumn<string>(
                name: "email_cliente",
                table: "Pedido",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pedido",
                table: "Pedido",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedido_Pedido_id_pedido",
                table: "ItensPedido",
                column: "id_pedido",
                principalTable: "Pedido",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedido_Pedido_id_pedido",
                table: "ItensPedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pedido",
                table: "Pedido");

            migrationBuilder.RenameTable(
                name: "Pedido",
                newName: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ItensPedido",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "ItensPedido",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "ItensPedido",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "ItensPedido",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "pago",
                table: "Pedidos",
                newName: "Pago");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Pedidos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "update_at",
                table: "Pedidos",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "Pedidos",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "email_cliente",
                table: "Pedidos",
                newName: "EmailCliente");

            migrationBuilder.RenameColumn(
                name: "data_criacao",
                table: "Pedidos",
                newName: "DataCriacao");

            migrationBuilder.RenameColumn(
                name: "create_at",
                table: "Pedidos",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<string>(
                name: "EmailCliente",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedido_Pedidos_id_pedido",
                table: "ItensPedido",
                column: "id_pedido",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
