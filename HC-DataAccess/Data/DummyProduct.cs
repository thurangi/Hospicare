using System;
using System.Collections.Generic;

namespace HC_DataAccess.Data;

public partial class DummyProduct
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }
}
