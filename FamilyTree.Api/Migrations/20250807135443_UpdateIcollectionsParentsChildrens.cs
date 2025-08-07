using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyTree.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIcollectionsParentsChildrens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_People_FatherId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_People_MotherId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_People_PersonEntityId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_FatherId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_MotherId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_PersonEntityId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "FatherId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "MotherId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "PersonEntityId",
                table: "People");

            migrationBuilder.CreateTable(
                name: "PersonRelationship",
                columns: table => new
                {
                    ChildId = table.Column<int>(type: "INTEGER", nullable: false),
                    ParentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRelationship", x => new { x.ChildId, x.ParentId });
                    table.ForeignKey(
                        name: "FK_PersonRelationship_People_ChildId",
                        column: x => x.ChildId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonRelationship_People_ParentId",
                        column: x => x.ParentId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonRelationship_ParentId",
                table: "PersonRelationship",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonRelationship");

            migrationBuilder.AddColumn<int>(
                name: "FatherId",
                table: "People",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MotherId",
                table: "People",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonEntityId",
                table: "People",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_FatherId",
                table: "People",
                column: "FatherId");

            migrationBuilder.CreateIndex(
                name: "IX_People_MotherId",
                table: "People",
                column: "MotherId");

            migrationBuilder.CreateIndex(
                name: "IX_People_PersonEntityId",
                table: "People",
                column: "PersonEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_People_FatherId",
                table: "People",
                column: "FatherId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_People_MotherId",
                table: "People",
                column: "MotherId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_People_PersonEntityId",
                table: "People",
                column: "PersonEntityId",
                principalTable: "People",
                principalColumn: "Id");
        }
    }
}
