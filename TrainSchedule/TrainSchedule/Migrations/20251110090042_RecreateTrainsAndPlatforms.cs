using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainSchedule.Migrations
{
    /// <inheritdoc />
    public partial class RecreateTrainsAndPlatforms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trains_Platform_PlatformId",
                table: "Trains");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Platform",
                table: "Platform");

            migrationBuilder.RenameTable(
                name: "Platform",
                newName: "Platforms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Platforms",
                table: "Platforms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trains_Platforms_PlatformId",
                table: "Trains",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trains_Platforms_PlatformId",
                table: "Trains");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Platforms",
                table: "Platforms");

            migrationBuilder.RenameTable(
                name: "Platforms",
                newName: "Platform");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Platform",
                table: "Platform",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trains_Platform_PlatformId",
                table: "Trains",
                column: "PlatformId",
                principalTable: "Platform",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
