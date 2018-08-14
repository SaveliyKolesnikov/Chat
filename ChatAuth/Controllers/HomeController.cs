using System;
using System.Diagnostics;
using System.Threading.Tasks;
using ChatAuth.Data;
using ChatAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChatAuth.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<ChatUser> _userManager;

        public HomeController(ApplicationDbContext db, UserManager<ChatUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.User = await _userManager.GetUserAsync(User);
            return View(_db.Messages);
        }

        public IActionResult Create()
        {
            return View(new Message());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Message mes)
        {
            if (ModelState.IsValid)
            {
                mes.UserName = User.Identity.Name;
                mes.When = DateTime.Now;
                await _db.Messages.AddAsync(mes);
                await _db.SaveChangesAsync();
                return Ok();
                //return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
