using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleGenerator.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public int LectureHours { get; set; }
        public int LabHours { get; set; }
        public int DepartmentID { get; set; }
    }
}
