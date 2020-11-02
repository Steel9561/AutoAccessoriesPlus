using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoAccessoriesPlus.Data.Migrations
{
    public partial class UpdateUserType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "532467h2-hfr4–63ej-nhre-75shrewf89r8",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Admin", "Admin" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03895gh1–8321–5bef-bgea-48t832w83ey7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99bc34b1-f93a-40e2-a7e3-d4aa63020bee", "AQAAAAEAACcQAAAAEPoCH/sDrTS9E6NobyAvzeBks5GNl/eqY2NM8N4KLdaloAotptWV9May51dPm/hpRw==", "95a1f3c5-b3a8-44b9-8c34-ff0492c8beff" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "532467h2-hfr4–63ej-nhre-75shrewf89r8",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "User", "User" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03895gh1–8321–5bef-bgea-48t832w83ey7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8a33e3d-4033-4a92-aca0-126252a65412", "AQAAAAEAACcQAAAAEK9s6J2SEJVVqloYmpwDsNviCzPaDYlbbTFsu0kiIOnT4lmitv5EZYd8NROKkvMp/Q==", "ab2a3005-22bd-4dd6-a72d-fbe468b2b8eb" });
        }
    }
}
