using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Common.Extensions
{
    public static class DependencyInjectionsExtentions
    {
        public static void RegisterSingleton<T>(this IServiceCollection services, params Assembly[] assemblies)
        {
            IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes())
                .Where(c => c.IsClass && typeof(T).IsAssignableFrom(c));

            foreach (var item in types)
                services.AddSingleton(item);
        }
        public static void RegisterScoped<T>(this IServiceCollection services, params Assembly[] assemblies)
        {
            IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes())
                .Where(c => c.IsClass && typeof(T).IsAssignableFrom(c)).ToList();

            foreach (var item in types)
                services.AddScoped(item);
        }
        public static void RegisterTransient<T>(this IServiceCollection services, params Assembly[] assemblies)
        {
            IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes())
                .Where(c => c.IsClass && typeof(T).IsAssignableFrom(c));

            foreach (var item in types)
                services.AddTransient(item);
        }
    }
}
