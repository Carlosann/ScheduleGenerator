using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleGenerator.Models
{
    public class EFCourseRepository : ICourseRepository
    {
        private ApplicationDbContext context;
        public EFCourseRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Course> Courses => context.Courses;

        public void SaveCourse(Course course)
        {
            if (course.CourseID == 0)
            {
                context.Courses.Add(course);
            }
            else
            {
                Course courseEntry = context.Courses
                    .FirstOrDefault(c => c.CourseID == course.CourseID);
                if (courseEntry != null)
                {
                    courseEntry.CourseCode = course.CourseCode;
                    courseEntry.CourseName = course.CourseName;
                    courseEntry.DepartmentID = course.DepartmentID;
                    courseEntry.LectureHours = course.LectureHours;
                    courseEntry.LabHours = course.LabHours;
                }
            }
            context.SaveChanges();
        }

        public void DeleteCourse(int id)
        {
            Course courseEntry = context.Courses
                .FirstOrDefault(c => c.CourseID == id);

            if (courseEntry != null)
            {
                context.Courses.Remove(courseEntry);
                context.SaveChanges();
            }
        }
    }
}
