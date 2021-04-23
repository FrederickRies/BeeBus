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
        public async Task WhenWhenNoHandlerFoundForBasicMessage_ThenThowException()
        {
            // Arrange
            var services = new ServiceCollection();
            using var serviceProvider = services.BuildServiceProvider(true);
            using var scope = serviceProvider.CreateScope();
            MessageBus bus = new MessageBus(scope.ServiceProvider);

            // Act
            var resultTask = bus.SendAsync(new BasicMessage(), CancellationToken.None);

            // Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => resultTask);
        }

        /// <summary>
        /// Check if the message bus throw an exception when it does not found any handler to handle the message with response provided.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task WhenNoHandlerFoundForMessageWithResponse_ThenThrowException()
        {
            // Arrange
            var services = new ServiceCollection();
            using var serviceProvider = services.BuildServiceProvider(true);
            using var scope = serviceProvider.CreateScope();
            MessageBus bus = new MessageBus(scope.ServiceProvider);

            // Act
            var resultTask = bus.SendAsync<MessageWithResponse, string>(new MessageWithResponse(), CancellationToken.None);

            //Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => resultTask);
        }


        /// <summary>
        /// Check if a registred handler of a basic message is found correctly by the bus.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task WhenHandlerRegisteredForBasicMessage_ThenBusHandlesMessage()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddScoped<IMessageHandler<BasicMessage>, BasicMessageHandler>();
            using var serviceProvider = services.BuildServiceProvider(true);
            using var scope = serviceProvider.CreateScope();
            MessageBus bus = new MessageBus(scope.ServiceProvider);

            // Act
            var message = new BasicMessage();
            await bus.SendAsync(message, CancellationToken.None);

            // Assert
            Assert.True(message.Handled, Messages.MessageWasNotHandled);
        }

        /// <summary>
        /// Check if a registred handler of a message with response is found correctly by the bus.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task WhenHandlerRegisteredForMessageWithResponse_ThenBusHandlesMessage()
        {
            // Arrange
            var services = new ServiceCollection(); 
            services.AddScoped<IMessageHandler<MessageWithResponse, string>, MessageWithResponseHandler>();
            using var serviceProvider = services.BuildServiceProvider(true);
            using var scope = serviceProvider.CreateScope();
            MessageBus bus = new MessageBus(scope.ServiceProvider);

            // Act
            var message = new MessageWithResponse();
            var response = await bus.SendAsync<MessageWithResponse, string>(message, CancellationToken.None);

            // Assert
            Assert.True(message.Handled, Messages.MessageWasNotHandled);
            Assert.True(response == "OK", Messages.InconsistentResponse);
        }
    }
}
