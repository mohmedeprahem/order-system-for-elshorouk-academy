using System;
using System.Collections.Generic;

namespace src.Models;

public class Branch
{
    public int Id { get; set; }

    public string BranchName { get; set; } = null!;

    public int CityId { get; set; }

    public ICollection<Cashier> Cashiers { get; set; } = new List<Cashier>();

    public City City { get; set; } = null!;

    public ICollection<InvoiceHeader> InvoiceHeaders { get; set; } = new List<InvoiceHeader>();
}
