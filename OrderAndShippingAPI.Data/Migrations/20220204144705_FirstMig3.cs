using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderAndShippingAPI.Data.Migrations
{
    public partial class FirstMig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 4, 17, 47, 4, 464, DateTimeKind.Local).AddTicks(7211),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 4, 17, 36, 53, 685, DateTimeKind.Local).AddTicks(1792));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2022, 2, 4, 17, 47, 4, 475, DateTimeKind.Local).AddTicks(804));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2022, 2, 4, 17, 47, 4, 475, DateTimeKind.Local).AddTicks(2193));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 4, 17, 36, 53, 685, DateTimeKind.Local).AddTicks(1792),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 4, 17, 47, 4, 464, DateTimeKind.Local).AddTicks(7211));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2022, 2, 4, 17, 36, 53, 696, DateTimeKind.Local).AddTicks(2339));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2022, 2, 4, 17, 36, 53, 696, DateTimeKind.Local).AddTicks(3719));
        }
    }
}
