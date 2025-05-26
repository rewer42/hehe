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
        var ipAddress = context.Connection.RemoteIpAddress?.ToString();
        Console.WriteLine($"[IP LOG] User IP: {ipAddress}");

        await _next(context);
    }
}