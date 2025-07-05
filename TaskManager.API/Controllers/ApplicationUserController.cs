using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Repository.Services;
using TaskManager.ViewModels;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private IApplicationUser _repo;
        public ApplicationUserController(IApplicationUser repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _repo.Get();
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(ApplicationUserVm param)
        {
            var res = await _repo.AddUser(param);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUserVm param)
        {
            var res = await _repo.Update(param);
            return Ok(res);
        }
        [HttpPost]
        public IActionResult Delete(string Id)
        {
            var res = _repo.Delete(Id);
            return Ok(res);
        }
        [HttpPost]
        public async  Task<IActionResult> ChangePassword(string Id, string newPassword)
        {
            var res = await _repo.ChangePassword(Id, newPassword);
            return Ok(res);
        }
    }
}
