using System;
using System.Diagnostics;
using System.Threading.Tasks;
using ChatAuth.Data;
using ChatAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var currentUser = await _userManager.GetUserAsync(User);
            ViewBag.CurrentUserAlias = currentUser?.Alias ?? currentUser?.UserName ?? "Anonymous";
            var messages = await _db.Messages.Include(m => m.Sender).ToArrayAsync();
            return View(messages);
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
                mes.Sender = await _userManager.GetUserAsync(User);
                await _db.Messages.AddAsync(mes);
                await _db.SaveChangesAsync();
                return Ok();
                //return RedirectToAction("Index");
            }

            return Error();
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
