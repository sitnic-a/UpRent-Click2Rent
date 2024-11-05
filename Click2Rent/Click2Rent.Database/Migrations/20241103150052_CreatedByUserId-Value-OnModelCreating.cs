using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Click2Rent.Database.Migrations
{
    /// <inheritdoc />
    public partial class CreatedByUserIdValueOnModelCreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "IsDeleted", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 3, 16, 0, 51, 640, DateTimeKind.Local).AddTicks(5993), false, new DateTime(2024, 11, 3, 16, 0, 51, 640, DateTimeKind.Local).AddTicks(6046) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "IsDeleted", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 3, 16, 0, 51, 640, DateTimeKind.Local).AddTicks(6553), false, new DateTime(2024, 11, 3, 16, 0, 51, 640, DateTimeKind.Local).AddTicks(6556) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedByUserId", "CreatedDate", "ModifiedDate" },
                values: new object[] { 1, new DateTime(2024, 11, 3, 16, 0, 51, 640, DateTimeKind.Local).AddTicks(6430), new DateTime(2024, 11, 3, 16, 0, 51, 640, DateTimeKind.Local).AddTicks(6435) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Roles");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 2, 12, 28, 5, 778, DateTimeKind.Local).AddTicks(9918), new DateTime(2024, 11, 2, 12, 28, 5, 778, DateTimeKind.Local).AddTicks(9963) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 2, 12, 28, 5, 779, DateTimeKind.Local).AddTicks(156), new DateTime(2024, 11, 2, 12, 28, 5, 779, DateTimeKind.Local).AddTicks(158) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedByUserId", "CreatedDate", "ModifiedDate" },
                values: new object[] { 0, new DateTime(2024, 11, 2, 12, 28, 5, 779, DateTimeKind.Local).AddTicks(130), new DateTime(2024, 11, 2, 12, 28, 5, 779, DateTimeKind.Local).AddTicks(133) });
        }
    }
}
