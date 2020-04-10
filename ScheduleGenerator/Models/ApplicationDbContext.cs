using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleGenerator.Models
{
    public class ApplicationDbContext:DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options){ }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<DesiredCourse> DesiredCourses { get; set; }
    }
}
