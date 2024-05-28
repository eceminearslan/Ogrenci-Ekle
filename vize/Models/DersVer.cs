using System;
using System.Collections.Generic;

namespace vize.Models;

public partial class DersVer
{
    public int DvId { get; set; }

    public int? HocaId { get; set; }

    public int? DersId { get; set; }

    public virtual Der Dv { get; set; } = null!;

    public virtual Hoca DvNavigation { get; set; } = null!;
}
