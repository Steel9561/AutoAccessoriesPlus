using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoAccessoriesPlus.Data.Migrations
{
    public partial class SeedUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "532467h2-hfr4–63ej-nhre-75shrewf89r8", "532467h2-hfr4–63ej-nhre-75shrewf89r8", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "03895gh1–8321–5bef-bgea-48t832w83ey7", 0, "ff909150-14cb-4d1f-b8f3-0d4f45f856ee", "steel9561@yahoo.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEBwmYljRXbu/U1Z55WVtmjphl75s5w+q7XmV5ryxe8YUgel5bWW5TDeeAToI+547gg==", null, false, "ef3edb78-a153-49af-8ce6-f2e34a7d0d2b", false, "steel9561@yahoo.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "03895gh1–8321–5bef-bgea-48t832w83ey7", "532467h2-hfr4–63ej-nhre-75shrewf89r8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "03895gh1–8321–5bef-bgea-48t832w83ey7", "532467h2-hfr4–63ej-nhre-75shrewf89r8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "532467h2-hfr4–63ej-nhre-75shrewf89r8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03895gh1–8321–5bef-bgea-48t832w83ey7");
        }
    }
}
