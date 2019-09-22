using Core.Interfaces;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            // register all services
            services.Scan(scan => scan
              .FromAssemblyOf<IService>()
                .AddClasses(classes => classes.AssignableTo<IService>())
                    .AsMatchingInterface()
                    .WithScopedLifetime());
        }
    }
}
