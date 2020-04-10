using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleGenerator.Models
{
    public class DesiredCourse
    {
        public int DesiredCourseID { get; set; }
        public bool IsDesired { get; set; }
        public bool IsQualified { get; set; }
        public int CourseID { get; set; }
        public string InstructorID { get; set; }
    }
}
