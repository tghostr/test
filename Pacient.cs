using System;
using System.Collections.Generic;

namespace test_avto;

public partial class Pacient
{
    public int IdPacient { get; set; }

    public string PacientFamiliya { get; set; } = null!;

    public string PacientImya { get; set; } = null!;

    public string PacientOtch { get; set; } = null!;

    public long PacientPhone { get; set; }

    public long Oms { get; set; }

    public DateOnly PacientDayBirth { get; set; }

    public string PacientEmail { get; set; } = null!;

    public virtual ICollection<Poseshenie> Poseshenies { get; set; } = new List<Poseshenie>();
}
