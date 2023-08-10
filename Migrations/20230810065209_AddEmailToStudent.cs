using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailToStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId1",
                table: "Grades",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_SubjectId1",
                table: "Grades",
                column: "SubjectId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Subjects_SubjectId1",
                table: "Grades",
                column: "SubjectId1",
                principalTable: "Subjects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Subjects_SubjectId1",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_SubjectId1",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SubjectId1",
                table: "Grades");
        }
    }
}
