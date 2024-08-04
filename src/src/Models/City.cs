using System;
using System.Collections.Generic;

namespace src.Models;

public class City
{
    public int Id { get; set; }

    public string CityName { get; set; } = null!;

    public ICollection<Branch> Branches { get; set; } = new List<Branch>();
}
