using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb2_Linq.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Klass",
                columns: table => new
                {
                    KlassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klass", x => x.KlassId);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "CourseKlass",
                columns: table => new
                {
                    ClassesKlassId = table.Column<int>(type: "int", nullable: false),
                    CoursesCourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseKlass", x => new { x.ClassesKlassId, x.CoursesCourseId });
                    table.ForeignKey(
                        name: "FK_CourseKlass_Course_CoursesCourseId",
                        column: x => x.CoursesCourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseKlass_Klass_ClassesKlassId",
                        column: x => x.ClassesKlassId,
                        principalTable: "Klass",
                        principalColumn: "KlassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KlassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Student_Klass_KlassId",
                        column: x => x.KlassId,
                        principalTable: "Klass",
                        principalColumn: "KlassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseTeacher",
                columns: table => new
                {
                    CoursesCourseId = table.Column<int>(type: "int", nullable: false),
                    TeachersTeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTeacher", x => new { x.CoursesCourseId, x.TeachersTeacherId });
                    table.ForeignKey(
                        name: "FK_CourseTeacher_Course_CoursesCourseId",
                        column: x => x.CoursesCourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTeacher_Teacher_TeachersTeacherId",
                        column: x => x.TeachersTeacherId,
                        principalTable: "Teacher",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "CourseId", "Name" },
                values: new object[,]
                {
                    { 1, "Programmering 1" },
                    { 2, "Programmering 2" },
                    { 3, "Svenska" },
                    { 4, "Engelska" }
                });

            migrationBuilder.InsertData(
                table: "Klass",
                columns: new[] { "KlassId", "Name" },
                values: new object[,]
                {
                    { 1, "A1" },
                    { 2, "A2" },
                    { 3, "B1" },
                    { 4, "B2" }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "TeacherId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Reidar", "Nilsen" },
                    { 2, "Tobias", "Landén" },
                    { 3, "Adam", "Adamsson" },
                    { 4, "Bertil", "Bok" }
                });

            migrationBuilder.InsertData(
                table: "CourseKlass",
                columns: new[] { "ClassesKlassId", "CoursesCourseId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 4 },
                    { 2, 2 },
                    { 3, 2 },
                    { 3, 3 },
                    { 4, 1 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "CourseTeacher",
                columns: new[] { "CoursesCourseId", "TeachersTeacherId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "FirstName", "KlassId", "LastName" },
                values: new object[,]
                {
                    { 1, "Anders", 1, "And" },
                    { 2, "Bosse", 2, "Basker" },
                    { 3, "Bengt", 4, "Basker" },
                    { 4, "Daniel", 3, "Danielsson" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseKlass_CoursesCourseId",
                table: "CourseKlass",
                column: "CoursesCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTeacher_TeachersTeacherId",
                table: "CourseTeacher",
                column: "TeachersTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_KlassId",
                table: "Student",
                column: "KlassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseKlass");

            migrationBuilder.DropTable(
                name: "CourseTeacher");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Klass");
        }
    }
}
