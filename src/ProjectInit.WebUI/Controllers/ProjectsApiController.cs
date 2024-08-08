using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectInit.Core.Entities.Projects;
using ProjectInit.Repositories.Projects;

namespace ProjectInit.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsApiController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectsApiController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _projectRepository.GetAllAsync();
        }
    }
}
