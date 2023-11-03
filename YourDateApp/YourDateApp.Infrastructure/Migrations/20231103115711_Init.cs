using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourDateApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profile_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profile_LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profile_PhotoSrc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profile_Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profile_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profile_Age = table.Column<int>(type: "int", nullable: true)
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
        }
    }
}
