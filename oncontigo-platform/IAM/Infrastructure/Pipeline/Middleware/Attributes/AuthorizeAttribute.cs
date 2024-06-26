using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using oncontigo_platform.IAM.Domain.Model.Aggregates;

namespace oncontigo_platform.IAM.Infrastructure.Pipeline.Middleware.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
            {
                Console.WriteLine("Skipping authorization");
                return;
            }
            var user = (User?)context.HttpContext.Items["User"];
            if (user is null) context.Result = new UnauthorizedResult();
        }
    }
}
