using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Eser_Merc.Models;

public partial class TaskMercolediContext : DbContext
{
    public TaskMercolediContext()
    {
    }

    public TaskMercolediContext(DbContextOptions<TaskMercolediContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Ordine> Ordines { get; set; }

    public virtual DbSet<OrdineProdotto> OrdineProdottos { get; set; }

    public virtual DbSet<Prodotto> Prodottos { get; set; }

    public virtual DbSet<Utente> Utentes { get; set; }

    public virtual DbSet<Variazione> Variaziones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ACADEMY2024-03\\SQLEXPRESS;Database=task_mercoledi;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__6378C0206BC2B582");

            entity.Property(e => e.CategoriaId).HasColumnName("categoriaID");
            entity.Property(e => e.Deleted)
                .HasColumnType("datetime")
                .HasColumnName("deleted");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Ordine>(entity =>
        {
            entity.HasKey(e => e.OrdineId).HasName("PK__Ordine__8F87D0E5510B9BEE");

            entity.ToTable("Ordine");

            entity.Property(e => e.OrdineId).HasColumnName("ordineID");
            entity.Property(e => e.DataOrd)
                .HasColumnType("datetime")
                .HasColumnName("dataOrd");
            entity.Property(e => e.Deleted)
                .HasColumnType("datetime")
                .HasColumnName("deleted");
            entity.Property(e => e.QuantitaOrd).HasColumnName("quantitaOrd");
            entity.Property(e => e.UtenteRif).HasColumnName("utenteRIF");

            entity.HasOne(d => d.UtenteRifNavigation).WithMany(p => p.Ordines)
                .HasForeignKey(d => d.UtenteRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ordine__utenteRI__797309D9");
        });

        modelBuilder.Entity<OrdineProdotto>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Ordine_Prodotto");

            entity.Property(e => e.ProdottoRif).HasColumnName("prodottoRIF");
            entity.Property(e => e.UtenteRif).HasColumnName("utenteRIF");
            entity.Property(e => e.VariazioneRif).HasColumnName("variazioneRIF");

            entity.HasOne(d => d.ProdottoRifNavigation).WithMany()
                .HasForeignKey(d => d.ProdottoRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ordine_Pr__prodo__7B5B524B");

            entity.HasOne(d => d.UtenteRifNavigation).WithMany()
                .HasForeignKey(d => d.UtenteRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ordine_Pr__utent__7C4F7684");

            entity.HasOne(d => d.VariazioneRifNavigation).WithMany()
                .HasForeignKey(d => d.VariazioneRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ordine_Pr__varia__7D439ABD");
        });

        modelBuilder.Entity<Prodotto>(entity =>
        {
            entity.HasKey(e => e.ProdottoId).HasName("PK__Prodotto__3AB65975D1C3CA28");

            entity.ToTable("Prodotto");

            entity.Property(e => e.ProdottoId).HasColumnName("prodottoID");
            entity.Property(e => e.CategoriaRif).HasColumnName("categoriaRIF");
            entity.Property(e => e.Deleted)
                .HasColumnType("datetime")
                .HasColumnName("deleted");
            entity.Property(e => e.Descrizione)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("descrizione");
            entity.Property(e => e.Image)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.Marca)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("marca");

            entity.HasOne(d => d.CategoriaRifNavigation).WithMany(p => p.Prodottos)
                .HasForeignKey(d => d.CategoriaRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prodotto__catego__72C60C4A");
        });

        modelBuilder.Entity<Utente>(entity =>
        {
            entity.HasKey(e => e.UtenteId).HasName("PK__Utente__CA5C22531907A0CE");

            entity.ToTable("Utente");

            entity.HasIndex(e => new { e.Email, e.PasswordUtente }, "UQ__Utente__CB3813C3860F486C").IsUnique();

            entity.Property(e => e.UtenteId).HasColumnName("utenteID");
            entity.Property(e => e.Deleted)
                .HasColumnType("datetime")
                .HasColumnName("deleted");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nominativo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nominativo");
            entity.Property(e => e.PasswordUtente)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("passwordUtente");
        });

        modelBuilder.Entity<Variazione>(entity =>
        {
            entity.HasKey(e => e.VariazioneId).HasName("PK__Variazio__54F6EA5A9F1DABBC");

            entity.ToTable("Variazione");

            entity.Property(e => e.VariazioneId).HasColumnName("variazioneID");
            entity.Property(e => e.Colore)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("colore");
            entity.Property(e => e.DataFinScon)
                .HasColumnType("datetime")
                .HasColumnName("dataFinScon");
            entity.Property(e => e.DataInScon)
                .HasColumnType("datetime")
                .HasColumnName("dataInScon");
            entity.Property(e => e.Deleted)
                .HasColumnType("datetime")
                .HasColumnName("deleted");
            entity.Property(e => e.IsDisponibile)
                .HasDefaultValue(false)
                .HasColumnName("isDisponibile");
            entity.Property(e => e.Prezzo)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("prezzo");
            entity.Property(e => e.PrezzoOf)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("prezzoOF");
            entity.Property(e => e.ProdottoRif).HasColumnName("prodottoRIF");
            entity.Property(e => e.QuantitaStock).HasColumnName("quantitaStock");
            entity.Property(e => e.Taglia)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("taglia");

            entity.HasOne(d => d.ProdottoRifNavigation).WithMany(p => p.Variaziones)
                .HasForeignKey(d => d.ProdottoRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Variazion__prodo__76969D2E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
