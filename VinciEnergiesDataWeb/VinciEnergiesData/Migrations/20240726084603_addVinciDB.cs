using Microsoft.EntityFrameworkCore.Migrations;

namespace VinciEnergiesData.Migrations
{
    public partial class addVinciDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "administrateur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin0 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminKey0 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrateur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dossiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codeSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    annee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ville = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    folder = table.Column<int>(type: "int", nullable: false),
                    genre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dossiers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fichiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dossier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    annee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ville = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fichiers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vmLogins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeepLoggedIn = table.Column<bool>(type: "bit", nullable: false),
                    Administrateur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminKey = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vmLogins", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "administrateur");

            migrationBuilder.DropTable(
                name: "dossiers");

            migrationBuilder.DropTable(
                name: "fichiers");

            migrationBuilder.DropTable(
                name: "vmLogins");
        }
    }
}
