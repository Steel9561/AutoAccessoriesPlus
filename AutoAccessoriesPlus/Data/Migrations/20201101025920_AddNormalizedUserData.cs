using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoAccessoriesPlus.Data.Migrations
{
    public partial class AddNormalizedUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03895gh1–8321–5bef-bgea-48t832w83ey7",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc0e57ea-aa07-4ff9-be7e-eb118e740939", "steel9561@yahoo.com", "steel9561@yahoo.com", "AQAAAAEAACcQAAAAEEFER4RoGEVKpNbfkxQ1JjKLjqXyXykP/RY4RrAfsN3ElzLMrZGrP1SARKD3hFCBCQ==", "13d2b331-a911-4baa-9b2c-ce09f3baf831" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03895gh1–8321–5bef-bgea-48t832w83ey7",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff909150-14cb-4d1f-b8f3-0d4f45f856ee", null, null, "AQAAAAEAACcQAAAAEBwmYljRXbu/U1Z55WVtmjphl75s5w+q7XmV5ryxe8YUgel5bWW5TDeeAToI+547gg==", "ef3edb78-a153-49af-8ce6-f2e34a7d0d2b" });
        }
    }
}
