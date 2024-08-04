using System;
using System.Collections.Generic;

namespace src.Models;

public class Cashier
{
    public int Id { get; set; }

    public string CashierName { get; set; } = null!;

    public int BranchId { get; set; }

    public Branch Branch { get; set; } = null!;

    public ICollection<InvoiceHeader> InvoiceHeaders { get; set; } = new List<InvoiceHeader>();
}
