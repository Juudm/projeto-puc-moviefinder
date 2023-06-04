using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace moviefinder.Migrations
{
    /// <inheritdoc />
    public partial class M04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TheMovieDbId",
                table: "Generos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TheMovieDbId",
                table: "Filmes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TheMovieDbId",
                table: "Atores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TheMovieDbId",
                table: "Generos");

            migrationBuilder.DropColumn(
                name: "TheMovieDbId",
                table: "Filmes");

            migrationBuilder.DropColumn(
                name: "TheMovieDbId",
                table: "Atores");
        }
    }
}
