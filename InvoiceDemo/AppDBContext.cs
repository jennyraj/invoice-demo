using System.Reflection;
using Microsoft.EntityFrameworkCore;
using InvoiceDemo.Models;

namespace InvoiceDemo
{
    public class AppDbContext : DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}