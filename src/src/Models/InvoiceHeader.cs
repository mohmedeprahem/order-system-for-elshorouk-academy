using System;
using System.Collections.Generic;

namespace src.Models;

public class InvoiceHeader
{
    public long Id { get; set; }

    public string CustomerName { get; set; } = null!;

    public DateTime Invoicedate { get; set; }

    public int? CashierId { get; set; }

    public int BranchId { get; set; }

    public Branch Branch { get; set; } = null!;

    public Cashier? Cashier { get; set; }

    public ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}
