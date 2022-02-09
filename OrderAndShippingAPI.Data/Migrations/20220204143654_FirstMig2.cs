using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderAndShippingAPI.Data.Migrations
{
    public partial class FirstMig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 4, 17, 36, 53, 685, DateTimeKind.Local).AddTicks(1792),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 1, 18, 10, 34, 621, DateTimeKind.Local).AddTicks(9542));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 1, 18, 10, 34, 621, DateTimeKind.Local).AddTicks(9542),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 4, 17, 36, 53, 685, DateTimeKind.Local).AddTicks(1792));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2022, 2, 1, 18, 10, 34, 634, DateTimeKind.Local).AddTicks(2571));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2022, 2, 1, 18, 10, 34, 634, DateTimeKind.Local).AddTicks(4104));
        }
    }
}
