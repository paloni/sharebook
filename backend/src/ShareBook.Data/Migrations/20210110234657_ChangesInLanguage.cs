using Microsoft.EntityFrameworkCore.Migrations;

namespace ShareBook.Data.Migrations
{
    public partial class ChangesInLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Languages_LanguageId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_LanguageId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "Abbriviation",
                table: "Languages",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookLanguages",
                columns: table => new
                {
                    BooksBookId = table.Column<int>(type: "integer", nullable: false),
                    LanguagesLanguageId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLanguages", x => new { x.BooksBookId, x.LanguagesLanguageId });
                    table.ForeignKey(
                        name: "FK_BookLanguages_Books_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLanguages_Languages_LanguagesLanguageId",
                        column: x => x.LanguagesLanguageId,
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Abbriviation",
                table: "Languages",
                column: "Abbriviation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookLanguages_LanguagesLanguageId",
                table: "BookLanguages",
                column: "LanguagesLanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookLanguages");

            migrationBuilder.DropIndex(
                name: "IX_Languages_Abbriviation",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "Abbriviation",
                table: "Languages");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Books",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_LanguageId",
                table: "Books",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Languages_LanguageId",
                table: "Books",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
