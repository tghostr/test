using System;
using System.Collections.Generic;

namespace test_avto;

public partial class Poseshenie
{
    public int IdPoseshenie { get; set; }

    public int PacientIdPacient { get; set; }

    public int VrachIdVrach { get; set; }

    public DateOnly? DateOfZapis { get; set; }

    public DateTime? DateOfPriem { get; set; }

    public sbyte? FirstOrRepeated { get; set; }

    public int? VidIdVid { get; set; }

    public virtual Pacient PacientIdPacientNavigation { get; set; } = null!;

    public virtual Vid? VidIdV { get; set; }

    public virtual Vrach VrachIdVrachNavigation { get; set; } = null!;
}
