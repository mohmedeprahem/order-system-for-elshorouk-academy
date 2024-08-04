using System;
using System.Collections.Generic;

namespace src.Models;

public class InvoiceDetail
{
    public long Id { get; set; }

    public long InvoiceHeaderId { get; set; }

    public string ItemName { get; set; } = null!;

    public double ItemCount { get; set; }

    public double ItemPrice { get; set; }

    public InvoiceHeader InvoiceHeader { get; set; } = null!;
}
