using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GettingStatedWithSignalR.Models;
using Microsoft.AspNetCore.SignalR;
using GettingStatedWithSignalR.Service;

namespace GettingStatedWithSignalR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<Hubs.NotificationHub> _hubContext;
        private readonly IDependencyService _service;

        public HomeController(ILogger<HomeController> logger, IHubContext<Hubs.NotificationHub> hubContext , IDependencyService service)
        {
            _logger = logger;
            _hubContext = hubContext;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            return View(_service.GetAll());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
