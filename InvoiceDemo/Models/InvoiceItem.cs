using System.ComponentModel.DataAnnotations;

namespace InvoiceDemo.Models;

public class InvoiceItem
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }
}