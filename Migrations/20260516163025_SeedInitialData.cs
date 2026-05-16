using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace apbd_cw7_EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Clear tables in FK-safe order before seeding to avoid PK conflicts on shared DB
            migrationBuilder.Sql("DELETE FROM [s33985].[PCComponents]");
            migrationBuilder.Sql("DELETE FROM [s33985].[Components]");
            migrationBuilder.Sql("DELETE FROM [s33985].[PCs]");
            migrationBuilder.Sql("DBCC CHECKIDENT ('[s33985].[PCs]', RESEED, 0)");
            migrationBuilder.Sql("DELETE FROM [s33985].[ComponentManufacturers]");
            migrationBuilder.Sql("DBCC CHECKIDENT ('[s33985].[ComponentManufacturers]', RESEED, 0)");
            migrationBuilder.Sql("DELETE FROM [s33985].[ComponentTypes]");
            migrationBuilder.Sql("DBCC CHECKIDENT ('[s33985].[ComponentTypes]', RESEED, 0)");

            migrationBuilder.InsertData(
                schema: "s33985",
                table: "ComponentManufacturers",
                columns: new[] { "Id", "Abbreviation", "FoundationDate", "FullName" },
                values: new object[,]
                {
                    { 1, "INTEL", new DateTime(1968, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intel Corporation" },
                    { 2, "AMD", new DateTime(1969, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Advanced Micro Devices" },
                    { 3, "NVIDIA", new DateTime(1993, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nvidia Corporation" }
                });

            migrationBuilder.InsertData(
                schema: "s33985",
                table: "ComponentTypes",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[,]
                {
                    { 1, "CPU", "Central Processing Unit" },
                    { 2, "GPU", "Graphics Processing Unit" },
                    { 3, "RAM", "Random Access Memory" },
                    { 4, "SSD", "Solid State Drive" }
                });

            migrationBuilder.InsertData(
                schema: "s33985",
                table: "PCs",
                columns: new[] { "Id", "CreatedAt", "Name", "Stock", "Warranty", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), "Gaming Beast X", 5, 36, 12.5f },
                    { 2, new DateTime(2026, 4, 15, 13, 30, 0, 0, DateTimeKind.Unspecified), "Office Mini Pro", 12, 24, 4.2f },
                    { 3, new DateTime(2026, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "Workstation Ultra", 3, 48, 18f }
                });

            migrationBuilder.InsertData(
                schema: "s33985",
                table: "Components",
                columns: new[] { "Code", "ComponentManufacturerId", "ComponentTypeId", "Description", "Name" },
                values: new object[,]
                {
                    { "I9-14900K", 1, 1, "High-end desktop processor", "Intel Core i9-14900K" },
                    { "R9-7950X", 2, 1, "16-core workstation CPU", "AMD Ryzen 9 7950X" },
                    { "RTX4090", 3, 2, "Top-tier Nvidia GPU", "Nvidia GeForce RTX 4090" },
                    { "RX7900XTX", 2, 2, "Flagship AMD graphics card", "AMD Radeon RX 7900 XTX" }
                });

            migrationBuilder.InsertData(
                schema: "s33985",
                table: "PCComponents",
                columns: new[] { "ComponentCode", "PcId", "Amount" },
                values: new object[,]
                {
                    { "I9-14900K", 1, 1 },
                    { "RTX4090", 1, 1 },
                    { "R9-7950X", 2, 1 },
                    { "I9-14900K", 3, 2 },
                    { "RX7900XTX", 3, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "s33985",
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "s33985",
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "s33985",
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "I9-14900K", 1 });

            migrationBuilder.DeleteData(
                schema: "s33985",
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "RTX4090", 1 });

            migrationBuilder.DeleteData(
                schema: "s33985",
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "R9-7950X", 2 });

            migrationBuilder.DeleteData(
                schema: "s33985",
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "I9-14900K", 3 });

            migrationBuilder.DeleteData(
                schema: "s33985",
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "RX7900XTX", 3 });

            migrationBuilder.DeleteData(
                schema: "s33985",
                table: "Components",
                keyColumn: "Code",
                keyValue: "I9-14900K");

            migrationBuilder.DeleteData(
                schema: "s33985",
                table: "Components",
                keyColumn: "Code",
                keyValue: "R9-7950X");

            migrationBuilder.DeleteData(
                schema: "s33985",
                table: "Components",
                keyColumn: "Code",
                keyValue: "RTX4090");

            migrationBuilder.DeleteData(
                schema: "s33985",
                table: "Components",
                keyColumn: "Code",
                keyValue: "RX7900XTX");

            migrationBuilder.DeleteData(
                schema: "s33985",
                table: "PCs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "s33985",
                table: "PCs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "s33985",
                table: "PCs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "s33985",
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "s33985",
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "s33985",
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "s33985",
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "s33985",
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
