using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradingSystemApi.Migrations
{
    /// <inheritdoc />
    public partial class FixCascadePaths2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Subjects_subjectCode",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Teachers_teacherID",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSubjects_Courses_courseID",
                table: "CourseSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSubjects_Subjects_subjectCode1",
                table: "CourseSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Courses_courseID",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Students_studentID",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Terms_termID",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Classes_classID",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Students_studentID",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Subjects_subjectCode",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Terms_termID",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubjects_Subjects_subjectCode",
                table: "TeacherSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubjects_Teachers_teacherID",
                table: "TeacherSubjects");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Subjects_subjectCode",
                table: "Classes",
                column: "subjectCode",
                principalTable: "Subjects",
                principalColumn: "subjectCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Teachers_teacherID",
                table: "Classes",
                column: "teacherID",
                principalTable: "Teachers",
                principalColumn: "teacherID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSubjects_Courses_courseID",
                table: "CourseSubjects",
                column: "courseID",
                principalTable: "Courses",
                principalColumn: "courseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSubjects_Subjects_subjectCode1",
                table: "CourseSubjects",
                column: "subjectCode1",
                principalTable: "Subjects",
                principalColumn: "subjectCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Courses_courseID",
                table: "Enrollments",
                column: "courseID",
                principalTable: "Courses",
                principalColumn: "courseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Students_studentID",
                table: "Enrollments",
                column: "studentID",
                principalTable: "Students",
                principalColumn: "studentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Terms_termID",
                table: "Enrollments",
                column: "termID",
                principalTable: "Terms",
                principalColumn: "Term_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Classes_classID",
                table: "Grades",
                column: "classID",
                principalTable: "Classes",
                principalColumn: "classID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_studentID",
                table: "Grades",
                column: "studentID",
                principalTable: "Students",
                principalColumn: "studentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Subjects_subjectCode",
                table: "Grades",
                column: "subjectCode",
                principalTable: "Subjects",
                principalColumn: "subjectCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Terms_termID",
                table: "Grades",
                column: "termID",
                principalTable: "Terms",
                principalColumn: "Term_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubjects_Subjects_subjectCode",
                table: "TeacherSubjects",
                column: "subjectCode",
                principalTable: "Subjects",
                principalColumn: "subjectCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubjects_Teachers_teacherID",
                table: "TeacherSubjects",
                column: "teacherID",
                principalTable: "Teachers",
                principalColumn: "teacherID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Subjects_subjectCode",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Teachers_teacherID",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSubjects_Courses_courseID",
                table: "CourseSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSubjects_Subjects_subjectCode1",
                table: "CourseSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Courses_courseID",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Students_studentID",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Terms_termID",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Classes_classID",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Students_studentID",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Subjects_subjectCode",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Terms_termID",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubjects_Subjects_subjectCode",
                table: "TeacherSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubjects_Teachers_teacherID",
                table: "TeacherSubjects");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Subjects_subjectCode",
                table: "Classes",
                column: "subjectCode",
                principalTable: "Subjects",
                principalColumn: "subjectCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Teachers_teacherID",
                table: "Classes",
                column: "teacherID",
                principalTable: "Teachers",
                principalColumn: "teacherID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSubjects_Courses_courseID",
                table: "CourseSubjects",
                column: "courseID",
                principalTable: "Courses",
                principalColumn: "courseID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSubjects_Subjects_subjectCode1",
                table: "CourseSubjects",
                column: "subjectCode1",
                principalTable: "Subjects",
                principalColumn: "subjectCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Courses_courseID",
                table: "Enrollments",
                column: "courseID",
                principalTable: "Courses",
                principalColumn: "courseID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Students_studentID",
                table: "Enrollments",
                column: "studentID",
                principalTable: "Students",
                principalColumn: "studentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Terms_termID",
                table: "Enrollments",
                column: "termID",
                principalTable: "Terms",
                principalColumn: "Term_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Classes_classID",
                table: "Grades",
                column: "classID",
                principalTable: "Classes",
                principalColumn: "classID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_studentID",
                table: "Grades",
                column: "studentID",
                principalTable: "Students",
                principalColumn: "studentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Subjects_subjectCode",
                table: "Grades",
                column: "subjectCode",
                principalTable: "Subjects",
                principalColumn: "subjectCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Terms_termID",
                table: "Grades",
                column: "termID",
                principalTable: "Terms",
                principalColumn: "Term_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubjects_Subjects_subjectCode",
                table: "TeacherSubjects",
                column: "subjectCode",
                principalTable: "Subjects",
                principalColumn: "subjectCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubjects_Teachers_teacherID",
                table: "TeacherSubjects",
                column: "teacherID",
                principalTable: "Teachers",
                principalColumn: "teacherID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
