using System;
using System.Threading.Tasks;
using InvoiceDemo.Contracts;
using InvoiceDemo.Models;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace InvoiceDemo.InvoiceService;

public class InvoiceService(AppDbContext dbContext, IBus bus, IPublishEndpoint publishEP) : IInvoiceService
{
    private readonly AppDbContext DbContext = dbContext;

    public async Task<Invoice> GetInvoice(string name)
    {
        return await DbContext.Invoices
            .Include(x=>x.InvoiceItem)
            .FirstOrDefaultAsync(invoice => invoice.Name == name);
    }
    
    /// <summary>
    /// CreateInvoice
    /// </summary>
    /// <param name="name"></param>
    public async Task CreateInvoice(string name)
    {
        var invoice = new Invoice{Name = name};
        DbContext.Invoices.Add(invoice);
      
        var invoiceData=new InvoiceData { Value = $"{DateTimeOffset.Now}:invoice {name} is saved"};
      
        //1. Publish to Service bus
        //2. Save to DB
        await publishEP.Publish<InvoiceData>( invoiceData, default); //await bus.Publish( invoiceData, default);
        await DbContext.SaveChangesAsync();
         
    }
}

 