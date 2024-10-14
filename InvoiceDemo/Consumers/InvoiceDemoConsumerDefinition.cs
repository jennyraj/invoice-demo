using MassTransit;

namespace InvoiceDemo.Consumers
{
    public class InvoiceDemoConsumerDefinition :
        ConsumerDefinition<InvoiceDemoConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<InvoiceDemoConsumer> consumerConfigurator, IRegistrationContext context)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));

            endpointConfigurator.UseInMemoryOutbox(context);
        }
    }
}