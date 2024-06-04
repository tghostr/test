using System;
using System.Collections.Generic;

namespace test_avto;

public partial class Smena
{
    public int IdSmena { get; set; }

    public string NameSmena { get; set; } = null!;

    public virtual ICollection<Vrach> Vraches { get; set; } = new List<Vrach>();
}
