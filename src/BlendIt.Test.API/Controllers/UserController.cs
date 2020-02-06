using BlendIt.Test.API.ViewModels;
using BlendIt.Test.Domain.Users.Commands;
using BlendIt.Test.Shared.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlendIt.Test.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : BaseController
    {
        public UserController(IMediatorHandler mediator) : base(mediator)
        {
        }
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddUserViewModel viewModel)
            => await Execute<AddUserCommand, AddUserViewModel>(viewModel);

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]AuthenticationViewModel viewModel)
            => await Execute<AuthenticationCommand, AuthenticationViewModel>(viewModel);
    }
}
