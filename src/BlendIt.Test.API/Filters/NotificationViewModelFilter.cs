using BlendIt.Test.Shared.Commands;
using BlendIt.Test.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendIt.Test.API.Filters
{
    internal class NotificationViewModelFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var objeto = context.ActionArguments.Select(x => x.Value).FirstOrDefault(v => v is ViewModel);
            if (objeto != null)
            {
                var viewModel = objeto as ViewModel;
                if (!viewModel.Validate())
                {
                    var messages = viewModel.ValidationResult.Errors.Select(err => err.ErrorMessage).ToList();
                    var result = new CommandResult(false, messages);

                    var log = new StringBuilder();
                    messages.ForEach(m => log.Append(m));
                    Log.Error(log.ToString());

                    context.Result = new BadRequestObjectResult(result);
                    return;
                }
            }

            await next();
        }
    }
}
