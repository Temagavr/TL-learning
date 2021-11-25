using Microsoft.EntityFrameworkCore.Migrations;

namespace CookingWebsite.Migrations.Migrations
{
    public partial class AddRecipeInDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CookingTime = table.Column<int>(type: "int", nullable: false),
                    PersonsCount = table.Column<int>(type: "int", nullable: false),
                    LikesCount = table.Column<int>(type: "int", nullable: false),
                    FavouritesCount = table.Column<int>(type: "int", nullable: false),
                    AuthorUsername = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeStep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    StepNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeStep_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredientItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeIngredientId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredientItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeIngredientItem_RecipeIngredient_RecipeIngredientId",
                        column: x => x.RecipeIngredientId,
                        principalTable: "RecipeIngredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_RecipeId",
                table: "RecipeIngredient",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredientItem_RecipeIngredientId",
                table: "RecipeIngredientItem",
                column: "RecipeIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeStep_RecipeId",
                table: "RecipeStep",
                column: "RecipeId");

            /*
            migrationBuilder.Sql("INSERT INTO Recipe (ImageUrl, Title, Description, CookingTime, PersonsCount, LikesCount, " +
                "FavouritesCount, AuthorUsername) VALUES('../../../assets/recipes-list-page/recipeExpl1WithoutUsername.png', " +
                "'Клубничная панна-котта', 'Десерт, который невероятно легко и быстро готовится. Советую подавать его порционно в" +
                " красивых бокалах, украсив взбитыми сливками, свежими ягодами и мятой.', " +
                "35, 5, 8, 10, 'glazest');");
            
            migrationBuilder.Sql("INSERT INTO RecipeIngredient VALUES(1, 'Для панна котты');");

            migrationBuilder.Sql("INSERT INTO RecipeIngredientItem VALUES(1, 'Сливки-20-30%', '500мл.');");
            migrationBuilder.Sql("INSERT INTO RecipeIngredientItem VALUES(1, 'Молоко', '100мл.');");
            migrationBuilder.Sql("INSERT INTO RecipeIngredientItem VALUES(1, 'Желатин', '2 ч.л.');");
            migrationBuilder.Sql("INSERT INTO RecipeIngredientItem VALUES(1, 'Сахар', '3 ст.л.');");
            migrationBuilder.Sql("INSERT INTO RecipeIngredientItem VALUES(1, 'Ванильный сахар', '2 ч.л.');");

            migrationBuilder.Sql("INSERT INTO RecipeStep VALUES(1, 1, 'Приготовим панна котту: Зальем желатин молоком и поставим на 30 минут для набухания. В сливки добавим сахар и ванильный сахар. Доводим до кипения (не кипятим!).'); ");
            migrationBuilder.Sql("INSERT INTO RecipeStep VALUES(1, 2, 'Добавим в сливки набухший в молоке желатин. Перемешаем до полного растворения. Огонь отключаем. Охладим до комнатной температуры.'); ");
            migrationBuilder.Sql("INSERT INTO RecipeStep VALUES(1, 3, 'Разольем охлажденные сливки по креманкам и поставим в холодильник до полного застывания. Это около 3-5 часов.'); ");
            migrationBuilder.Sql("INSERT INTO RecipeStep VALUES(1, 4, 'Приготовим клубничное желе: Клубнику помоем, очистим от плодоножек. Добавим сахар. Взбиваем клубнику с помощью блендера в пюре.'); ");
            migrationBuilder.Sql("INSERT INTO RecipeStep VALUES(1, 5, 'Добавим в миску с желатином 2ст.ложки холодной воды и сок лимона. Перемешаем и поставим на 30 минут для набухания. Доведем клубничное пюре до кипения. Добавим набухший желатин, перемешаем до полного растворения. Огонь отключаем. Охладим до комнатной температуры.'); ");
            migrationBuilder.Sql("INSERT INTO RecipeStep VALUES(1, 6, 'Сверху на застывшие сливки добавим охлажденное клубничное желе. Поставим в холодильник до полного застывания клубничного желе. Готовую панна коту подаем с фруктами.'); ");
            */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeIngredientItem");

            migrationBuilder.DropTable(
                name: "RecipeStep");

            migrationBuilder.DropTable(
                name: "RecipeIngredient");

            migrationBuilder.DropTable(
                name: "Recipe");
        }
    }
}
