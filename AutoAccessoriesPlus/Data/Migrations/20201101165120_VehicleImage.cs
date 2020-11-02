using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoAccessoriesPlus.Data.Migrations
{
    public partial class VehicleImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "VehicleImage",
                table: "Vehicles",
                nullable: true);          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleImage",
                table: "Vehicles");
       
        }
    }
}
