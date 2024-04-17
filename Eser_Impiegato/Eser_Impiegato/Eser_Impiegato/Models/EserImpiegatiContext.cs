using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Eser_Impiegato.Models;

public partial class EserImpiegatiContext : DbContext
{
    public EserImpiegatiContext()
    {
    }

    public EserImpiegatiContext(DbContextOptions<EserImpiegatiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CittaResidenza> CittaResidenzas { get; set; }

    public virtual DbSet<Impiegato> Impiegatos { get; set; }

    public virtual DbSet<ProvinciaResidenza> ProvinciaResidenzas { get; set; }

    public virtual DbSet<Reparto> Repartos { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=ACADEMY2024-03\\SQLEXPRESS;Database=Eser_Impiegati;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CittaResidenza>(entity =>
        {
            entity.HasKey(e => e.CittaResidenzaId).HasName("PK__Citta_re__3A180AB0858DDBEF");

            entity.ToTable("Citta_residenza");

            entity.Property(e => e.CittaResidenzaId).HasColumnName("citta_residenzaID");
            entity.Property(e => e.NomeCitta)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome_citta");
            entity.Property(e => e.ProvinciaRif).HasColumnName("provinciaRIF");

            entity.HasOne(d => d.ProvinciaRifNavigation).WithMany(p => p.CittaResidenzas)
                .HasForeignKey(d => d.ProvinciaRif)
                .HasConstraintName("FK__Citta_res__provi__75A278F5");
        });

        modelBuilder.Entity<Impiegato>(entity =>
        {
            entity.HasKey(e => e.ImpiegatoId).HasName("PK__Impiegat__C7A20D323860711A");

            entity.ToTable("Impiegato");

            entity.HasIndex(e => e.Matricola, "UQ__Impiegat__2C2751BA01162E65").IsUnique();

            entity.Property(e => e.ImpiegatoId).HasColumnName("impiegatoId");
            entity.Property(e => e.CittaResidenza)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("citta_residenza");
            entity.Property(e => e.Cognome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("cognome");
            entity.Property(e => e.DataNascita).HasColumnName("data_nascita");
            entity.Property(e => e.IndirizzoResidenza)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("indirizzo_residenza");
            entity.Property(e => e.Matricola)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("matricola");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.ProvinciaResidenza)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("provincia_residenza");
            entity.Property(e => e.Reparto)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("reparto");
            entity.Property(e => e.Ruolo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("ruolo");
        });

        modelBuilder.Entity<ProvinciaResidenza>(entity =>
        {
            entity.HasKey(e => e.ProvinciaResidenzaId).HasName("PK__Provinci__C7E2EC3DAC490AC4");

            entity.ToTable("Provincia_residenza");

            entity.Property(e => e.ProvinciaResidenzaId).HasColumnName("provincia_residenzaID");
            entity.Property(e => e.NomeProvincia)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome_provincia");
            entity.Property(e => e.Sigla)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("sigla");
        });

        modelBuilder.Entity<Reparto>(entity =>
        {
            entity.HasKey(e => e.RepartoId).HasName("PK__Reparto__100BEE1580D565DE");

            entity.ToTable("Reparto");

            entity.Property(e => e.RepartoId).HasColumnName("RepartoID");
            entity.Property(e => e.NomeReparto)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome_reparto");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
