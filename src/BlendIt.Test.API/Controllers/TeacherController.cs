using BlendIt.Test.API.ViewModels;
using BlendIt.Test.Domain.Teachers.Commands;
using BlendIt.Test.Domain.Teachers.Repositories;
using BlendIt.Test.Shared.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BlendIt.Test.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TeacherController : BaseController
    {
        private readonly ITeacherRepository repository;

        public TeacherController(
            ITeacherRepository repository,
            IMediatorHandler mediator) : base(mediator)
        {
            this.repository = repository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var teacher = await repository.Get();
            return new OkObjectResult(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddTeacherViewModel viewModel)
            => await Execute<AddTeacherCommand, AddTeacherViewModel>(viewModel);

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateTeacherViewModel viewModel)
            => await Execute<UpdateTeacherCommand, UpdateTeacherViewModel>(viewModel);

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var command = new RemoveTeacherCommand(id);
            return await SendCommand(command);
            
        }
    }
}
