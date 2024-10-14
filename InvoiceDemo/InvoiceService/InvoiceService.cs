using System.Threading.Tasks;

using InvoiceDemo.Models;

using Microsoft.EntityFrameworkCore;

namespace InvoiceDemo.InvoiceService;

public class InvoiceService(AppDbContext dbContext) : IInvoiceService
{
    public readonly AppDbContext DbContext = dbContext;

    public async Task<Invoice> GetInvoice(string name)
    {
        return await DbContext.Invoices
            .Include(x=>x.InvoiceItem)
            .FirstOrDefaultAsync(invoice => invoice.Name == name);
    }
}

 