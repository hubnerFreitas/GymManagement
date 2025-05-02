using GymManagement.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(options => options.RegisterServicesFromAssemblyContaining(typeof(ApplicationDependencyInjection)));
            return services;
        }
    }
}
