using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_management_system.Migrations
{
    /// <inheritdoc />
    public partial class updateRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentModelId",
                table: "Grade",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleModelId",
                table: "Authotications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SubjectModelTeacherModel",
                columns: table => new
                {
                    SubjectModelsId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectModelTeacherModel", x => new { x.SubjectModelsId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_SubjectModelTeacherModel_Subjects_SubjectModelsId",
                        column: x => x.SubjectModelsId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectModelTeacherModel_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grade_StudentModelId",
                table: "Grade",
                column: "StudentModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Authotications_RoleModelId",
                table: "Authotications",
                column: "RoleModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectModelTeacherModel_TeacherId",
                table: "SubjectModelTeacherModel",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authotications_Roles_RoleModelId",
                table: "Authotications",
                column: "RoleModelId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Students_StudentModelId",
                table: "Grade",
                column: "StudentModelId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authotications_Roles_RoleModelId",
                table: "Authotications");

            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Students_StudentModelId",
                table: "Grade");

            migrationBuilder.DropTable(
                name: "SubjectModelTeacherModel");

            migrationBuilder.DropIndex(
                name: "IX_Grade_StudentModelId",
                table: "Grade");

            migrationBuilder.DropIndex(
                name: "IX_Authotications_RoleModelId",
                table: "Authotications");

            migrationBuilder.DropColumn(
                name: "StudentModelId",
                table: "Grade");

            migrationBuilder.DropColumn(
                name: "RoleModelId",
                table: "Authotications");
        }
    }
}
