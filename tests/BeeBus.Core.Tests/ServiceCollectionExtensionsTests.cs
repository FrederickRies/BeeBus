using BeeBus.Core.Dummies;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BeeBus.Core
{
    public class ServiceCollectionExtensionsTests
    {
        /// <summary>
        /// Check if the <c cref="ServiceCollection" /> method "AddBeeBus" register all handlers and the bus himself.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void WhenAddBeeBusCalled_ThenAllHandlersAreRegistered()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddScoped<IMessageHandler<BasicMessage>, BasicMessageHandler>();
            using var serviceProvider = services.BuildServiceProvider(true);

            // Act
            services.AddBeeBus(typeof(BasicMessage).Assembly);
            using var scope = serviceProvider.CreateScope();

            // Assert
            Assert.NotNull(scope.ServiceProvider.GetService<IMessageBus>());
            Assert.NotNull(scope.ServiceProvider.GetService<IMessageHandler<BasicMessage>>());
            Assert.NotNull(scope.ServiceProvider.GetService<IMessageHandler<MessageWithResponse, string>>());
        }
    }
}
