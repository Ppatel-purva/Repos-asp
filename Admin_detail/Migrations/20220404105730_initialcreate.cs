using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin_detail.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    admin_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    admin_first_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    admin_last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    admin_username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    admin_password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    admin_token = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");
        }
    }
}
