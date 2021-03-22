﻿using System.Threading;
using System.Threading.Tasks;

namespace BeeBus.Core.Dummies
{
    public class BasicMessageHandler : IMessageHandler<BasicMessage>
    {

        public Task HandleAsync(BasicMessage message, CancellationToken cancellation)
        {
            message.Handled = true;
            return Task.CompletedTask;
        }
    }
}
