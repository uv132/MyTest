using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTest.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HomeTeacherId",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HomeTeacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    teachergender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeTeacher", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_HomeTeacherId",
                table: "Student",
                column: "HomeTeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_HomeTeacher_HomeTeacherId",
                table: "Student",
                column: "HomeTeacherId",
                principalTable: "HomeTeacher",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_HomeTeacher_HomeTeacherId",
                table: "Student");

            migrationBuilder.DropTable(
                name: "HomeTeacher");

            migrationBuilder.DropIndex(
                name: "IX_Student_HomeTeacherId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "HomeTeacherId",
                table: "Student");
        }
    }
}
