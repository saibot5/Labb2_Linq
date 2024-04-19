using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb2_Linq.Migrations
{
    /// <inheritdoc />
    public partial class viewmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseKlass_Class_ClassesKlassId",
                table: "CourseKlass");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Class_KlassId",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Class",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Student");

            migrationBuilder.RenameTable(
                name: "Class",
                newName: "Klass");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Klass",
                table: "Klass",
                column: "KlassId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseKlass_Klass_ClassesKlassId",
                table: "CourseKlass",
                column: "ClassesKlassId",
                principalTable: "Klass",
                principalColumn: "KlassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Klass_KlassId",
                table: "Student",
                column: "KlassId",
                principalTable: "Klass",
                principalColumn: "KlassId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseKlass_Klass_ClassesKlassId",
                table: "CourseKlass");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Klass_KlassId",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Klass",
                table: "Klass");

            migrationBuilder.RenameTable(
                name: "Klass",
                newName: "Class");

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Class",
                table: "Class",
                column: "KlassId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseKlass_Class_ClassesKlassId",
                table: "CourseKlass",
                column: "ClassesKlassId",
                principalTable: "Class",
                principalColumn: "KlassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Class_KlassId",
                table: "Student",
                column: "KlassId",
                principalTable: "Class",
                principalColumn: "KlassId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
