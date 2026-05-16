using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apbd_cw7_EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class CompletePcEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Weight",
                schema: "s33985",
                table: "PCs",
                type: "float(5)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "s33985",
                table: "PCs",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                schema: "s33985",
                table: "PCs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Warranty",
                schema: "s33985",
                table: "PCs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "s33985",
                table: "PCs");

            migrationBuilder.DropColumn(
                name: "Stock",
                schema: "s33985",
                table: "PCs");

            migrationBuilder.DropColumn(
                name: "Warranty",
                schema: "s33985",
                table: "PCs");

            migrationBuilder.AlterColumn<float>(
                name: "Weight",
                schema: "s33985",
                table: "PCs",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float(5)");
        }
    }
}
