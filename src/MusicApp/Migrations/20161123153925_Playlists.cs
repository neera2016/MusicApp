using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicApp.Migrations
{
    public partial class Playlists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_AspNetUsers_userId",
                table: "Playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistExtension_Albums_albumID",
                table: "PlaylistExtension");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistExtension_Playlists_playlistID",
                table: "PlaylistExtension");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Playlists",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_AspNetUsers_UserId",
                table: "Playlists",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistExtension_Albums_AlbumID",
                table: "PlaylistExtension",
                column: "albumID",
                principalTable: "Albums",
                principalColumn: "AlbumID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistExtension_Playlists_PlaylistID",
                table: "PlaylistExtension",
                column: "playlistID",
                principalTable: "Playlists",
                principalColumn: "playlistID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameColumn(
                name: "albumID",
                table: "PlaylistExtension",
                newName: "AlbumID");

            migrationBuilder.RenameColumn(
                name: "playlistID",
                table: "PlaylistExtension",
                newName: "PlaylistID");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Playlists",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Playlists",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "playlistID",
                table: "Playlists",
                newName: "PlaylistID");

            migrationBuilder.RenameIndex(
                name: "IX_PlaylistExtension_playlistID",
                table: "PlaylistExtension",
                newName: "IX_PlaylistExtension_PlaylistID");

            migrationBuilder.RenameIndex(
                name: "IX_PlaylistExtension_albumID",
                table: "PlaylistExtension",
                newName: "IX_PlaylistExtension_AlbumID");

            migrationBuilder.RenameIndex(
                name: "IX_Playlists_userId",
                table: "Playlists",
                newName: "IX_Playlists_UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_AspNetUsers_UserId",
                table: "Playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistExtension_Albums_AlbumID",
                table: "PlaylistExtension");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistExtension_Playlists_PlaylistID",
                table: "PlaylistExtension");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Playlists",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_AspNetUsers_userId",
                table: "Playlists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistExtension_Albums_albumID",
                table: "PlaylistExtension",
                column: "AlbumID",
                principalTable: "Albums",
                principalColumn: "AlbumID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistExtension_Playlists_playlistID",
                table: "PlaylistExtension",
                column: "PlaylistID",
                principalTable: "Playlists",
                principalColumn: "PlaylistID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameColumn(
                name: "AlbumID",
                table: "PlaylistExtension",
                newName: "albumID");

            migrationBuilder.RenameColumn(
                name: "PlaylistID",
                table: "PlaylistExtension",
                newName: "playlistID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Playlists",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Playlists",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "PlaylistID",
                table: "Playlists",
                newName: "playlistID");

            migrationBuilder.RenameIndex(
                name: "IX_PlaylistExtension_PlaylistID",
                table: "PlaylistExtension",
                newName: "IX_PlaylistExtension_playlistID");

            migrationBuilder.RenameIndex(
                name: "IX_PlaylistExtension_AlbumID",
                table: "PlaylistExtension",
                newName: "IX_PlaylistExtension_albumID");

            migrationBuilder.RenameIndex(
                name: "IX_Playlists_UserId",
                table: "Playlists",
                newName: "IX_Playlists_userId");
        }
    }
}
