using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvoiceDemo.Models;

public class Invoice
{
    public int Id { get; private set; }
    [MaxLength(100)]
    public string Name { get; set; }
    public List<InvoiceItem> InvoiceItem { get;private set; }
}