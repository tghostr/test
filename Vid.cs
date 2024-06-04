using System;
using System.Collections.Generic;

namespace test_avto;

public partial class Vid
{
    public int IdVid { get; set; }

    public string Vid1 { get; set; } = null!;

    public virtual ICollection<Poseshenie> Poseshenies { get; set; } = new List<Poseshenie>();
}
