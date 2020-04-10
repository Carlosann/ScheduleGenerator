using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScheduleGenerator.Models;
using Microsoft.Extensions.DependencyInjection;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScheduleGenerator.Controllers
{
    [Authorize(Roles = "INSTRUCTOR")]
    public class InstructorController : Controller
    {
        private UserManager<AppUser> userManager;
        private AppIdentityDbContext identitycontext;
        private SignInManager<AppUser> signInManager;
        private ApplicationDbContext context;
        private IDesiredCourseRepository desiredCourseRepository;
        private IDepartmentRepository departmentRepository;

        public InstructorController(UserManager<AppUser> userMgr, AppIdentityDbContext identCtx,
             SignInManager<AppUser> singInMgr, IDepartmentRepository depRepo,
             IDesiredCourseRepository desRepo, ApplicationDbContext ctx)
        {
            context = ctx;
            userManager = userMgr;
            identitycontext = identCtx;
            signInManager = singInMgr;
            departmentRepository = depRepo;
            desiredCourseRepository = desRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ViewResult> AccountDetails()
        {
            var user = await userManager.GetUserAsync(User);
            var department = context.Departments.FirstOrDefault(d => d.DepartmentCode == user.Department);
            ViewBag.Dep = department.DepartmentName;
            return View(user);
        }

        
        public async Task<ViewResult> SelectCourses()
        {
            var user = await userManager.GetUserAsync(User);
             var department = context.Departments.FirstOrDefault(d => d.DepartmentCode == user.Department);

             CourseSelection courseSelection = new CourseSelection {
                 Courses = context.Courses.Where(c => c.DepartmentID == department.DepartmentID), 
                 DesiredCourses = new List<DesiredCourse>()};

             foreach (var c in courseSelection.Courses)
             {

                 if (context.DesiredCourses.FirstOrDefault(d => (d.CourseID == c.CourseID) && (d.InstructorID == user.Id)) != null)
                 {
                     courseSelection.DesiredCourses.Add(
                     new DesiredCourse { CourseID = c.CourseID, IsDesired = true, InstructorID = user.Id });
                 } else
                 {
                     courseSelection.DesiredCourses.Add(
                     new DesiredCourse { CourseID = c.CourseID , IsDesired = false, InstructorID = user.Id});
                 }
             }
            return View(courseSelection);
        }

        [HttpPost]
        public IActionResult UpdateDesiredCourses(CourseSelection model)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in model.DesiredCourses)
                {
                     if (context.DesiredCourses
                                .Where(i => i.InstructorID == item.InstructorID) != null)
                     {
                        if (!context.DesiredCourses
                            .Where(i => i.InstructorID == item.InstructorID)
                            .Select(c => c.CourseID)
                            .Contains(item.CourseID))
                        {
                            if (item.IsDesired)
                            {
                                desiredCourseRepository.SaveDesiredCourse(item);
                            }
                        }
                        else
                        {
                            if (!item.IsDesired)
                            {
                                desiredCourseRepository.DeleteCourse(context.DesiredCourses
                                .FirstOrDefault(i => (i.CourseID == item.CourseID) && (i.InstructorID == item.InstructorID))
                                .DesiredCourseID);
                            }
                        } 
                     }
                }
            }
            return RedirectToAction("Index");
        }

        public ViewResult SetAvailability()
        {
            return View();
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
