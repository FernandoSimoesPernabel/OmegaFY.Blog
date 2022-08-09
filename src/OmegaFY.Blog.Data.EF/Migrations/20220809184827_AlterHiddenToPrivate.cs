using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmegaFY.Blog.Data.EF.Migrations
{
    public partial class AlterHiddenToPrivate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hidden",
                table: "Posts",
                newName: "Private");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Private",
                table: "Posts",
                newName: "Hidden");
        }
    }
}
