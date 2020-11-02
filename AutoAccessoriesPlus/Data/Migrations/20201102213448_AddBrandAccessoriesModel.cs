using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoAccessoriesPlus.Data.Migrations
{
    public partial class AddBrandAccessoriesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleBrandAccessories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelatedAccessoryId = table.Column<int>(nullable: true),
                    VehicleId = table.Column<int>(nullable: false),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleBrandAccessories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleBrandAccessories_Accessory_RelatedAccessoryId",
                        column: x => x.RelatedAccessoryId,
                        principalTable: "Accessory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleBrandAccessories_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03895gh1–8321–5bef-bgea-48t832w83ey7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2ba99f9-ad66-4a53-8a8f-5f0c5c95b421", "AQAAAAEAACcQAAAAEKC2dfHa24Ag8DsJnwXSGu58CiECHZ5uOboc6hfBGQiCnKR8Jpq8zSRWNM9TZCOR3w==", "9260ef08-3a20-4943-8590-7bad91cdb343" });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBrandAccessories_RelatedAccessoryId",
                table: "VehicleBrandAccessories",
                column: "RelatedAccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBrandAccessories_VehicleId",
                table: "VehicleBrandAccessories",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleBrandAccessories");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03895gh1–8321–5bef-bgea-48t832w83ey7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de0d3e6c-e43d-4f28-9d21-a5cd1b026448", "AQAAAAEAACcQAAAAEOA/XKTYXwYhlVdcNHDPz7264nWIJWrNSwFTGTycPLzOKhIGO+f5VmZ2aDiTn2m16g==", "7ecfd7ed-708d-4871-9307-7af4e5fd0bc5" });
        }
    }
}
