using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

public class LogIpMiddleware
{
    private readonly RequestDelegate _next;

    public LogIpMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var ip = context.Request.Headers["X-Forwarded-For"].FirstOrDefault()
                 ?? context.Connection.RemoteIpAddress?.ToString();

        Console.WriteLine($"[IP LOG] User IP: {ip}");

        await _next(context);
    }
}