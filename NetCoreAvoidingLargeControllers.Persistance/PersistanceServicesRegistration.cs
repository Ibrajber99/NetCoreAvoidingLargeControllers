using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreAvodingLargeControllers.Application.Contracts.Persistance;
using NetCoreAvoidingLargeControllers.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreAvoidingLargeControllers.Persistance
{
    public static class PersistanceServicesRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<TestRegistrationDbContext>(options => options.UseSqlServer
            (configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IAsyncRepository<>),typeof(BaseRepository<>));

            return services;
        }
    }
}
