using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apbd_cw7_EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddRemainingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Clear existing rows before structural column changes to avoid FK violations
            migrationBuilder.Sql("DELETE FROM [s33985].[Components]");

            migrationBuilder.DropForeignKey(
                name: "FK_Components_ComponentManufacturers_ComputerManufacturerId",
                schema: "s33985",
                table: "Components");

            migrationBuilder.RenameColumn(
                name: "ComputerManufacturerId",
                schema: "s33985",
                table: "Components",
                newName: "ComponentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Components_ComputerManufacturerId",
                schema: "s33985",
                table: "Components",
                newName: "IX_Components_ComponentTypeId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "s33985",
                table: "Components",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ComponentManufacturerId",
                schema: "s33985",
                table: "Components",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ComponentTypes",
                schema: "s33985",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abbreviation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PCComponents",
                schema: "s33985",
                columns: table => new
                {
                    PcId = table.Column<int>(type: "int", nullable: false),
                    ComponentCode = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCComponents", x => new { x.PcId, x.ComponentCode });
                    table.ForeignKey(
                        name: "FK_PCComponents_Components_ComponentCode",
                        column: x => x.ComponentCode,
                        principalSchema: "s33985",
                        principalTable: "Components",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PCComponents_PCs_PcId",
                        column: x => x.PcId,
                        principalSchema: "s33985",
                        principalTable: "PCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Components_ComponentManufacturerId",
                schema: "s33985",
                table: "Components",
                column: "ComponentManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_PCComponents_ComponentCode",
                schema: "s33985",
                table: "PCComponents",
                column: "ComponentCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Components_ComponentManufacturers_ComponentManufacturerId",
                schema: "s33985",
                table: "Components",
                column: "ComponentManufacturerId",
                principalSchema: "s33985",
                principalTable: "ComponentManufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Components_ComponentTypes_ComponentTypeId",
                schema: "s33985",
                table: "Components",
                column: "ComponentTypeId",
                principalSchema: "s33985",
                principalTable: "ComponentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_ComponentManufacturers_ComponentManufacturerId",
                schema: "s33985",
                table: "Components");

            migrationBuilder.DropForeignKey(
                name: "FK_Components_ComponentTypes_ComponentTypeId",
                schema: "s33985",
                table: "Components");

            migrationBuilder.DropTable(
                name: "ComponentTypes",
                schema: "s33985");

            migrationBuilder.DropTable(
                name: "PCComponents",
                schema: "s33985");

            migrationBuilder.DropIndex(
                name: "IX_Components_ComponentManufacturerId",
                schema: "s33985",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "ComponentManufacturerId",
                schema: "s33985",
                table: "Components");

            migrationBuilder.RenameColumn(
                name: "ComponentTypeId",
                schema: "s33985",
                table: "Components",
                newName: "ComputerManufacturerId");

            migrationBuilder.RenameIndex(
                name: "IX_Components_ComponentTypeId",
                schema: "s33985",
                table: "Components",
                newName: "IX_Components_ComputerManufacturerId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "s33985",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Components_ComponentManufacturers_ComputerManufacturerId",
                schema: "s33985",
                table: "Components",
                column: "ComputerManufacturerId",
                principalSchema: "s33985",
                principalTable: "ComponentManufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
