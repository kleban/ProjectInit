using Microsoft.AspNetCore.Mvc;
using ProjectInit.Core.Entities.Projects;
using ProjectInit.Repositories.Common;
using ProjectInit.Repositories.Projects;
using ProjectInit.WebUI.Models;
using System.Diagnostics;

namespace ProjectInit.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Project, Guid> repository;
        public HomeController(ILogger<HomeController> logger,
            IRepository<Project, Guid> repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View(repository.GetAllAsync());
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
