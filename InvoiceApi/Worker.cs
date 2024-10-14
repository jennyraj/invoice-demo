using InvoiceDemo.Contracts;

namespace InvoiceApi;

using System;
using System.Threading;
using System.Threading.Tasks;

using InvoiceDemo.Contracts;

using MassTransit;

using Microsoft.Extensions.Hosting;

public class Worker : BackgroundService
{
    private readonly IBus _bus;

    public Worker(IBus bus)
    {
        _bus = bus;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        
        while (!stoppingToken.IsCancellationRequested)
        {
             
          //  await _bus.Publish(new InvoiceData() { Value = $"The time is {DateTimeOffset.Now}" }, stoppingToken);
            
            await Task.Delay(1000, stoppingToken);
        }
    }
}