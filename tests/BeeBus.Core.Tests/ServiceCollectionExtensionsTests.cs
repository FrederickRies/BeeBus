using BeeBus.Core.Dummies;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
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

            // Act
            services.AddBeeBus(typeof(BasicMessage).Assembly);
            using var serviceProvider = services.BuildServiceProvider(false);
            using var scope = serviceProvider.CreateScope();

            // Assert
            Assert.True(null != scope.ServiceProvider.GetService<IMessageBus>(), string.Format(Messages.CouldNotResolveType, typeof(IMessageBus).Name));
            Assert.True(null != scope.ServiceProvider.GetService<IMessageHandler<BasicMessage>>(), string.Format(Messages.CouldNotResolveType, typeof(IMessageHandler<BasicMessage>).Name));
            Assert.True(null != scope.ServiceProvider.GetService<IMessageHandler<MessageWithResponse, string>>(), string.Format(Messages.CouldNotResolveType, typeof(IMessageHandler<MessageWithResponse>).Name));
        }

        /// <summary>
        /// Check if the <c cref="ServiceCollection" /> method "AddBeeBus" does not take into account interfaces.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task WhenAddBeeBusCalled_ThenAllInterfaceHandlersAreNotRegistered()
        {
            // Arrange
            var services = new ServiceCollection();

            // Act
            services.AddBeeBus(typeof(BasicMessage).Assembly);
            using var serviceProvider = services.BuildServiceProvider(false);
            using var scope = serviceProvider.CreateScope();
            var messageBus = new MessageBus(scope.ServiceProvider);
            var resultTask = messageBus.SendAsync(new AbstractMessage(), CancellationToken.None);

            // Assert
            Assert.True(typeof(IMessageHandler<InterfaceMessage>).IsAssignableFrom(typeof(InterfaceMessageHandler)));
            await Assert.ThrowsAsync<InvalidOperationException>(() => resultTask);
        }

        /// <summary>
        /// Check if the <c cref="ServiceCollection" /> method "AddBeeBus" does not take into account abstract classes.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task WhenAddBeeBusCalled_ThenAllAbstractHandlersAreNotRegistered()
        {
            // Arrange
            var services = new ServiceCollection();

            // Act
            services.AddBeeBus(typeof(BasicMessage).Assembly);
            using var serviceProvider = services.BuildServiceProvider(false);
            using var scope = serviceProvider.CreateScope();
            var messageBus = new MessageBus(scope.ServiceProvider);
            var resultTask = messageBus.SendAsync(new AbstractMessage(), CancellationToken.None);

            // Assert
            Assert.True(typeof(IMessageHandler<AbstractMessage>).IsAssignableFrom(typeof(AbstractMessageHandler)));
            await Assert.ThrowsAsync<InvalidOperationException>(() => resultTask);
        }
    }
}
