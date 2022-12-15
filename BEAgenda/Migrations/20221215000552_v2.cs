using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BEAgenda.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "number",
                table: "Contacts",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Contacts",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Contacts",
                newName: "Email");

            migrationBuilder.AddColumn<bool>(
                name: "Favorite",
                table: "Contacts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropColumn(
                name: "Favorite",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Contacts",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Contacts",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Contacts",
                newName: "email");
        }
    }
}
