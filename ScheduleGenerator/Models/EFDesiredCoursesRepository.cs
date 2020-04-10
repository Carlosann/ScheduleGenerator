using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleGenerator.Models
{
    public class EFDesiredCoursesRepository : IDesiredCourseRepository
    {
        private ApplicationDbContext context;
        public EFDesiredCoursesRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<DesiredCourse> DesiredCourses => context.DesiredCourses;

        public void SaveDesiredCourse(DesiredCourse desiredCourse)
        {
            if (desiredCourse.DesiredCourseID == 0)
            {
                context.DesiredCourses.Add(desiredCourse);
            }
            else
            {
                DesiredCourse desiredCourseEntry = context.DesiredCourses
                    .FirstOrDefault(d => d.DesiredCourseID == desiredCourse.DesiredCourseID);
                if (desiredCourseEntry != null)
                {
                    desiredCourseEntry.IsDesired = desiredCourse.IsDesired;
                    desiredCourseEntry.IsQualified = desiredCourse.IsQualified;
                }
            }
            context.SaveChanges();
        }

        public void DeleteCourse(int id)
        {
            DesiredCourse desiredCourseEntry = context.DesiredCourses
                .FirstOrDefault(c => c.DesiredCourseID == id);

            if (desiredCourseEntry != null)
            {
                context.DesiredCourses.Remove(desiredCourseEntry);
                context.SaveChanges();
            }
        }
    }
}
