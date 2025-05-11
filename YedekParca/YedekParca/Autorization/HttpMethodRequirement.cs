using Microsoft.AspNetCore.Authorization;

namespace YedekParca.WebAPI.Authorization;

public class HttpMethodRequirement : IAuthorizationRequirement
{
    public HttpMethod Method { get; }
    public HttpMethodRequirement(string method) => Method = new HttpMethod(method);
}