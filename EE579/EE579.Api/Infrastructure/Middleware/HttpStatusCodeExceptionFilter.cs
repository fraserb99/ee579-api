using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EE579.Core.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EE579.Api.Infrastructure.Middleware
{
    public class HttpStatusCodeExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = int.MaxValue - 10;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!(context.Exception is HttpStatusCodeException ex)) return;

            context.Result = new ObjectResult(ex.RenderBody())
            {
                StatusCode = ex.Status
            };
            context.ExceptionHandled = true;
        }

        public void OnActionExecuting(ActionExecutingContext context) { }
    }
}
