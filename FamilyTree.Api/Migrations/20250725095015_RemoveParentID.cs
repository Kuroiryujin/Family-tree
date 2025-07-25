using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyTree.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveParentID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_People_ParentId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_ParentId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "People");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "People",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_ParentId",
                table: "People",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_People_ParentId",
                table: "People",
                column: "ParentId",
                principalTable: "People",
                principalColumn: "Id");
        }
    }
}
