using System.Threading.Tasks;

using InvoiceDemo.Contracts;

using MassTransit;

using Microsoft.Extensions.Logging;

namespace InvoiceDemo.Consumers
{
    public class InvoiceDemoConsumer :
        IConsumer<InvoiceData>
    {
        readonly ILogger<InvoiceDemoConsumer> _logger;

        public InvoiceDemoConsumer(ILogger<InvoiceDemoConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<InvoiceData> context)
        {
            _logger.LogInformation("Received Text: {Text}", context.Message.Value);
            return Task.CompletedTask;
        }
    }
}
 