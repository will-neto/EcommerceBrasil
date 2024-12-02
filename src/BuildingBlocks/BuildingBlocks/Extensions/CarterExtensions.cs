﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Carter;

namespace BuildingBlocks.Extensions
{
    public static class CarterExtensions
    {
        public static IServiceCollection AddCarterWithAssemblies(this IServiceCollection services,
            params Assembly[] assemblies)
        {
            services.AddCarter(configurator: config =>
            {
                foreach (var assembly in assemblies)
                {
                    var modules = assembly.GetTypes()
                        .Where(t => t.IsAssignableTo(typeof(ICarterModule)))
                        .ToArray();

                    config.WithModules(modules);
                }
            });
            return services;
        }
    }
}
