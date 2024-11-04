using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Click2Rent.Database.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataChangeTableUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 4, 17, 46, 17, 561, DateTimeKind.Local).AddTicks(173), new DateTime(2024, 11, 4, 17, 46, 17, 561, DateTimeKind.Local).AddTicks(224) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 4, 17, 46, 17, 561, DateTimeKind.Local).AddTicks(227), new DateTime(2024, 11, 4, 17, 46, 17, 561, DateTimeKind.Local).AddTicks(229) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 4, 17, 46, 17, 561, DateTimeKind.Local).AddTicks(231), new DateTime(2024, 11, 4, 17, 46, 17, 561, DateTimeKind.Local).AddTicks(232) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Comment", "CreatedByUserId", "CreatedDate", "ModifiedDate" },
                values: new object[] { "", 1, new DateTime(2024, 11, 4, 17, 46, 17, 561, DateTimeKind.Local).AddTicks(425), new DateTime(2024, 11, 4, 17, 46, 17, 561, DateTimeKind.Local).AddTicks(427) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 4, 17, 46, 17, 561, DateTimeKind.Local).AddTicks(400), new DateTime(2024, 11, 4, 17, 46, 17, 561, DateTimeKind.Local).AddTicks(403) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 4, 17, 18, 42, 367, DateTimeKind.Local).AddTicks(9477), new DateTime(2024, 11, 4, 17, 18, 42, 367, DateTimeKind.Local).AddTicks(9543) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 4, 17, 18, 42, 367, DateTimeKind.Local).AddTicks(9551), new DateTime(2024, 11, 4, 17, 18, 42, 367, DateTimeKind.Local).AddTicks(9557) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 4, 17, 18, 42, 367, DateTimeKind.Local).AddTicks(9562), new DateTime(2024, 11, 4, 17, 18, 42, 367, DateTimeKind.Local).AddTicks(9567) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Comment", "CreatedByUserId", "CreatedDate", "ModifiedDate" },
                values: new object[] { null, 0, new DateTime(2024, 11, 4, 17, 18, 42, 368, DateTimeKind.Local).AddTicks(200), new DateTime(2024, 11, 4, 17, 18, 42, 368, DateTimeKind.Local).AddTicks(205) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 4, 17, 18, 42, 368, DateTimeKind.Local).AddTicks(120), new DateTime(2024, 11, 4, 17, 18, 42, 368, DateTimeKind.Local).AddTicks(130) });
        }
    }
}
