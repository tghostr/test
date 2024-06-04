using System;
using System.Collections.Generic;

namespace test_avto;

public partial class Vrach
{
    public int IdVrach { get; set; }

    public string VrachFamiliya { get; set; } = null!;

    public string VrachImya { get; set; } = null!;

    public string VrachOtch { get; set; } = null!;

    public int DolzhnostIdDolzhnost { get; set; }

    public int SmenaIdSmena { get; set; }

    public int StatusIdStatus { get; set; }

    public byte[]? Photo { get; set; }

    public virtual Dolzhnost DolzhnostIdDolzhnostNavigation { get; set; } = null!;

    public virtual ICollection<Poseshenie> Poseshenies { get; set; } = new List<Poseshenie>();

    public virtual Smena SmenaIdSmenaNavigation { get; set; } = null!;

    public virtual Status StatusIdStatusNavigation { get; set; } = null!;
}
