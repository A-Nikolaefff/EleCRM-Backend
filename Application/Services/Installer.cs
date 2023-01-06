using Application.Services.Requests;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services;

public static class Installer
{
    public static void AddCustomServices(this IServiceCollection container)
    {
        container
            .AddScoped<IRequestService, RequestService>();
    }
}