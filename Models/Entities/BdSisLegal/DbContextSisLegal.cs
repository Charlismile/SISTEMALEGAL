using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SISTEMALEGAL.Models.Entities.BdSisLegal;

public partial class DbContextSisLegal : DbContext
{
    public DbContextSisLegal()
    {
    }

    public DbContextSisLegal(DbContextOptions<DbContextSisLegal> options)
        : base(options)
    {
    }

    public virtual DbSet<ApoderadoLegal> ApoderadoLegal { get; set; }

    public virtual DbSet<DocumentoAdjunto> DocumentoAdjunto { get; set; }

    public virtual DbSet<JuntaInterventora> JuntaInterventora { get; set; }

    public virtual DbSet<MiembroComite> MiembroComite { get; set; }

    public virtual DbSet<RegistroAsociaciones> RegistroAsociaciones { get; set; }

    public virtual DbSet<RegistroComite> RegistroComite { get; set; }

    public virtual DbSet<RepresentanteLegal> RepresentanteLegal { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApoderadoLegal>(entity =>
        {
            entity.HasIndex(e => e.RegistroAsociacionId, "IX_ApoderadoLegal_RegistroAsociacionId");

            entity.Property(e => e.Cedula).HasMaxLength(20);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirmaAbogadosNombre).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Telefono).HasMaxLength(20);

            entity.HasOne(d => d.RegistroAsociacion).WithMany(p => p.ApoderadoLegal)
                .HasForeignKey(d => d.RegistroAsociacionId)
                .HasConstraintName("FK_ApoderadoLegal_RegistroAsociaciones");
        });

        modelBuilder.Entity<DocumentoAdjunto>(entity =>
        {
            entity.HasIndex(e => e.RegistroAsociacionId, "IX_DocumentoAdjunto_RegistroAsociacionId").HasFilter("([RegistroAsociacionId] IS NOT NULL)");

            entity.HasIndex(e => e.RegistroComiteId, "IX_DocumentoAdjunto_RegistroComiteId").HasFilter("([RegistroComiteId] IS NOT NULL)");

            entity.Property(e => e.FechaSubida).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NombreOriginal).HasMaxLength(255);
            entity.Property(e => e.RutaArchivo).HasMaxLength(512);
            entity.Property(e => e.TipoDocumento).HasMaxLength(100);
            entity.Property(e => e.UsuarioId).HasMaxLength(450);

            entity.HasOne(d => d.RegistroAsociacion).WithMany(p => p.DocumentoAdjunto)
                .HasForeignKey(d => d.RegistroAsociacionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DocumentoAdjunto_RegistroAsociaciones");

            entity.HasOne(d => d.RegistroComite).WithMany(p => p.DocumentoAdjunto)
                .HasForeignKey(d => d.RegistroComiteId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DocumentoAdjunto_RegistroComite");
        });

        modelBuilder.Entity<JuntaInterventora>(entity =>
        {
            entity.HasIndex(e => e.RegistroComiteId, "IX_JuntaInterventora_RegistroComiteId");

            entity.Property(e => e.Cedula).HasMaxLength(20);
            entity.Property(e => e.Nombre).HasMaxLength(255);

            entity.HasOne(d => d.RegistroComite).WithMany(p => p.JuntaInterventora)
                .HasForeignKey(d => d.RegistroComiteId)
                .HasConstraintName("FK_JuntaInterventora_RegistroComite");
        });

        modelBuilder.Entity<MiembroComite>(entity =>
        {
            entity.HasIndex(e => e.RegistroComiteId, "IX_MiembroComite_RegistroComiteId");

            entity.Property(e => e.Cargo).HasMaxLength(50);
            entity.Property(e => e.Cedula).HasMaxLength(20);
            entity.Property(e => e.Nombre).HasMaxLength(255);

            entity.HasOne(d => d.RegistroComite).WithMany(p => p.MiembroComite)
                .HasForeignKey(d => d.RegistroComiteId)
                .HasConstraintName("FK_MiembroComite_RegistroComite");
        });

        modelBuilder.Entity<RegistroAsociaciones>(entity =>
        {
            entity.HasKey(e => e.RegistroAsociacionId);

            entity.Property(e => e.ActividadSalud).HasMaxLength(255);
            entity.Property(e => e.Asociacion).HasMaxLength(255);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
        });

        modelBuilder.Entity<RegistroComite>(entity =>
        {
            entity.Property(e => e.ComiteSalud).HasMaxLength(255);
            entity.Property(e => e.Comunidad).HasMaxLength(255);
            entity.Property(e => e.Corregimiento).HasMaxLength(255);
            entity.Property(e => e.Distrito).HasMaxLength(255);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaEleccion).HasColumnType("datetime");
            entity.Property(e => e.Provincia).HasMaxLength(255);
            entity.Property(e => e.RegionSalud).HasMaxLength(255);
            entity.Property(e => e.TipoTramite).HasMaxLength(50);
        });

        modelBuilder.Entity<RepresentanteLegal>(entity =>
        {
            entity.HasIndex(e => e.RegistroAsociacionId, "IX_RepresentanteLegal_RegistroAsociacionId");

            entity.Property(e => e.Cargo).HasMaxLength(100);
            entity.Property(e => e.Cedula).HasMaxLength(20);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Telefono).HasMaxLength(20);

            entity.HasOne(d => d.RegistroAsociacion).WithMany(p => p.RepresentanteLegal)
                .HasForeignKey(d => d.RegistroAsociacionId)
                .HasConstraintName("FK_RepresentanteLegal_RegistroAsociaciones");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
