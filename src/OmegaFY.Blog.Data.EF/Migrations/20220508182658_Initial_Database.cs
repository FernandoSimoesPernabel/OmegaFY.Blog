using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmegaFY.Blog.Data.EF.Migrations
{
    public partial class Initial_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "varchar(36)", nullable: false),
                    AuthorId = table.Column<Guid>(type: "varchar(36)", nullable: true),
                    Title = table.Column<string>(type: "varchar(50)", nullable: true),
                    SubTitle = table.Column<string>(type: "varchar(50)", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateOfModification = table.Column<DateTime>(type: "datetime", nullable: true),
                    Hidden = table.Column<bool>(type: "INTEGER", nullable: false),
                    AverageRate = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "varchar(36)", nullable: false),
                    PostId = table.Column<Guid>(type: "varchar(36)", nullable: false),
                    AuthorId = table.Column<Guid>(type: "varchar(36)", nullable: true),
                    Content = table.Column<string>(type: "varchar(500)", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateOfModification = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "varchar(36)", nullable: false),
                    CommentId = table.Column<Guid>(type: "varchar(36)", nullable: false),
                    AuthorId = table.Column<Guid>(type: "varchar(36)", nullable: true),
                    CommentReaction = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reactions_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_CommentId",
                table: "Reactions",
                column: "CommentId");

            migrationBuilder.CreateTable(
                name: "Avaliations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "varchar(36)", nullable: false),
                    PostId = table.Column<Guid>(type: "varchar(36)", nullable: false),
                    AuthorId = table.Column<Guid>(type: "varchar(36)", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateOfModification = table.Column<DateTime>(type: "datetime", nullable: true),
                    Rate = table.Column<byte>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avaliations_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliations_PostId",
                table: "Avaliations",
                column: "PostId");

            migrationBuilder.CreateTable(
                name: "Shares",
                columns: table => new
                {
                    PostId = table.Column<Guid>(type: "varchar(36)", nullable: false),
                    AuthorId = table.Column<Guid>(type: "varchar(36)", nullable: false),
                    DateAndTimeOfShare = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shares", x => new { x.PostId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_Shares_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shares_PostId",
                table: "Shares",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shares");

            migrationBuilder.DropTable(
                name: "Avaliations");

            migrationBuilder.DropTable(
                name: "Reactions");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
