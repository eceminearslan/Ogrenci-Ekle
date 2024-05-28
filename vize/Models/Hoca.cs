using System;
using System.Collections.Generic;

namespace vize.Models;

public partial class Hoca
{
    public int HocaId { get; set; }

    public int? BolumId { get; set; }

    public string? HocaAdi { get; set; }

    public int? VerilenDersSayisi { get; set; }

    public virtual Bolum? Bolum { get; set; }

    public virtual DersVer? DersVer { get; set; }
}
