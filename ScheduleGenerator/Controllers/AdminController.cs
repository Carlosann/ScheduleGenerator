using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScheduleGenerator.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScheduleGenerator.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class AdminController : Controller
    {

        private UserManager<AppUser> userManager;
        private AppIdentityDbContext identitycontext;
        private ApplicationDbContext context;
        private SignInManager<AppUser> signInManager;
        private IRoomRepository roomRepository;

        public AdminController(UserManager<AppUser> userMgr, AppIdentityDbContext identCtx,
            ApplicationDbContext ctx, SignInManager<AppUser> singInMgr, IRoomRepository roomRepo)
        {
            userManager = userMgr;
            identitycontext = identCtx;
            context = ctx;
            signInManager = singInMgr;
            roomRepository = roomRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult RoomsList()
        {
            return View(context.Rooms.ToList());
        }

        public ViewResult CreateRoom() => View("AddRoom", new Room());

        public IActionResult AddRoom(Room room)
        {
            roomRepository.SaveRoom(room);
            return RedirectToAction("RoomsList");
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
