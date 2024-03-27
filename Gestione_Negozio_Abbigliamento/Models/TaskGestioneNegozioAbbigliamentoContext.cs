using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Gestione_Negozio_Abbigliamento.Models;

public partial class TaskGestioneNegozioAbbigliamentoContext : DbContext
{
    public TaskGestioneNegozioAbbigliamentoContext()
    {
    }

    public TaskGestioneNegozioAbbigliamentoContext(DbContextOptions<TaskGestioneNegozioAbbigliamentoContext> options)
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
        => optionsBuilder.UseSqlServer("Server = ACADEMY2022-19\\SQLEXPRESS;Database=Task_Gestione_NegozioAbbigliamento;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__6378C020AFAC05EE");

            entity.Property(e => e.CategoriaId).HasColumnName("categoriaID");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Ordine>(entity =>
        {
            entity.HasKey(e => e.OrdineId).HasName("PK__Ordine__8F87D0E5076C0271");

            entity.ToTable("Ordine");

            entity.Property(e => e.OrdineId).HasColumnName("ordineID");
            entity.Property(e => e.DataOrdine).HasColumnName("data_ordine");
            entity.Property(e => e.Stato)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("stato");
            entity.Property(e => e.UtenteRif).HasColumnName("utenteRIF");

            entity.HasOne(d => d.UtenteRifNavigation).WithMany(p => p.Ordines)
                .HasForeignKey(d => d.UtenteRif)
                .HasConstraintName("FK__Ordine__utenteRI__3B75D760");
        });

        modelBuilder.Entity<OrdineProdotto>(entity =>
        {
            entity.HasKey(e => new { e.OrdineRif, e.ProdottoRif, e.VariazioneRif }).HasName("PK__Ordine_P__7C981825713D6CEF");

            entity.ToTable("Ordine_Prodotto");

            entity.Property(e => e.OrdineRif).HasColumnName("ordineRIF");
            entity.Property(e => e.ProdottoRif).HasColumnName("prodottoRIF");
            entity.Property(e => e.VariazioneRif).HasColumnName("variazioneRIF");
            entity.Property(e => e.Quantità).HasColumnName("quantità");

            entity.HasOne(d => d.OrdineRifNavigation).WithMany(p => p.OrdineProdottos)
                .HasForeignKey(d => d.OrdineRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ordine_Pr__ordin__45F365D3");

            entity.HasOne(d => d.ProdottoRifNavigation).WithMany(p => p.OrdineProdottos)
                .HasForeignKey(d => d.ProdottoRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ordine_Pr__prodo__46E78A0C");

            entity.HasOne(d => d.VariazioneRifNavigation).WithMany(p => p.OrdineProdottos)
                .HasForeignKey(d => d.VariazioneRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ordine_Pr__varia__47DBAE45");
        });

        modelBuilder.Entity<Prodotto>(entity =>
        {
            entity.HasKey(e => e.ProdottoId).HasName("PK__Prodotto__3AB659756905A469");

            entity.ToTable("Prodotto");

            entity.Property(e => e.ProdottoId).HasColumnName("prodottoID");
            entity.Property(e => e.CategoriaRif).HasColumnName("categoriaRIF");
            entity.Property(e => e.Descrizione)
                .HasColumnType("text")
                .HasColumnName("descrizione");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");

            entity.HasOne(d => d.CategoriaRifNavigation).WithMany(p => p.Prodottos)
                .HasForeignKey(d => d.CategoriaRif)
                .HasConstraintName("FK__Prodotto__catego__403A8C7D");
        });

        modelBuilder.Entity<Utente>(entity =>
        {
            entity.HasKey(e => e.UtenteId).HasName("PK__Utente__CA5C22533E7529B4");

            entity.ToTable("Utente");

            entity.HasIndex(e => new { e.Email, e.Pass }, "UQ__Utente__435C6E078A1C929A").IsUnique();

            entity.Property(e => e.UtenteId).HasColumnName("utenteID");
            entity.Property(e => e.Cognome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("cognome");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Pass)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("pass");
        });

        modelBuilder.Entity<Variazione>(entity =>
        {
            entity.HasKey(e => e.VariazioneId).HasName("PK__Variazio__54F6EA5A6BE48D1E");

            entity.ToTable("Variazione");

            entity.Property(e => e.VariazioneId).HasColumnName("variazioneID");
            entity.Property(e => e.Colore)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("colore");
            entity.Property(e => e.DataFineOfferta).HasColumnName("data_fine_offerta");
            entity.Property(e => e.DataInizioOfferta).HasColumnName("data_inizio_offerta");
            entity.Property(e => e.PrezzoOfferta)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("prezzo_offerta");
            entity.Property(e => e.PrezzoPieno)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("prezzo_pieno");
            entity.Property(e => e.ProdottoRif).HasColumnName("prodottoRIF");
            entity.Property(e => e.Quantità).HasColumnName("quantità");
            entity.Property(e => e.Taglia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("taglia");

            entity.HasOne(d => d.ProdottoRifNavigation).WithMany(p => p.Variaziones)
                .HasForeignKey(d => d.ProdottoRif)
                .HasConstraintName("FK__Variazion__prodo__4316F928");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
