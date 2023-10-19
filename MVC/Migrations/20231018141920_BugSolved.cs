using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Migrations
{
    /// <inheritdoc />
    public partial class BugSolved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Makes_Makes_VehicleMakeId",
                table: "Makes");

            migrationBuilder.DropIndex(
                name: "IX_Makes_VehicleMakeId",
                table: "Makes");

            migrationBuilder.DropColumn(
                name: "VehicleMakeId",
                table: "Makes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleMakeId",
                table: "Makes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Makes_VehicleMakeId",
                table: "Makes",
                column: "VehicleMakeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Makes_Makes_VehicleMakeId",
                table: "Makes",
                column: "VehicleMakeId",
                principalTable: "Makes",
                principalColumn: "Id");
        }
    }
}
