using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShop.Migrations
{
    /// <inheritdoc />
    public partial class adminlogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Oid",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "Adminlogins",
                columns: table => new
                {
                    AdminEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Adminname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adminlogins", x => x.AdminEmail);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adminlogins");

            migrationBuilder.AddColumn<int>(
                name: "Oid",
                table: "Products",
                type: "int",
                nullable: true);
        }
    }
}
