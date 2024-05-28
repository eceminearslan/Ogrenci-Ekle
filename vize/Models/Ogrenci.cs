using System;
using System.Collections.Generic;

namespace vize.Models;

public partial class Ogrenci
{
    public int OgrenciId { get; set; }

    public int? BolumId { get; set; }

    public string? OgrenciAd { get; set; }

    public string? OgrenciSoyad { get; set; }

    public virtual Bolum? Bolum { get; set; }

    public virtual ICollection<DersAl> DersAls { get; set; } = new List<DersAl>();
}
