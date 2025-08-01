using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyTree.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddedParentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "People",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "People");
        }
    }
}
