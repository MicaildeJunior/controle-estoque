using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleEstoque.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoverNumeroMovimentacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroMovimentacao",
                table: "MovimentacoesEstoque");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NumeroMovimentacao",
                table: "MovimentacoesEstoque",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
