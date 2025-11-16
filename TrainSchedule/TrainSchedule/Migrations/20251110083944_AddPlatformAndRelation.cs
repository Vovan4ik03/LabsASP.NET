using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainSchedule.Migrations
{
    /// <inheritdoc />
    public partial class AddPlatformAndRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trains_TrainTypes_TrainTypeId",
                table: "Trains");

            migrationBuilder.DropTable(
                name: "TrainTypes");

            migrationBuilder.RenameColumn(
                name: "TrainTypeId",
                table: "Trains",
                newName: "PlatformId");

            migrationBuilder.RenameIndex(
                name: "IX_Trains_TrainTypeId",
                table: "Trains",
                newName: "IX_Trains_PlatformId");

            migrationBuilder.AddColumn<string>(
                name: "TrainType",
                table: "Trains",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Platform",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatformNumber = table.Column<int>(type: "int", nullable: false),
                    StationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platform", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Trains_Platform_PlatformId",
                table: "Trains",
                column: "PlatformId",
                principalTable: "Platform",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trains_Platform_PlatformId",
                table: "Trains");

            migrationBuilder.DropTable(
                name: "Platform");

            migrationBuilder.DropColumn(
                name: "TrainType",
                table: "Trains");

            migrationBuilder.RenameColumn(
                name: "PlatformId",
                table: "Trains",
                newName: "TrainTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Trains_PlatformId",
                table: "Trains",
                newName: "IX_Trains_TrainTypeId");

            migrationBuilder.CreateTable(
                name: "TrainTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainTypes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Trains_TrainTypes_TrainTypeId",
                table: "Trains",
                column: "TrainTypeId",
                principalTable: "TrainTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
