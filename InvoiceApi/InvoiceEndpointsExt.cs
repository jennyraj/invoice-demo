using InvoiceDemo.InvoiceService;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceApi
{
    public static class InvoiceEndpointsExt
    {
        public static void MapInvoiceEndPoints(this WebApplication app)
        {
            app.MapGet("/Invoice",
                    ([FromServices] IInvoiceService service, string name) => { return service.GetInvoice(name); }
                )
                .WithName("GetInvoice")
                .WithOpenApi();
            
            app.MapPost("/Invoice",
                    ([FromServices] IInvoiceService service, string name) => { return service.CreateInvoice(name); }
                )
                .WithName("CreateInvoice")
                .WithOpenApi();
        }
    }
}