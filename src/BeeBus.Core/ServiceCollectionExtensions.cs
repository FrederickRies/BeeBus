using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BeeBus.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBeeBus(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.TryAddScoped<IMessageBus, MessageBus>();

            // Find all handlers in the provided assembly
            

            foreach (var handler in handlers)
            {

            }
            assembliesTypes
                .GetInterfacesWithImplementationOfType(typeof(IMessageHandler<>))
                .Register(services);

            // Enregitrement des gestionnaires de commandes renvoyant une réponse
            assembliesTypes
                .GetInterfacesWithImplementationOfType(typeof(IMessageHandler<,>))
                .Register(services);

            return services;
        }

        public static IEnumerable<(Type Interface, Type Implementation)> RetrieveAndRegister<THandlerType>(IEnumerable<Assembly> assemblies, Type openGenericInterfaceImplementationType)
        {
            // Retrieve all handlers independantly from their types and their implementations
            var handlers = assemblies
                .SelectMany(a => a.DefinedTypes)
                .Where(t => t.IsClass && !t.IsAbstract &&
                    t.GetInterfaces()
                    .Any(i => i.IsGenericType && 
                        i.GetGenericTypeDefinition() == typeof(IHandler<>)));
            foreach (var  in handlers)
            {
                foreach (var handlers)
            }
                

            foreach ()

            // Pour tous les types implémentant une interface du type recherché
            var list = new List<(Type Interface, Type Implementation)>();
            var implementations = assembliesTypes.GetTypeOf(openGenericInterfaceImplementationType);
            foreach (var implementation in implementations)
            {
                // Identification de toutes les interfaces du type de demandé implémentées dans le type retourné
                var interfaces = implementation.GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == openGenericInterfaceImplementationType);
                foreach (var interfaceType in interfaces)
                {
                    list.Add((interfaceType, implementation));
                }
            }
            return list;
        }


    }
}
