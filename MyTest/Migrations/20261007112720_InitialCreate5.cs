using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTest.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Student_SchoolId",
                table: "Student",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_School_SchoolId",
                table: "Student",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "SchoolId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_School_SchoolId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_SchoolId",
                table: "Student");
        }
    }
}
