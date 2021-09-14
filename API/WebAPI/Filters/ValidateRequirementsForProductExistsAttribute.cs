using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace WebAPI.Filters
{
    public class ValidateRequirementsForProductExistsAttribute : IAsyncActionFilter
    {
        private readonly IRepositoryWrapper repository;
        private readonly ILoggerManager logger;
        public ValidateRequirementsForProductExistsAttribute(IRepositoryWrapper repository,
       ILoggerManager logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var method = context.HttpContext.Request.Method;
            var trackChanges = (method.Equals("PUT") || method.Equals("PATCH")) ? true : false;

            var productId = (Guid)context.ActionArguments["productId"];
            var product = await repository.Product.GetProductAsync(productId, false);

            if (product == null)
            {
                logger.LogInfo($"Product with id: {productId} doesn't exist in the database.");
               
                context.Result = new NotFoundResult();
                return;
            }

            var id = (Guid)context.ActionArguments["id"];
            var requirements = await repository.SystemRequirements.GetRequirementsAsync(productId, id, trackChanges);
            if (requirements == null)
            {
                logger.LogInfo($"Requirements with id: {id} doesn't exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("requirements", requirements);
                await next();
            }
        }
    }
}
