using System.Threading.Tasks;
using InvoiceDemo.Models;

namespace InvoiceDemo.InvoiceService;

public interface IInvoiceService
{
    Task<Invoice> GetInvoice(string name);
    Task CreateInvoice(string name);
}