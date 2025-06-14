﻿using GymManagement.Application.Services.Common.Interfaces;
using GymManagement.Infrastructure.Admins.Persistence;
using GymManagement.Infrastructure.Common.Persistence;
using GymManagement.Infrastructure.Gyms.Persistence;
using GymManagement.Infrastructure.Subscriptions.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.IoC
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services
                      .AddPersistence();
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<GymManagementDbContext>(options =>
                options.UseSqlite("Data Source = GymManagement.db"));

            services.AddScoped<IAdminsRepository, AdminsRepository>();
            services.AddScoped<IGymsRepository, GymsRepository>();
            services.AddScoped<ISubscriptionsRepository, SubscriptionsRepository>();
            services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<GymManagementDbContext>());

            return services;
        }
    }
}
