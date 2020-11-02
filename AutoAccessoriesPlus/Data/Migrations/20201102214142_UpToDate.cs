using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoAccessoriesPlus.Data.Migrations
{
    public partial class UpToDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03895gh1–8321–5bef-bgea-48t832w83ey7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4968262d-bd99-465f-b315-455ec65f8ddc", "AQAAAAEAACcQAAAAEO79y14yd9dkexiXvGn5ztPR/+2eKiejnJLmZDQ2pPQ+/fi6afl71lwI9I+j4YqKaQ==", "3d7cfee7-499c-47f6-87fa-e69dc72249ae" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03895gh1–8321–5bef-bgea-48t832w83ey7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2ba99f9-ad66-4a53-8a8f-5f0c5c95b421", "AQAAAAEAACcQAAAAEKC2dfHa24Ag8DsJnwXSGu58CiECHZ5uOboc6hfBGQiCnKR8Jpq8zSRWNM9TZCOR3w==", "9260ef08-3a20-4943-8590-7bad91cdb343" });
        }
    }
}
