using InvoiceDemo.InvoiceService;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceApi
{
    public static class InvoiceEndpointsExt
    {
        public static void MapInvoiceEndPoints(this WebApplication app)
        {
             
            app.MapGet("/weatherforecast", ([FromServices] IInvoiceService service, string name) =>
                    {
                        return service.GetInvoice(name);
                    }
            
            )
            .WithName("GetWeatherForecast")
                .WithOpenApi();
        }
    }
}
