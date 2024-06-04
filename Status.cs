using System;
using System.Collections.Generic;

namespace test_avto;

public partial class Status
{
    public int IdStatus { get; set; }

    public string NameStatus { get; set; } = null!;

    public virtual ICollection<Vrach> Vraches { get; set; } = new List<Vrach>();
}
