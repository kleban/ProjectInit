using Humanizer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Core.Types;
using ProjectInit.Core.Entities.Projects;
using ProjectInit.Repositories.Projects;
using ProjectInit.Repositories.Users;
using ProjectInit.WebUI.Helpers;

namespace ProjectInit.WebUI.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProjectsController(
            IProjectRepository projectRepository,
            IUserRepository userRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index(string viewType = ViewType.Table)
        {
            var data = await _projectRepository.GetAllAsync();
            return View($"{viewType.ApplyCase(LetterCasing.Sentence)}View", data);
        }

        // GET: ProjectsController/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            return View(await _projectRepository.GetAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {            
            ViewBag.Teachers = (await _userRepository
                .GetAllAsync())
                .Select(x => new SelectListItem { Text = x.FullName, Value = x.Id.ToString() }).ToList();

            return View(new Project());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Project model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile is not null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;

                    var fileExt = Path.GetExtension(model.ImageFile.FileName);
                    var filePath = Path.Combine("/img/projects/", $"{model.Id}{fileExt}");
                    string path = Path.Combine(wwwRootPath, "img\\projects\\", $"{model.Id}{fileExt}");

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(fileStream);
                    }

                    model.ImagePath = filePath;
                }

                await _projectRepository.CreateAsync(model);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Teachers = (await _userRepository
                .GetAllAsync())
                .Select(x => new SelectListItem { Text = x.FullName, Value = x.Id.ToString() }).ToList();

            return View(model);
        }

        // GET: ProjectsController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.Teachers = (await _userRepository
             .GetAllAsync())
             .Select(x => new SelectListItem { Text = x.FullName, Value = x.Id.ToString() }).ToList();

            return View(await _projectRepository.GetAsync(id));
        }

        // POST: ProjectsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjectsController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            return View(await _projectRepository.GetAsync(id));
        }

        // POST: ProjectsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, IFormCollection form)
        {
            try
            {
                await _projectRepository.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Delete", new { id = id });
            }
        }
    }

}

