using System;
using System.Collections.Generic;

namespace vize.Models;

public partial class Bolum
{
    public int BolumId { get; set; }

    public string? BolumAd { get; set; }

    public int? BolumNotOrtalaması { get; set; }

    public int? BolumOgrenciSayisi { get; set; }

    public virtual Hoca BolumNavigation { get; set; } = null!;

    public virtual ICollection<Der> Ders { get; set; } = new List<Der>();

    public virtual ICollection<DersAl> DersAls { get; set; } = new List<DersAl>();

    public virtual ICollection<Ogrenci> Ogrencis { get; set; } = new List<Ogrenci>();
}
