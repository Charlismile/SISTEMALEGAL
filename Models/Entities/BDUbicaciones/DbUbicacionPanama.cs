using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SISTEMALEGAL.Models.Entities.BDUbicaciones;

public partial class DbUbicacionPanama : DbContext
{
    public DbUbicacionPanama()
    {
    }

    public DbUbicacionPanama(DbContextOptions<DbUbicacionPanama> options)
        : base(options)
    {
    }

    public virtual DbSet<Corregimiento> Corregimiento { get; set; }

    public virtual DbSet<Distrito> Distrito { get; set; }

    public virtual DbSet<Provincia> Provincia { get; set; }

    public virtual DbSet<RegionSalud> RegionSalud { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:UbicacionConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Corregimiento>(entity =>
        {
            entity.HasKey(e => e.CorregimientoId).HasName("PK__Corregim__3214EC0762FB3DAA");

            entity.HasIndex(e => new { e.CodigoCorregimiento, e.DistritoId }, "UQ_Corregimiento_Codigo").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.Distrito).WithMany(p => p.Corregimiento)
                .HasForeignKey(d => d.DistritoId)
                .HasConstraintName("FK__Corregimi__Distr__5535A963");
        });

        modelBuilder.Entity<Distrito>(entity =>
        {
            entity.HasKey(e => e.DistritoId).HasName("PK__Distrito__3214EC07355E8722");

            entity.HasIndex(e => new { e.CodigoDistrito, e.ProvinciaId }, "UQ_Distrito_Codigo").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.Provincia).WithMany(p => p.Distrito)
                .HasForeignKey(d => d.ProvinciaId)
                .HasConstraintName("FK__Distrito__Provin__5629CD9C");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.ProvinciaId).HasName("PK__Provinci__3214EC072A99A560");

            entity.HasIndex(e => e.CodigoProvincia, "UQ_Provincia_Codigo").IsUnique();

            entity.HasIndex(e => e.Nombre, "UQ_Provincia_Nombre").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.RegionSalud).WithMany(p => p.Provincia)
                .HasForeignKey(d => d.RegionSaludId)
                .HasConstraintName("FK__Provincia__Regio__571DF1D5");
        });

        modelBuilder.Entity<RegionSalud>(entity =>
        {
            entity.HasKey(e => e.RegionSaludId).HasName("PK__RegionSa__3214EC07DB0DE7BC");

            entity.HasIndex(e => e.Nombre, "UQ__RegionSa__75E3EFCFC55DD11A").IsUnique();

            entity.HasIndex(e => e.CodigoRegion, "UQ__RegionSa__7F1F2F9B39B04293").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
