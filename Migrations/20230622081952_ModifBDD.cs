using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Migrations
{
    /// <inheritdoc />
    public partial class ModifBDD : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "ImagesId",
                table: "Projets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategorieId",
                table: "Projets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projets_Categorie_CategorieId",
                table: "Projets");

            migrationBuilder.DropForeignKey(
                name: "FK_Projets_Images_ImagesId",
                table: "Projets");

            migrationBuilder.AlterColumn<int>(
                name: "ImagesId",
                table: "Projets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategorieId",
                table: "Projets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projets_Categorie_CategorieId",
                table: "Projets",
                column: "CategorieId",
                principalTable: "Categorie",
                principalColumn: "CategorieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projets_Images_ImagesId",
                table: "Projets",
                column: "ImagesId",
                principalTable: "Images",
                principalColumn: "ImagesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
