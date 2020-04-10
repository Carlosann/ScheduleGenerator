using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleGenerator.Models
{
    public interface IDesiredCourseRepository
    {
        IQueryable<DesiredCourse> DesiredCourses { get; }
        void SaveDesiredCourse(DesiredCourse desiredCourse);
        void DeleteCourse(int id);
    }
}
