using InvoiceDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceDemo.Configurations;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable("Invoice");
        builder.HasKey(i => i.Id);
           
        builder.HasMany(d =>d.InvoiceItem)
            .WithOne()
            .HasForeignKey(r => r.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}