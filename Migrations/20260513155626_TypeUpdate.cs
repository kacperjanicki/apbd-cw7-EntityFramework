using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apbd_cw7_EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class TypeUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pcs",
                schema: "s33985",
                table: "Pcs");

            migrationBuilder.RenameTable(
                name: "Pcs",
                schema: "s33985",
                newName: "PCs",
                newSchema: "s33985");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "s33985",
                table: "PCs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PCs",
                schema: "s33985",
                table: "PCs",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PCs",
                schema: "s33985",
                table: "PCs");

            migrationBuilder.RenameTable(
                name: "PCs",
                schema: "s33985",
                newName: "Pcs",
                newSchema: "s33985");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "s33985",
                table: "Pcs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pcs",
                schema: "s33985",
                table: "Pcs",
                column: "Id");
        }
    }
}
