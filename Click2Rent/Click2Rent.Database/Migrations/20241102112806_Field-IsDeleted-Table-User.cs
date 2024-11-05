using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Click2Rent.Database.Migrations
{
    /// <inheritdoc />
    public partial class FieldIsDeletedTableUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 2, 12, 28, 5, 779, DateTimeKind.Local).AddTicks(130), new DateTime(2024, 11, 2, 12, 28, 5, 779, DateTimeKind.Local).AddTicks(133) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 1, 20, 19, 49, 73, DateTimeKind.Local).AddTicks(6985), new DateTime(2024, 11, 1, 20, 19, 49, 73, DateTimeKind.Local).AddTicks(7035) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 1, 20, 19, 49, 73, DateTimeKind.Local).AddTicks(7221), new DateTime(2024, 11, 1, 20, 19, 49, 73, DateTimeKind.Local).AddTicks(7223) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 1, 20, 19, 49, 73, DateTimeKind.Local).AddTicks(7194), new DateTime(2024, 11, 1, 20, 19, 49, 73, DateTimeKind.Local).AddTicks(7197) });
        }
    }
}
