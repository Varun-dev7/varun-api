using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Repository.Services;
using TaskManager.ViewModel;
using TaskManager.ViewModels.Enum;

namespace TaskManager.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private ITaskManager _repo;
        public TaskController(ITaskManager repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var res = _repo.Get();
            return Ok(res);
        }
        [HttpGet]
        public IActionResult GetByStatus(EBool status)
        {
            var res = _repo.Gett(status);
            return Ok(res);
        }
        [HttpPost]
        public IActionResult Add(TaskManagerVm user)
        {
            var res = _repo.Add(user);
            return Ok(res);
        }
        [HttpPost]
        public IActionResult Update(TaskManagerVm user)
        {
            var res = _repo.Update(user);
            return Ok(res);
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var res = _repo.Delete(Id);
            return Ok(res);
        }
    }
}
