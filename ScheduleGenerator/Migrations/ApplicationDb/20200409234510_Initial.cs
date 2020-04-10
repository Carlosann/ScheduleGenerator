using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleGenerator.Migrations.ApplicationDb
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseName = table.Column<string>(nullable: true),
                    CourseCode = table.Column<string>(nullable: true),
                    LectureHours = table.Column<int>(nullable: false),
                    LabHours = table.Column<int>(nullable: false),
                    DepartmentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentName = table.Column<string>(nullable: true),
                    DepartmentCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "DesiredCourses",
                columns: table => new
                {
                    DesiredCourseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDesired = table.Column<bool>(nullable: false),
                    IsQualified = table.Column<bool>(nullable: false),
                    CourseID = table.Column<int>(nullable: false),
                    InstructorID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesiredCourses", x => x.DesiredCourseID);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoomBuilding = table.Column<string>(nullable: true),
                    RoomNumber = table.Column<int>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    StartHour = table.Column<int>(nullable: false),
                    EndHour = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "DesiredCourses");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
