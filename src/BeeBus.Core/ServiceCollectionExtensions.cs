using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BeeBus.Core
{
    public static class ServiceCollectionExtensions
    {
        public static BusBuilder AddBeeBus(this IServiceCollection services, params Assembly[] assemblies)
        {
            // Registers the bus himself
            services.TryAddSingleton<IMessageBus, MessageBus>();

            // Find all handlers in the provided assemblies and registers them dependantly from their type.
            services.SeekAndRegister(assemblies);

            return new BusBuilder(services);
        }

        /// <summary>
        /// Retrieves all handlers defined in the provided assemblies.
        /// </summary>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        public static IEnumerable<Type> RetrieveHandlersFromAssemblies(IEnumerable<Assembly> assemblies)
        {
            // Retrieve all handlers independantly from their types and their implementations
            return assemblies
                .SelectMany(a => a.DefinedTypes)
                .Where(t => t.IsClass && !t.IsAbstract &&
                    t.GetInterfaces()
                    .Any(i => i.IsGenericType &&
                        i.GetGenericTypeDefinition() == typeof(IHandler<>)));
        }

        /// <summary>
        /// Searchiiiiiinnnnnnng seek and register...
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblies"></param>
        public static void SeekAndRegister(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            foreach (var handlerImplementation in RetrieveHandlersFromAssemblies(assemblies))
            {
                services.RegisterAll(typeof(IMessageHandler<>), handlerImplementation);
                services.RegisterAll(typeof(IMessageHandler<,>), handlerImplementation);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="handlerType"></param>
        /// <param name="handlerImplementation"></param>
        public static void RegisterAll(this IServiceCollection services, Type handlerType, Type handlerImplementation)
        {
            var handlerInterfaces = handlerImplementation.GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerType);
            foreach (var handlerInterface in handlerInterfaces)
            {
                services.Add(new ServiceDescriptor(handlerInterface, handlerImplementation, ServiceLifetime.Scoped));
            }
        }
    }
}
