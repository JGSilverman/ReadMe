using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadMe.Data.Migrations
{
    public partial class Stories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stories",
                columns: table => new
                {
                    StoryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Blurb = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Content = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    StoryType = table.Column<int>(type: "int", nullable: false),
                    Tags = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    ContentWarnings = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    WordCount = table.Column<long>(type: "bigint", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", unicode: false, nullable: false),
                    AuthorId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stories", x => x.StoryId);
                    table.ForeignKey(
                        name: "FK_Stories_AspNetUsers_AuthorId1",
                        column: x => x.AuthorId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stories_AuthorId",
                table: "Stories",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Stories_AuthorId1",
                table: "Stories",
                column: "AuthorId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stories");
        }
    }
}
