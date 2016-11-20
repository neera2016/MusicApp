using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MusicApp.Migrations
{
    public partial class DateJoined : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    playlistID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    userId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.playlistID);
                    table.ForeignKey(
                        name: "FK_Playlists_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistExtension",
                columns: table => new
                {
                    playlistID = table.Column<int>(nullable: false),
                    albumID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistExtension", x => new { x.playlistID, x.albumID });
                    table.ForeignKey(
                        name: "FK_PlaylistExtension_Albums_albumID",
                        column: x => x.albumID,
                        principalTable: "Albums",
                        principalColumn: "AlbumID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistExtension_Playlists_playlistID",
                        column: x => x.playlistID,
                        principalTable: "Playlists",
                        principalColumn: "playlistID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<DateTime>(
                name: "DateJoined",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_userId",
                table: "Playlists",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistExtension_albumID",
                table: "PlaylistExtension",
                column: "albumID");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistExtension_playlistID",
                table: "PlaylistExtension",
                column: "playlistID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateJoined",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PlaylistExtension");

            migrationBuilder.DropTable(
                name: "Playlists");
        }
    }
}
