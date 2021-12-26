using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Proje.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    kitapID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kitapAdi = table.Column<string>(nullable: true),
                    basimYili = table.Column<int>(nullable: false),
                    yazar = table.Column<string>(nullable: true),
                    sayfaSayisi = table.Column<int>(nullable: false),
                    konu = table.Column<string>(nullable: true),
                    link = table.Column<string>(nullable: true),
                    kategori = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.kitapID);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    messageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    message = table.Column<string>(nullable: true),
                    BookId = table.Column<int>(nullable: false),
                    User = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.messageID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "messages");
        }
    }
}
