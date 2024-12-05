using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bigbank.Migrations
{
    public partial class AddUsersTable : Migration
    {
        // Bu metot veritabanı değişikliklerini uygular
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users", // Tablo adı
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"), // ID kolonunu otomatik arttırma ile ekleyin
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id); // Id kolonunu birincil anahtar olarak belirle
                }
            );
        }

        // Bu metot migration geri alındığında yapılacak işlemleri tanımlar
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users"); // Users tablosunu sil
        }
    }
}
