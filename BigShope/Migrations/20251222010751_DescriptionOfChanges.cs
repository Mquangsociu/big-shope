using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BigShope.Migrations
{
    /// <inheritdoc />
    public partial class DescriptionOfChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 22, 8, 7, 49, 204, DateTimeKind.Local).AddTicks(2153));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 22, 8, 7, 49, 204, DateTimeKind.Local).AddTicks(2168));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 22, 8, 7, 49, 204, DateTimeKind.Local).AddTicks(2170));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 22, 8, 7, 49, 204, DateTimeKind.Local).AddTicks(2172));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 22, 8, 7, 49, 204, DateTimeKind.Local).AddTicks(2173));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 22, 8, 7, 49, 204, DateTimeKind.Local).AddTicks(2177));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 22, 8, 7, 49, 204, DateTimeKind.Local).AddTicks(2181));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 22, 8, 7, 49, 204, DateTimeKind.Local).AddTicks(2183));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 21, 17, 7, 40, 625, DateTimeKind.Local).AddTicks(9351));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 21, 17, 7, 40, 625, DateTimeKind.Local).AddTicks(9384));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 21, 17, 7, 40, 625, DateTimeKind.Local).AddTicks(9387));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 21, 17, 7, 40, 625, DateTimeKind.Local).AddTicks(9438));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 21, 17, 7, 40, 625, DateTimeKind.Local).AddTicks(9441));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 21, 17, 7, 40, 625, DateTimeKind.Local).AddTicks(9444));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 21, 17, 7, 40, 625, DateTimeKind.Local).AddTicks(9446));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 21, 17, 7, 40, 625, DateTimeKind.Local).AddTicks(9449));
        }
    }
}
