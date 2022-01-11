using Microsoft.EntityFrameworkCore.Migrations;

namespace CookingWebsite.Migrations.Migrations
{
    public partial class AddUniqueForLikesAndFavourites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RecipeLike_UserId_RecipeId",
                table: "RecipeLike",
                columns: new[] { "UserId", "RecipeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeFavourite_UserId_RecipeId",
                table: "RecipeFavourite",
                columns: new[] { "UserId", "RecipeId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RecipeLike_UserId_RecipeId",
                table: "RecipeLike");

            migrationBuilder.DropIndex(
                name: "IX_RecipeFavourite_UserId_RecipeId",
                table: "RecipeFavourite");
        }
    }
}
