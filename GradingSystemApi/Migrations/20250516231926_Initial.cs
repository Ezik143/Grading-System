using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradingSystemApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalUnits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Units = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectCode);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    TeacherID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.TeacherID);
                });

            migrationBuilder.CreateTable(
                name: "Term",
                columns: table => new
                {
                    TermID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TermName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcademicYear = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Term", x => x.TermID);
                });

            migrationBuilder.CreateTable(
                name: "CourseSubject",
                columns: table => new
                {
                    CourseSubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    SubjectCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSubject", x => x.CourseSubjectID);
                    table.ForeignKey(
                        name: "FK_CourseSubject_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSubject_Subject_SubjectCode",
                        column: x => x.SubjectCode,
                        principalTable: "Subject",
                        principalColumn: "SubjectCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    ClassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherID = table.Column<int>(type: "int", nullable: false),
                    Schedule = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.ClassID);
                    table.ForeignKey(
                        name: "FK_Class_Teacher_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teacher",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherSubject",
                columns: table => new
                {
                    TeacherSubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherID = table.Column<int>(type: "int", nullable: false),
                    SubjectCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSubject", x => x.TeacherSubjectID);
                    table.ForeignKey(
                        name: "FK_TeacherSubject_Subject_SubjectCode",
                        column: x => x.SubjectCode,
                        principalTable: "Subject",
                        principalColumn: "SubjectCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherSubject_Teacher_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teacher",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    TermID = table.Column<int>(type: "int", nullable: false),
                    EnrollmentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK_Enrollment_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Term_TermID",
                        column: x => x.TermID,
                        principalTable: "Term",
                        principalColumn: "TermID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GradingPeriod",
                columns: table => new
                {
                    GradingPeriodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TermID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradingPeriod", x => x.GradingPeriodID);
                    table.ForeignKey(
                        name: "FK_GradingPeriod_Term_TermID",
                        column: x => x.TermID,
                        principalTable: "Term",
                        principalColumn: "TermID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    GradeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassID = table.Column<int>(type: "int", nullable: false),
                    GradeValue = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    GradeEquivalent = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradingPeriodID = table.Column<int>(type: "int", nullable: false),
                    EnrollmentID = table.Column<int>(type: "int", nullable: false),
                    DateRecorded = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.GradeID);
                    table.ForeignKey(
                        name: "FK_Grade_GradingPeriod_GradingPeriodID",
                        column: x => x.GradingPeriodID,
                        principalTable: "GradingPeriod",
                        principalColumn: "GradingPeriodID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Class_TeacherID",
                table: "Class",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubject_CourseID",
                table: "CourseSubject",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubject_SubjectCode",
                table: "CourseSubject",
                column: "SubjectCode");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_CourseID",
                table: "Enrollment",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_StudentID",
                table: "Enrollment",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_TermID",
                table: "Enrollment",
                column: "TermID");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_GradingPeriodID",
                table: "Grade",
                column: "GradingPeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_GradingPeriod_TermID",
                table: "GradingPeriod",
                column: "TermID");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubject_SubjectCode",
                table: "TeacherSubject",
                column: "SubjectCode");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubject_TeacherID",
                table: "TeacherSubject",
                column: "TeacherID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "CourseSubject");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "TeacherSubject");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "GradingPeriod");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Term");
        }
    }
}
