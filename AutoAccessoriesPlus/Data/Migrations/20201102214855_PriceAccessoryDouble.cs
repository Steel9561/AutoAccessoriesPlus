using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoAccessoriesPlus.Data.Migrations
{
    public partial class PriceAccessoryDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Accessory",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03895gh1–8321–5bef-bgea-48t832w83ey7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6904da85-0673-489e-b25e-4a5087c02fa9", "AQAAAAEAACcQAAAAEDbX1DS3AmKAPRS/wv2v1NZLgvJBIEMfZPMlEeVi+QwzaNHSvueHMi+DLzJ1BQUbQw==", "8817a641-b9b1-4a06-a239-8892587ba5b2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Accessory",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03895gh1–8321–5bef-bgea-48t832w83ey7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4968262d-bd99-465f-b315-455ec65f8ddc", "AQAAAAEAACcQAAAAEO79y14yd9dkexiXvGn5ztPR/+2eKiejnJLmZDQ2pPQ+/fi6afl71lwI9I+j4YqKaQ==", "3d7cfee7-499c-47f6-87fa-e69dc72249ae" });
        }
    }
}
