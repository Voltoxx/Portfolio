using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Migrations
{
    /// <inheritdoc />
    public partial class NewBdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projets_Categorie_CategorieId",
                table: "Projets");

            migrationBuilder.DropForeignKey(
                name: "FK_Projets_Images_ImagesId",
                table: "Projets");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Projets_CategorieId",
                table: "Projets");

            migrationBuilder.DropIndex(
                name: "IX_Projets_ImagesId",
                table: "Projets");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "Projets");

            migrationBuilder.DropColumn(
                name: "ImagesId",
                table: "Projets");

            migrationBuilder.AddColumn<string>(
                name: "Categorie",
                table: "Projets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstImage",
                table: "Projets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondImage",
                table: "Projets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ThirdImage",
                table: "Projets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categorie",
                table: "Projets");

            migrationBuilder.DropColumn(
                name: "FirstImage",
                table: "Projets");

            migrationBuilder.DropColumn(
                name: "SecondImage",
                table: "Projets");

            migrationBuilder.DropColumn(
                name: "ThirdImage",
                table: "Projets");

            migrationBuilder.AddColumn<int>(
                name: "CategorieId",
                table: "Projets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImagesId",
                table: "Projets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategorieName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.CategorieId);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImagesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImagesId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projets_CategorieId",
                table: "Projets",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Projets_ImagesId",
                table: "Projets",
                column: "ImagesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projets_Categorie_CategorieId",
                table: "Projets",
                column: "CategorieId",
                principalTable: "Categorie",
                principalColumn: "CategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projets_Images_ImagesId",
                table: "Projets",
                column: "ImagesId",
                principalTable: "Images",
                principalColumn: "ImagesId");
        }
    }
}
