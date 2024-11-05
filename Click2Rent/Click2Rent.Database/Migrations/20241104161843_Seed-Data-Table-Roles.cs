using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Click2Rent.Database.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataTableRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 4, 17, 18, 42, 367, DateTimeKind.Local).AddTicks(9477), new DateTime(2024, 11, 4, 17, 18, 42, 367, DateTimeKind.Local).AddTicks(9543) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedByUserId", "CreatedDate", "IsDeleted", "Locked", "ModifiedByUserId", "ModifiedDate", "Name", "Version", "Visible" },
                values: new object[,]
                {
                    { 2, 0, new DateTime(2024, 11, 4, 17, 18, 42, 367, DateTimeKind.Local).AddTicks(9551), false, false, 0, new DateTime(2024, 11, 4, 17, 18, 42, 367, DateTimeKind.Local).AddTicks(9557), "User", 0, true },
                    { 3, 0, new DateTime(2024, 11, 4, 17, 18, 42, 367, DateTimeKind.Local).AddTicks(9562), false, false, 0, new DateTime(2024, 11, 4, 17, 18, 42, 367, DateTimeKind.Local).AddTicks(9567), "Izvjestaji", 0, true }
                });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 4, 17, 18, 42, 368, DateTimeKind.Local).AddTicks(200), new DateTime(2024, 11, 4, 17, 18, 42, 368, DateTimeKind.Local).AddTicks(205) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 4, 17, 18, 42, 368, DateTimeKind.Local).AddTicks(120), new DateTime(2024, 11, 4, 17, 18, 42, 368, DateTimeKind.Local).AddTicks(130) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 3, 16, 0, 51, 640, DateTimeKind.Local).AddTicks(5993), new DateTime(2024, 11, 3, 16, 0, 51, 640, DateTimeKind.Local).AddTicks(6046) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 3, 16, 0, 51, 640, DateTimeKind.Local).AddTicks(6553), new DateTime(2024, 11, 3, 16, 0, 51, 640, DateTimeKind.Local).AddTicks(6556) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 3, 16, 0, 51, 640, DateTimeKind.Local).AddTicks(6430), new DateTime(2024, 11, 3, 16, 0, 51, 640, DateTimeKind.Local).AddTicks(6435) });
        }
    }
}
