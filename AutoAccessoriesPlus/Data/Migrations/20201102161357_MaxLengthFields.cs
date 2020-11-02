using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoAccessoriesPlus.Data.Migrations
{
    public partial class MaxLengthFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Vehicles",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Make",
                table: "Vehicles",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03895gh1–8321–5bef-bgea-48t832w83ey7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25313c14-45eb-41a0-83ba-cec54f06b7bd", "AQAAAAEAACcQAAAAEI6Rpdv1USHlYFz29zSiKNGijCyM029eSPwPjhJQFL7zUc3u6PDOBogCkHnwAoS1fw==", "a947fa58-88bc-4ef0-877a-0aeae28109a2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Make",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03895gh1–8321–5bef-bgea-48t832w83ey7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a38a4d36-1399-47f8-a673-6eecef86c801", "AQAAAAEAACcQAAAAEJzNSjntlmLKOthDLDrlp9o4QtOg3ay3vIrDGh77kyuhuCtKVnD+mEACJaarlytFUw==", "d8d8b619-e8da-4b4f-8ccb-0a2c732f3d1c" });
        }
    }
}
