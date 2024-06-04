using System;
using System.Collections.Generic;

namespace test_avto;

public partial class Dostup
{
    public int IdDostup { get; set; }

    public string DostupName { get; set; } = null!;

    public virtual ICollection<Sotrudnik> Sotrudniks { get; set; } = new List<Sotrudnik>();
}
