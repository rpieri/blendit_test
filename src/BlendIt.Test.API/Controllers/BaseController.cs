using BlendIt.Test.Shared.Commands;
using BlendIt.Test.Shared.Interfaces;
using BlendIt.Test.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlendIt.Test.API.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMediatorHandler mediator;

        public BaseController(IMediatorHandler mediator)
        {
            this.mediator = mediator;
        }

        protected async Task<IActionResult> ResponseBase(CommandResult commandResult)
        {
            if (commandResult != null)
            {
                if (commandResult.Success)
                {

                    return await Task.Run(() => new OkObjectResult(commandResult));
                }

                return await Task.Run(() => new BadRequestObjectResult(commandResult));
            }
            return await Task.Run(() => new BadRequestResult());
        }

        protected async Task<IActionResult> SendCommand(Command command)
        {
            var result = await mediator.SendCommand(command);
            return await ResponseBase(result);
        }

        protected async Task<IActionResult> Execute<TCommand, TViewModel>(TViewModel viewModel)
            where TCommand : Command
            where TViewModel : ViewModelCommand<TCommand>
        {
            var command = viewModel.Mapping();
            return await SendCommand(command);
        }

    }
}
