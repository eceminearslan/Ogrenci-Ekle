using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace vize.Models;

public partial class OrnekVizeContext : DbContext
{
    public OrnekVizeContext()
    {
    }

    public OrnekVizeContext(DbContextOptions<OrnekVizeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bolum> Bolums { get; set; }

    public virtual DbSet<Der> Ders { get; set; }

    public virtual DbSet<DersAl> DersAls { get; set; }

    public virtual DbSet<DersVer> DersVers { get; set; }

    public virtual DbSet<Hoca> Hocas { get; set; }

    public virtual DbSet<Ogrenci> Ogrencis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ECEARSLAN;Database=ornek_vize;uid=sa;password=sanane;Trusted_Connection=True;Integrated Security=false;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bolum>(entity =>
        {
            entity.ToTable("Bolum");

            entity.Property(e => e.BolumId).ValueGeneratedOnAdd();
            entity.Property(e => e.BolumAd)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.BolumNavigation).WithOne(p => p.Bolum)
                .HasForeignKey<Bolum>(d => d.BolumId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bolum_Hoca");
        });

        modelBuilder.Entity<Der>(entity =>
        {
            entity.HasKey(e => e.DersId);

            entity.Property(e => e.DersAd)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Bolum).WithMany(p => p.Ders)
                .HasForeignKey(d => d.BolumId)
                .HasConstraintName("FK_Ders_Bolum");
        });

        modelBuilder.Entity<DersAl>(entity =>
        {
            entity.HasKey(e => e.DaId);

            entity.ToTable("Ders_Al");

            entity.Property(e => e.DersId).HasColumnName("dersId");

            entity.HasOne(d => d.Ders).WithMany(p => p.DersAls)
                .HasForeignKey(d => d.DersId)
                .HasConstraintName("FK_Ders_Al_Ders");

            entity.HasOne(d => d.Ogrenci).WithMany(p => p.DersAls)
                .HasForeignKey(d => d.OgrenciId)
                .HasConstraintName("FK_Ders_Al_Bolum");

            entity.HasOne(d => d.OgrenciNavigation).WithMany(p => p.DersAls)
                .HasForeignKey(d => d.OgrenciId)
                .HasConstraintName("FK_Ders_Al_Student");
        });

        modelBuilder.Entity<DersVer>(entity =>
        {
            entity.HasKey(e => e.DvId);

            entity.ToTable("Ders_Ver");

            entity.Property(e => e.DvId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Dv).WithOne(p => p.DersVer)
                .HasForeignKey<DersVer>(d => d.DvId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ders_Ver_Ders");

            entity.HasOne(d => d.DvNavigation).WithOne(p => p.DersVer)
                .HasForeignKey<DersVer>(d => d.DvId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ders_Ver_Hoca");
        });

        modelBuilder.Entity<Hoca>(entity =>
        {
            entity.ToTable("Hoca");

            entity.Property(e => e.HocaAdi)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ogrenci>(entity =>
        {
            entity.HasKey(e => e.OgrenciId).HasName("PK_Student");

            entity.ToTable("Ogrenci");

            entity.Property(e => e.OgrenciAd)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OgrenciSoyad)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Bolum).WithMany(p => p.Ogrencis)
                .HasForeignKey(d => d.BolumId)
                .HasConstraintName("FK_Student_Bolum");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
