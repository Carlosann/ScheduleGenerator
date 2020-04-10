using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace ScheduleGenerator.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();

            if (!context.Departments.Any())
            {
                context.Departments.AddRange(
                    new Department
                    {
                        DepartmentName = "Computation Department",
                        DepartmentCode = "COMP"
                    },
                    new Department
                    {
                        DepartmentName = "Communications Department",
                        DepartmentCode = "COMM"
                    },
                    new Department
                    {
                        DepartmentName = "Math Department",
                        DepartmentCode = "MATH"
                    }
                    );

                context.SaveChanges();
            }

            if (!context.Courses.Any())
            {
                context.Courses.AddRange(
                    new Course
                    {
                        CourseName = "College Communications 1",
                        CourseCode = "161",
                        LabHours = 2,
                        LectureHours = 2,
                        DepartmentID = context.Departments.FirstOrDefault(d => d.DepartmentCode == "COMM").DepartmentID
                    },
                    new Course
                    {
                        CourseName = "College Communications 2",
                        CourseCode = "171",
                        LabHours = 2,
                        LectureHours = 2,
                        DepartmentID = context.Departments.FirstOrDefault(d => d.DepartmentCode == "COMM").DepartmentID
                    }, 
                    new Course
                    {
                        CourseName = "Functions and Number Systems",
                        CourseCode = "175",
                        LabHours = 1,
                        LectureHours = 2,
                        DepartmentID = context.Departments.FirstOrDefault(d => d.DepartmentCode == "MATH").DepartmentID
                    },
                    new Course
                    {
                        CourseName = "Discrete Mathematics",
                        CourseCode = "185",
                        LabHours = 1,
                        LectureHours = 2,
                        DepartmentID = context.Departments.FirstOrDefault(d => d.DepartmentCode == "MATH").DepartmentID
                    },
                    new Course
                    {
                        CourseName = "Programming 1",
                        CourseCode = "100",
                        LabHours = 2,
                        LectureHours = 2,
                        DepartmentID = context.Departments.FirstOrDefault(d => d.DepartmentCode == "COMP").DepartmentID
                    },
                    new Course
                    {
                        CourseName = "Software Engineering Fundamentals",
                        CourseCode = "120",
                        LabHours = 2,
                        LectureHours = 2,
                        DepartmentID = context.Departments.FirstOrDefault(d => d.DepartmentCode == "COMP").DepartmentID
                    },
                    new Course
                    {
                        CourseName = "Web Interface Design",
                        CourseCode = "213",
                        LabHours = 2,
                        LectureHours = 2,
                        DepartmentID = context.Departments.FirstOrDefault(d => d.DepartmentCode == "COMP").DepartmentID
                    },
                    new Course
                    {
                        CourseName = "Introduction to Database Concepts",
                        CourseCode = "122",
                        LabHours = 2,
                        LectureHours = 2,
                        DepartmentID = context.Departments.FirstOrDefault(d => d.DepartmentCode == "COMP").DepartmentID
                    },
                    new Course
                    {
                        CourseName = "Programming 2",
                        CourseCode = "123",
                        LabHours = 2,
                        LectureHours = 2,
                        DepartmentID = context.Departments.FirstOrDefault(d => d.DepartmentCode == "COMP").DepartmentID
                    },
                    new Course
                    {
                        CourseName = "Client-Side Web Developement",
                        CourseCode = "125",
                        LabHours = 2,
                        LectureHours = 2,
                        DepartmentID = context.Departments.FirstOrDefault(d => d.DepartmentCode == "COMP").DepartmentID
                    },
                    new Course
                    {
                        CourseName = "Unix/Linux Operating Systems",
                        CourseCode = "301",
                        LabHours = 2,
                        LectureHours = 2,
                        DepartmentID = context.Departments.FirstOrDefault(d => d.DepartmentCode == "COMP").DepartmentID
                    }
                    );
                context.SaveChanges();
            }

            if (!context.Rooms.Any())
            {
                context.Rooms.AddRange(
                    new Room
                    {
                        RoomBuilding = "A",
                        RoomNumber = 101,
                        Capacity = 25,
                        StartHour = 800,
                        EndHour = 1800
                    },
                    new Room
                    {
                        RoomBuilding = "A",
                        RoomNumber = 102,
                        Capacity = 25,
                        StartHour = 800,
                        EndHour = 1800
                    },
                    new Room
                    {
                        RoomBuilding = "A",
                        RoomNumber = 201,
                        Capacity = 25,
                        StartHour = 800,
                        EndHour = 1800
                    },
                    new Room
                    {
                        RoomBuilding = "A",
                        RoomNumber = 202,
                        Capacity = 25,
                        StartHour = 800,
                        EndHour = 1800
                    },
                    new Room
                    {
                        RoomBuilding = "B",
                        RoomNumber = 101,
                        Capacity = 25,
                        StartHour = 800,
                        EndHour = 1800
                    },
                    new Room
                    {
                        RoomBuilding = "B",
                        RoomNumber = 102,
                        Capacity = 25,
                        StartHour = 800,
                        EndHour = 1800
                    },
                    new Room
                    {
                        RoomBuilding = "B",
                        RoomNumber = 201,
                        Capacity = 25,
                        StartHour = 800,
                        EndHour = 1800
                    },
                    new Room
                    {
                        RoomBuilding = "B",
                        RoomNumber = 202,
                        Capacity = 25,
                        StartHour = 800,
                        EndHour = 1800
                    },
                    new Room
                    {
                        RoomBuilding = "C",
                        RoomNumber = 101,
                        Capacity = 25,
                        StartHour = 800,
                        EndHour = 1800
                    },
                    new Room
                    {
                        RoomBuilding = "C",
                        RoomNumber = 102,
                        Capacity = 25,
                        StartHour = 800,
                        EndHour = 1800
                    },
                    new Room
                    {
                        RoomBuilding = "C",
                        RoomNumber = 201,
                        Capacity = 25,
                        StartHour = 800,
                        EndHour = 1800
                    },
                    new Room
                    {
                        RoomBuilding = "C",
                        RoomNumber = 202,
                        Capacity = 25,
                        StartHour = 800,
                        EndHour = 1800
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
