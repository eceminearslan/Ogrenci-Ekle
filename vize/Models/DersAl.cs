using System;
using System.Collections.Generic;

namespace vize.Models;

public partial class DersAl
{
    public int DaId { get; set; }

    public int? OgrenciId { get; set; }

    public int? DersId { get; set; }

    public int? BolumId { get; set; }

    public int? Not { get; set; }

    public virtual Der? Ders { get; set; }

    public virtual Bolum? Ogrenci { get; set; }

    public virtual Ogrenci? OgrenciNavigation { get; set; }
}
