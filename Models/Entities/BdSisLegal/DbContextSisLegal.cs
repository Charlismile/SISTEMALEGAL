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
            entity.HasKey(e => e.Id).HasName("PK__Apoderad__3214EC07E3F7CF5F");

            entity.Property(e => e.Cedula).HasMaxLength(20);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirmaAbogadosNombre).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Telefono).HasMaxLength(20);

            entity.HasOne(d => d.RegistroAsociacion).WithMany(p => p.ApoderadoLegal)
                .HasForeignKey(d => d.RegistroAsociacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Apoderado__Regis__32E0915F");
        });

        modelBuilder.Entity<DocumentoAdjunto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3214EC0701C12FBD");

            entity.Property(e => e.FechaSubida).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NombreOriginal).HasMaxLength(255);
            entity.Property(e => e.RutaArchivo).HasMaxLength(512);
            entity.Property(e => e.TipoDocumento).HasMaxLength(100);
            entity.Property(e => e.UsuarioId).HasMaxLength(450);

            entity.HasOne(d => d.RegistroAsociacion).WithMany(p => p.DocumentoAdjunto)
                .HasForeignKey(d => d.RegistroAsociacionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Documento__Regis__4CA06362");

            entity.HasOne(d => d.RegistroComite).WithMany(p => p.DocumentoAdjunto)
                .HasForeignKey(d => d.RegistroComiteId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Documento__Regis__4BAC3F29");
        });

        modelBuilder.Entity<JuntaInterventora>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__JuntaInt__3214EC07C21F07D7");

            entity.Property(e => e.Cedula).HasMaxLength(20);
            entity.Property(e => e.Nombre).HasMaxLength(255);

            entity.HasOne(d => d.RegistroComite).WithMany(p => p.JuntaInterventora)
                .HasForeignKey(d => d.RegistroComiteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__JuntaInte__Regis__2B3F6F97");
        });

        modelBuilder.Entity<MiembroComite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MiembroC__3214EC073525266B");

            entity.Property(e => e.Cargo).HasMaxLength(50);
            entity.Property(e => e.Cedula).HasMaxLength(20);
            entity.Property(e => e.Nombre).HasMaxLength(255);

            entity.HasOne(d => d.RegistroComite).WithMany(p => p.MiembroComite)
                .HasForeignKey(d => d.RegistroComiteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MiembroCo__Regis__286302EC");
        });

        modelBuilder.Entity<RegistroAsociaciones>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Registro__3214EC072AE40BF2");

            entity.Property(e => e.ActividadSalud).HasMaxLength(255);
            entity.Property(e => e.Asociacion).HasMaxLength(255);
        });

        modelBuilder.Entity<RegistroComite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Registro__3214EC07D0EAD7B0");

            entity.Property(e => e.ComiteSalud).HasMaxLength(255);
            entity.Property(e => e.Comunidad).HasMaxLength(255);
            entity.Property(e => e.Corregimiento).HasMaxLength(255);
            entity.Property(e => e.Distrito).HasMaxLength(255);
            entity.Property(e => e.Provincia).HasMaxLength(255);
            entity.Property(e => e.RegionSalud).HasMaxLength(255);
            entity.Property(e => e.TipoTramite).HasMaxLength(50);
        });

        modelBuilder.Entity<RepresentanteLegal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Represen__3214EC078D7CB979");

            entity.Property(e => e.Cargo).HasMaxLength(100);
            entity.Property(e => e.Cedula).HasMaxLength(20);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Telefono).HasMaxLength(20);

            entity.HasOne(d => d.RegistroAsociacion).WithMany(p => p.RepresentanteLegal)
                .HasForeignKey(d => d.RegistroAsociacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Represent__Regis__300424B4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
