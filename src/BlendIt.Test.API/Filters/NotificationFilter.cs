using BlendIt.Test.Shared.Commands;
using BlendIt.Test.Shared.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendIt.Test.API.Filters
{
    internal class NotificationFilter : IAsyncResultFilter
    {
        private readonly NotificationContext notificationContext;

        public NotificationFilter(NotificationContext notificationContext)
        {
            this.notificationContext = notificationContext;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (notificationContext.HasNotification)
            {
                var message = notificationContext.Notifications.Select(x => x.Message).ToList();
                var result = new CommandResult(false, message);

                var log = new StringBuilder();
                message.ForEach(m => log.Append(m));
                Log.Error(log.ToString());

                context.Result = new BadRequestObjectResult(result);
            }
            await next();
        }
    }
}
