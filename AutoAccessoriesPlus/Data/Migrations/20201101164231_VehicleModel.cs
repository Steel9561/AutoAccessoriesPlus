using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoAccessoriesPlus.Data.Migrations
{
    public partial class VehicleModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03895gh1–8321–5bef-bgea-48t832w83ey7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "987171d0-b563-4263-9934-05dc3a3c4001", "AQAAAAEAACcQAAAAEMkBDxJ+7xCAA0/Dp8MhmljKEWlOLDG/0X2h28sZhcLcU91zf49P8xNcTIKfiCyjlw==", "6c8273a7-c585-4fa5-9f25-0737a0a3d538" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03895gh1–8321–5bef-bgea-48t832w83ey7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc0e57ea-aa07-4ff9-be7e-eb118e740939", "AQAAAAEAACcQAAAAEEFER4RoGEVKpNbfkxQ1JjKLjqXyXykP/RY4RrAfsN3ElzLMrZGrP1SARKD3hFCBCQ==", "13d2b331-a911-4baa-9b2c-ce09f3baf831" });
        }
    }
}
