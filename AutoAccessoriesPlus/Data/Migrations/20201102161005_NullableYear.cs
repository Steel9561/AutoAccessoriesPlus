using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoAccessoriesPlus.Data.Migrations
{
    public partial class NullableYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Vehicles",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03895gh1–8321–5bef-bgea-48t832w83ey7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a38a4d36-1399-47f8-a673-6eecef86c801", "AQAAAAEAACcQAAAAEJzNSjntlmLKOthDLDrlp9o4QtOg3ay3vIrDGh77kyuhuCtKVnD+mEACJaarlytFUw==", "d8d8b619-e8da-4b4f-8ccb-0a2c732f3d1c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Vehicles",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03895gh1–8321–5bef-bgea-48t832w83ey7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99bc34b1-f93a-40e2-a7e3-d4aa63020bee", "AQAAAAEAACcQAAAAEPoCH/sDrTS9E6NobyAvzeBks5GNl/eqY2NM8N4KLdaloAotptWV9May51dPm/hpRw==", "95a1f3c5-b3a8-44b9-8c34-ff0492c8beff" });
        }
    }
}
