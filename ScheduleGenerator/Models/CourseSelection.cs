using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleGenerator.Models
{
    public class CourseSelection
    {
        public IQueryable<Course> Courses { get; set; }
        public List<DesiredCourse> DesiredCourses { get; set; }
    }
}
