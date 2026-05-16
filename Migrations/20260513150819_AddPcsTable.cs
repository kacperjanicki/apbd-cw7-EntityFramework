using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apbd_cw7_EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddPcsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "s33985");

            migrationBuilder.CreateTable(
                name: "Pcs",
                schema: "s33985",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pcs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pcs",
                schema: "s33985");
        }
    }
}
