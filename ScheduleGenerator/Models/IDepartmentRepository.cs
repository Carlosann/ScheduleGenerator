using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleGenerator.Models
{
    public interface IDepartmentRepository
    {
        IQueryable<Department> Departments { get; }
        void SaveDepartment(Department department);
        Department DeleteDepartment(int departmentID);
    }
}
