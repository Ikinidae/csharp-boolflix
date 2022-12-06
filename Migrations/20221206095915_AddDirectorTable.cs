using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharpboolflix.Migrations
{
    /// <inheritdoc />
    public partial class AddDirectorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorContent_Content_ContentsId",
                table: "ActorContent");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryContent_Content_ContentsId",
                table: "CategoryContent");

            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Content_SerieId",
                table: "Seasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Content",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Content");

            migrationBuilder.RenameTable(
                name: "Content",
                newName: "Contents");

            migrationBuilder.AddColumn<int>(
                name: "DirectorId",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contents",
                table: "Contents",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contents_DirectorId",
                table: "Contents",
                column: "DirectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorContent_Contents_ContentsId",
                table: "ActorContent",
                column: "ContentsId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryContent_Contents_ContentsId",
                table: "CategoryContent",
                column: "ContentsId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Directors_DirectorId",
                table: "Contents",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Contents_SerieId",
                table: "Seasons",
                column: "SerieId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorContent_Contents_ContentsId",
                table: "ActorContent");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryContent_Contents_ContentsId",
                table: "CategoryContent");

            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Directors_DirectorId",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Contents_SerieId",
                table: "Seasons");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contents",
                table: "Contents");

            migrationBuilder.DropIndex(
                name: "IX_Contents_DirectorId",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "DirectorId",
                table: "Contents");

            migrationBuilder.RenameTable(
                name: "Contents",
                newName: "Content");

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Content",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Content",
                table: "Content",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorContent_Content_ContentsId",
                table: "ActorContent",
                column: "ContentsId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryContent_Content_ContentsId",
                table: "CategoryContent",
                column: "ContentsId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Content_SerieId",
                table: "Seasons",
                column: "SerieId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
