using BeeBus;
using BeeBus.Core;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;

namespace Benchmarks
{
    [SimpleJob(RuntimeMoniker.NetCoreApp50)]
#pragma warning disable S3881 // "IDisposable" should be implemented correctly
    public class BeeBusTests
#pragma warning restore S3881 // "IDisposable" should be implemented correctly
    {
#pragma warning disable IDISP006 // Implement IDisposable.
        private ServiceProvider? _serviceProvider;
#pragma warning restore IDISP006 // Implement IDisposable.

        [GlobalSetup]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddBeeBus(typeof(BasicMessage).Assembly);
            _serviceProvider?.Dispose();
            _serviceProvider = services.BuildServiceProvider(false);
        }

        [Benchmark]
        public async Task SimpleHandling()
        {
            using var scope = _serviceProvider!.CreateScope();
            var messageBus = scope.ServiceProvider.GetRequiredService<IMessageBus>();
            await messageBus.SendAsync(new BasicMessage(), CancellationToken.None);
        }

        [Benchmark]
        public async Task SimpleHandlingWithResponse()
        {
            using var scope = _serviceProvider!.CreateScope();
            var messageBus = scope.ServiceProvider.GetRequiredService<IMessageBus>();
            await messageBus.SendAsync<MessageWithResponse, string>(new MessageWithResponse(), CancellationToken.None);
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _serviceProvider?.Dispose();
        }
    }
}
