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

        private readonly IChat _chat;
        private readonly UserManager<ChatUser> _userManager;

        public HomeController(IChat chat, UserManager<ChatUser> userManager)
        {
            _chat = chat;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            ViewBag.CurrentUserAlias = currentUser?.Alias ?? "Anonymous";
            var messages = _chat.GetMessagesesAsync();
            return View(messages);
        }

        public IActionResult Create() => View(new Message());

        [HttpPost]
        public async Task<IActionResult> Create(Message mes)
        {
            if (ModelState.IsValid)
            {
                mes.UserName = User.Identity.Name;
                mes.Sender = await _userManager.GetUserAsync(User);
                await _chat.AddMessageAsync(mes);
                return Ok();
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

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => 
            View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
