using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back.Extensions;
using back.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace back.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();
            
            if (!resultContext.HttpContext.User.Identity.IsAuthenticated) return;

            var userId = resultContext.HttpContext.User.GetUserId();

            var uow = resultContext.HttpContext.RequestServices.GetRequiredService<IUnitOfWork>();
            var user = await uow.UserRepository.GetUserByIdAsync(userId);
            user.LastActive = DateTime.UtcNow;

            await uow.Complete();
            
        }
    }
}