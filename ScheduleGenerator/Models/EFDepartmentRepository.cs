using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleGenerator.Models
{
    public class EFDepartmentRepository : IDepartmentRepository
    {
        private ApplicationDbContext context;
        public EFDepartmentRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Department> Departments => context.Departments;

        public void SaveDepartment(Department department)
        {
            if (department.DepartmentID == 0)
            {
                context.Departments.Add(department);
            }
            else
            {
                Department departmentEntry = context.Departments
                    .FirstOrDefault(d => d.DepartmentID == department.DepartmentID);
                if(departmentEntry != null)
                {
                    departmentEntry.DepartmentCode = department.DepartmentCode;
                    departmentEntry.DepartmentName = department.DepartmentName;
                }
            }
            context.SaveChanges();
        }

        public Department DeleteDepartment (int departmentID)
        {
            Department departmentEntry = context.Departments
                .FirstOrDefault(d => d.DepartmentID == departmentID);
            
            if (departmentEntry != null)
            {
                context.Departments.Remove(departmentEntry);
                context.SaveChanges();
            }
            return departmentEntry;
        }
    }
}
