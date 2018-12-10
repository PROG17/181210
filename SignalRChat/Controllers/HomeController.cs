using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRChat.Hubs;
using SignalRChat.Models;

namespace SignalRChat.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHubContext<ChatHub> chatHub;
        public HomeController(IHubContext<ChatHub> chatHub)
        {
            this.chatHub = chatHub;
        }

        public async Task<IActionResult> Index(string name)
        {
            await chatHub.Clients.All.SendAsync("ReceiveMessage", name, "joined the chat");

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
