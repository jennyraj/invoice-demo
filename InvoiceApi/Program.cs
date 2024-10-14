using System.Reflection;

using InvoiceApi;

using InvoiceDemo;
using InvoiceDemo.InvoiceService;

using MassTransit;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Validations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x =>
{
   x.SetKebabCaseEndpointNameFormatter();
     

   var entryAssembly = Assembly.GetEntryAssembly();

   x.AddConsumers(entryAssembly);
  
    //IN MEMORY
    // x.UsingInMemory((context, cfg) =>
    // {
    //     cfg.ConfigureEndpoints(context);
    // });

    //RABBITMQ
   x.UsingRabbitMq((context, cfg) =>
   {
       cfg.Host("localhost", "/", h =>
       {
           h.Username("guest");
           h.Password("guest");
       });

       cfg.ConfigureEndpoints(context);
   });
});

builder.Services.AddHostedService<Worker>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
  options.UseSqlServer(connectionString, b=>b.MigrationsAssembly("InvoiceApi")));
builder.Services.AddScoped<IInvoiceService, InvoiceService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapInvoiceEndPoints();

app.Run();


