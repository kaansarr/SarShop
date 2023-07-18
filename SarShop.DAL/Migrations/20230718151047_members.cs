using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SarShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class members : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "OrderNumberUnique",
                table: "Order");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Order",
                type: "char(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Order",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrderNumber",
                table: "Order",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Order",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExpYear",
                table: "Order",
                type: "char(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(2)",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExpMounth",
                table: "Order",
                type: "char(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(2)",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CartNumber",
                table: "Order",
                type: "char(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(16)",
                oldMaxLength: 16,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Order",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Surname = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    UserName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "OrderNumberUnique",
                table: "Order",
                column: "OrderNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropIndex(
                name: "OrderNumberUnique",
                table: "Order");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Order",
                type: "char(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Order",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "OrderNumber",
                table: "Order",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Order",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "ExpYear",
                table: "Order",
                type: "char(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "ExpMounth",
                table: "Order",
                type: "char(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "CartNumber",
                table: "Order",
                type: "char(16)",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(16)",
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Order",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "OrderNumberUnique",
                table: "Order",
                column: "OrderNumber",
                unique: true,
                filter: "[OrderNumber] IS NOT NULL");
        }
    }
}
