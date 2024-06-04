using System;
using System.Collections.Generic;

namespace test_avto;

public partial class Sotrudnik
{
    public int IdSotrudnik { get; set; }

    public string SotrudnikFamiliya { get; set; } = null!;

    public string SotrudnikImya { get; set; } = null!;

    public string SotrudnikOtch { get; set; } = null!;

    public string SotrudnikPass { get; set; } = null!;

    public string SotrudnikLogin { get; set; } = null!;

    public int DostupIdDostup { get; set; }

    public virtual Dostup DostupIdDostupNavigation { get; set; } = null!;
}
