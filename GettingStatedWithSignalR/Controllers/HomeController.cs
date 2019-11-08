using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GettingStatedWithSignalR.Models;
using Microsoft.AspNetCore.SignalR;

namespace GettingStatedWithSignalR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<Hubs.NotificationHub> _hubContext;

        public HomeController(ILogger<HomeController> logger , IHubContext<Hubs.NotificationHub> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Privacy()
        {
            await _hubContext.Clients.All.SendAsync("Notify", $"Conected At {DateTime.Now}");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
