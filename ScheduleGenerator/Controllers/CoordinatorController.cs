using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using ScheduleGenerator.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScheduleGenerator.Controllers
{
    [Authorize(Roles = "COORDINATOR")]
    public class CoordinatorController : Controller
    {
        private UserManager<AppUser> userManager;
        private AppIdentityDbContext identitycontext;
        private ApplicationDbContext context;
        private SignInManager<AppUser> signInManager;
        private IDesiredCourseRepository desiredCourseRepository;
        private ICourseRepository courseRepository;

        public CoordinatorController(UserManager<AppUser> userMgr, AppIdentityDbContext identCtx,
            ApplicationDbContext ctx, SignInManager<AppUser> singInMgr, IDesiredCourseRepository desRepo,
            ICourseRepository couRepo)
        {
            userManager = userMgr;
            identitycontext = identCtx;
            context = ctx;
            signInManager = singInMgr;
            desiredCourseRepository = desRepo;
            courseRepository = couRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ViewResult> InstructorList()
        {
            var user = await userManager.GetUserAsync(User);
            var department = user.Department;
         
            return View(
                identitycontext.Users.Where(u=> u.Department == department)
                );
        }

        public async Task<ViewResult> CourseList()
        {
            var user = await userManager.GetUserAsync(User);
            var department = context.Departments.FirstOrDefault(d => d.DepartmentCode == user.Department);
            ViewBag.Dep = department.DepartmentCode;
            return View(
                context.Courses.Where(c => c.DepartmentID == department.DepartmentID)
                );
        }

        public async Task<ViewResult> AccountDetails()
        {
            var user = await userManager.GetUserAsync(User);
            var department = context.Departments.FirstOrDefault(d => d.DepartmentCode == user.Department);
            ViewBag.Dep = department.DepartmentName;
            return View(user);
        }

        public  ViewResult ValidateCourses(string instructorId)
        {
            CourseValidation courseSelection = new CourseValidation
            {
                DesiredCourses = context.DesiredCourses.Where(c => c.InstructorID == instructorId).ToList(),
                Courses = new List<Course>()
            };

            foreach (var item in courseSelection.DesiredCourses)
            {
                courseSelection.Courses.Add(context.Courses.FirstOrDefault(c => c.CourseID == item.CourseID));
            }

            return View(courseSelection);
        }

        [HttpPost]
        public IActionResult UpdateDesiredCourses(CourseSelection model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    foreach (var item in model.DesiredCourses)
                    {
                        desiredCourseRepository.SaveDesiredCourse(item);
                    }
                }
                catch { }
            }
            return RedirectToAction("Index");
        }

        public ViewResult EditCourse(int courseId)
        {
            return View(context.Courses.FirstOrDefault(c => c.CourseID == courseId));
        }

        [HttpPost]
        public IActionResult UpdateCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                courseRepository.SaveCourse(course);
            }
            return RedirectToAction("CourseList");
        }

        public async Task<RedirectResult> Logout (string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
