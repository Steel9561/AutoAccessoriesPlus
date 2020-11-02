using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoAccessoriesPlus.Data.Migrations
{
    public partial class ValidationMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03895gh1–8321–5bef-bgea-48t832w83ey7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d524377a-f971-46f1-9362-5c07b54e7525", "AQAAAAEAACcQAAAAEJFW9ml1T00pEwPgqbLvn6cwSQIUyeeOxpnVC9/+Mzs/3E048UDOGMjrqW/zfWgFrA==", "cdae85c4-8039-403a-839e-1e04c44fcf8f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03895gh1–8321–5bef-bgea-48t832w83ey7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25313c14-45eb-41a0-83ba-cec54f06b7bd", "AQAAAAEAACcQAAAAEI6Rpdv1USHlYFz29zSiKNGijCyM029eSPwPjhJQFL7zUc3u6PDOBogCkHnwAoS1fw==", "a947fa58-88bc-4ef0-877a-0aeae28109a2" });
        }
    }
}
