using System;
using System.Collections.Generic;

namespace vize.Models;

public partial class Der
{
    public int DersId { get; set; }

    public int? BolumId { get; set; }

    public string? DersAd { get; set; }

    public int? DersKredi { get; set; }

    public virtual Bolum? Bolum { get; set; }

    public virtual ICollection<DersAl> DersAls { get; set; } = new List<DersAl>();

    public virtual DersVer? DersVer { get; set; }
}
