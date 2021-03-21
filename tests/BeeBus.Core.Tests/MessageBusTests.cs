using BeeBus.Core.Dummies;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BeeBus.Core
{
    public class MessageBusTests
    {
        /// <summary>
        /// Check if the message bus throw an exception when it does not found any handler to handle the basic message provided.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ThowExceptionWhenNoHandlerFoundForBasicMessage()
        {
            // Arrange
            var serviceProviderFactory = new DefaultServiceProviderFactory();
            var serviceProvider = serviceProviderFactory.CreateServiceProvider(new ServiceCollection());
            MessageBus bus = new MessageBus(serviceProvider);

            // Act
            var resultTask = bus.SendAsync(new BasicMessage(), CancellationToken.None);

            // Assert
            await Assert.ThrowsAsync<NotSupportedException>(() => resultTask);
        }

        /// <summary>
        /// Check if the message bus throw an exception when it does not found any handler to handle the message with response provided.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ThowExceptionWhenNoHandlerFoundForMessageWithResponse()
        {
            // Arrange
            var serviceProviderFactory = new DefaultServiceProviderFactory();
            var serviceProvider = serviceProviderFactory.CreateServiceProvider(new ServiceCollection());
            MessageBus bus = new MessageBus(serviceProvider);

            // Act/Assert
            var resultTask = bus.SendAsync<MessageWithResponse, string>(new MessageWithResponse(), CancellationToken.None);

            await Assert.ThrowsAsync<NotSupportedException>(() => resultTask);
        }
    }
}
