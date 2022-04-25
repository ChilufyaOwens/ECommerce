using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Core.Application.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //Inject Services here
            //services.AddScoped<,> ();
            return services;
        }
    }
}
