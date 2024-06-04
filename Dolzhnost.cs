using System;
using System.Collections.Generic;

namespace test_avto;

public partial class Dolzhnost
{
    public int IdDolzhnost { get; set; }

    public string NameDolzhnost { get; set; } = null!;

    public virtual ICollection<Vrach> Vraches { get; set; } = new List<Vrach>();
}
