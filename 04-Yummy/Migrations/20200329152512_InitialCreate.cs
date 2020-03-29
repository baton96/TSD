using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCRecipes.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Time = table.Column<int>(nullable: false),
                    Difficulty = table.Column<int>(nullable: false),
                    Likes = table.Column<int>(nullable: false),
                    Ingredients = table.Column<string>(nullable: true),
                    Process = table.Column<string>(nullable: true),
                    TipsNTricks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
