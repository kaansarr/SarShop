using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SarShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class aboutt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "About",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    SubTitle = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    SubDescription = table.Column<string>(type: "nvarchar(MAX)", maxLength: 2147483647, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_About", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "About");
        }
    }
}
