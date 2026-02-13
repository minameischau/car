using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CaraCara.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(typeof(DependencyInjection));
        
        return services;
    }
}
