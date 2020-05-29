using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.HR.Models.Db.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedAt", "IsActive", "Name", "Notes" },
                values: new object[] { 1, new DateTime(2020, 5, 29, 18, 14, 22, 488, DateTimeKind.Local).AddTicks(114), true, "Demo Project 1", null });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedAt", "IsActive", "Name", "Notes" },
                values: new object[] { 2, new DateTime(2020, 5, 29, 18, 14, 22, 491, DateTimeKind.Local).AddTicks(2267), true, "Demo Project 2", null });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedAt", "IsActive", "Name", "Notes" },
                values: new object[] { 3, new DateTime(2020, 5, 29, 18, 14, 22, 491, DateTimeKind.Local).AddTicks(2317), true, "Demo Project 3", null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "IsActive", "Name" },
                values: new object[] { 1, new DateTime(2020, 5, 29, 18, 14, 22, 493, DateTimeKind.Local).AddTicks(4072), true, "Demo Role 1" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "IsActive", "Name" },
                values: new object[] { 2, new DateTime(2020, 5, 29, 18, 14, 22, 493, DateTimeKind.Local).AddTicks(4102), true, "Demo Role 2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "IsActive", "Notes", "Skills" },
                values: new object[] { 1, new DateTime(2020, 5, 29, 18, 14, 22, 496, DateTimeKind.Local).AddTicks(1403), "demo1@test.com", "Demo User 1", true, null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "IsActive", "Notes", "Skills" },
                values: new object[] { 2, new DateTime(2020, 5, 29, 18, 14, 22, 496, DateTimeKind.Local).AddTicks(1480), "demo2@test.com", "Demo User 2", true, null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "IsActive", "Notes", "Skills" },
                values: new object[] { 3, new DateTime(2020, 5, 29, 18, 14, 22, 496, DateTimeKind.Local).AddTicks(1486), "demo3@test.com", "Demo User 3", true, null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "IsActive", "Notes", "Skills" },
                values: new object[] { 4, new DateTime(2020, 5, 29, 18, 14, 22, 496, DateTimeKind.Local).AddTicks(1492), "demo4@test.com", "Demo User 4", true, null, null });

            migrationBuilder.InsertData(
                table: "UserAllocations",
                columns: new[] { "Id", "ActualHours", "ContractedHours", "ContractedHoursApproved", "CreatedAt", "EndDate", "IsActive", "Notes", "ProjectId", "RoleId", "StartDate", "UserId" },
                values: new object[] { 1, (byte)20, (byte)32, true, new DateTime(2020, 5, 29, 18, 14, 22, 503, DateTimeKind.Local).AddTicks(79), new DateTime(2019, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, 1, 1, new DateTime(2019, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "UserProjects",
                columns: new[] { "Id", "CreatedAt", "IsActive", "ProjectId", "UserId" },
                values: new object[] { 1, new DateTime(2020, 5, 29, 18, 14, 22, 504, DateTimeKind.Local).AddTicks(6118), true, 1, 1 });

            migrationBuilder.InsertData(
                table: "UserProjects",
                columns: new[] { "Id", "CreatedAt", "IsActive", "ProjectId", "UserId" },
                values: new object[] { 2, new DateTime(2020, 5, 29, 18, 14, 22, 504, DateTimeKind.Local).AddTicks(6206), true, 2, 1 });

            migrationBuilder.InsertData(
                table: "UserProjects",
                columns: new[] { "Id", "CreatedAt", "IsActive", "ProjectId", "UserId" },
                values: new object[] { 4, new DateTime(2020, 5, 29, 18, 14, 22, 504, DateTimeKind.Local).AddTicks(6216), true, 3, 1 });

            migrationBuilder.InsertData(
                table: "UserProjects",
                columns: new[] { "Id", "CreatedAt", "IsActive", "ProjectId", "UserId" },
                values: new object[] { 3, new DateTime(2020, 5, 29, 18, 14, 22, 504, DateTimeKind.Local).AddTicks(6212), true, 2, 2 });

            migrationBuilder.InsertData(
                table: "UserProjects",
                columns: new[] { "Id", "CreatedAt", "IsActive", "ProjectId", "UserId" },
                values: new object[] { 5, new DateTime(2020, 5, 29, 18, 14, 22, 504, DateTimeKind.Local).AddTicks(6221), true, 3, 3 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "IsActive", "RoleId", "UserId" },
                values: new object[] { 1, new DateTime(2020, 5, 29, 18, 14, 22, 506, DateTimeKind.Local).AddTicks(2297), true, 1, 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "IsActive", "RoleId", "UserId" },
                values: new object[] { 2, new DateTime(2020, 5, 29, 18, 14, 22, 506, DateTimeKind.Local).AddTicks(2369), true, 2, 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "IsActive", "RoleId", "UserId" },
                values: new object[] { 4, new DateTime(2020, 5, 29, 18, 14, 22, 506, DateTimeKind.Local).AddTicks(2379), true, 1, 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "IsActive", "RoleId", "UserId" },
                values: new object[] { 3, new DateTime(2020, 5, 29, 18, 14, 22, 506, DateTimeKind.Local).AddTicks(2375), true, 1, 2 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "IsActive", "RoleId", "UserId" },
                values: new object[] { 5, new DateTime(2020, 5, 29, 18, 14, 22, 506, DateTimeKind.Local).AddTicks(2383), true, 1, 3 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "IsActive", "RoleId", "UserId" },
                values: new object[] { 6, new DateTime(2020, 5, 29, 18, 14, 22, 506, DateTimeKind.Local).AddTicks(2387), true, 2, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAllocations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserProjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserProjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserProjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserProjects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserProjects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
