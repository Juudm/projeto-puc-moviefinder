using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace moviefinder.Migrations
{
    /// <inheritdoc />
    public partial class M01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AtoresFavoritos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Atores = table.Column<int>(type: "int", nullable: false),
                    Usuarios = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtoresFavoritos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtoresFavoritos_Atores_Atores",
                        column: x => x.Atores,
                        principalTable: "Atores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtoresFavoritos_Usuarios_Usuarios",
                        column: x => x.Usuarios,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmesFavoritos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Filmes = table.Column<int>(type: "int", nullable: false),
                    Usuarios = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmesFavoritos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmesFavoritos_Filmes_Filmes",
                        column: x => x.Filmes,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmesFavoritos_Usuarios_Usuarios",
                        column: x => x.Usuarios,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenerosFavoritos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Generos = table.Column<int>(type: "int", nullable: false),
                    Usuarios = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenerosFavoritos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenerosFavoritos_Generos_Generos",
                        column: x => x.Generos,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenerosFavoritos_Usuarios_Usuarios",
                        column: x => x.Usuarios,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtoresFavoritos_Atores",
                table: "AtoresFavoritos",
                column: "Atores");

            migrationBuilder.CreateIndex(
                name: "IX_AtoresFavoritos_Usuarios",
                table: "AtoresFavoritos",
                column: "Usuarios");

            migrationBuilder.CreateIndex(
                name: "IX_FilmesFavoritos_Filmes",
                table: "FilmesFavoritos",
                column: "Filmes");

            migrationBuilder.CreateIndex(
                name: "IX_FilmesFavoritos_Usuarios",
                table: "FilmesFavoritos",
                column: "Usuarios");

            migrationBuilder.CreateIndex(
                name: "IX_GenerosFavoritos_Generos",
                table: "GenerosFavoritos",
                column: "Generos");

            migrationBuilder.CreateIndex(
                name: "IX_GenerosFavoritos_Usuarios",
                table: "GenerosFavoritos",
                column: "Usuarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtoresFavoritos");

            migrationBuilder.DropTable(
                name: "FilmesFavoritos");

            migrationBuilder.DropTable(
                name: "GenerosFavoritos");

            migrationBuilder.DropTable(
                name: "Atores");

            migrationBuilder.DropTable(
                name: "Filmes");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
