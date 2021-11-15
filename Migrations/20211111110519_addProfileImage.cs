using Microsoft.EntityFrameworkCore.Migrations;

namespace LifeGoals.Migrations
{
    public partial class addProfileImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imag",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imag",
                table: "AspNetUsers");
        }
    }
}
