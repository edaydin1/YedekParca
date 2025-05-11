using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace YedekParca.WebAPI.Authorization;

public class HttpMethodHandler : AuthorizationHandler<HttpMethodRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        HttpMethodRequirement requirement)
    {
        var httpContext = context.Resource as HttpContext;
        if (httpContext?.Request.Method == requirement.Method.Method)
        {
            context.Succeed(requirement);
        }
        return Task.CompletedTask;
    }
}