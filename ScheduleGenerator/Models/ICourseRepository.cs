using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleGenerator.Models
{
    public interface ICourseRepository
    {
        IQueryable<Course> Courses { get; }
        void SaveCourse(Course course);
        void DeleteCourse(int id);
    }
}
