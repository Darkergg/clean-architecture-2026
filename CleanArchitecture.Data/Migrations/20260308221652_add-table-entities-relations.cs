using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Data.Migrations
{
    /// <inheritdoc />
    public partial class addtableentitiesrelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Streamers_streamerId",
                table: "Videos");

            migrationBuilder.RenameColumn(
                name: "streamerId",
                table: "Videos",
                newName: "StreamerId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Videos",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Videos_streamerId",
                table: "Videos",
                newName: "IX_Videos_StreamerId");

            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Director",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    videoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Director", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Director_Videos_videoId",
                        column: x => x.videoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoActor",
                columns: table => new
                {
                    videoId = table.Column<int>(type: "int", nullable: false),
                    actorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoActor", x => new { x.actorId, x.videoId });
                    table.ForeignKey(
                        name: "FK_VideoActor_Actor_actorId",
                        column: x => x.actorId,
                        principalTable: "Actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoActor_Videos_videoId",
                        column: x => x.videoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Director_videoId",
                table: "Director",
                column: "videoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VideoActor_videoId",
                table: "VideoActor",
                column: "videoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Streamers_StreamerId",
                table: "Videos",
                column: "StreamerId",
                principalTable: "Streamers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Streamers_StreamerId",
                table: "Videos");

            migrationBuilder.DropTable(
                name: "Director");

            migrationBuilder.DropTable(
                name: "VideoActor");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.RenameColumn(
                name: "StreamerId",
                table: "Videos",
                newName: "streamerId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Videos",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Videos_StreamerId",
                table: "Videos",
                newName: "IX_Videos_streamerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Streamers_streamerId",
                table: "Videos",
                column: "streamerId",
                principalTable: "Streamers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
