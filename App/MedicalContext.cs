using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace App.Models
{
    public partial class MedicalContext : DbContext
    {
        public MedicalContext()
        {
        }

        public MedicalContext(DbContextOptions<MedicalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adresse> Adresse { get; set; }
        public virtual DbSet<Categorie> Categorie { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Fiche> Fiche { get; set; }
        public virtual DbSet<Materiel> Materiel { get; set; }
        public virtual DbSet<MaterielHasFiche> MaterielHasFiche { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=root;database=medical", x => x.ServerVersion("8.0.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adresse>(entity =>
            {
                entity.ToTable("adresse");

                entity.HasIndex(e => e.ClientId)
                    .HasName("fk_adresse_client1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.CodePostal)
                    .HasColumnName("code_postal")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Rue)
                    .HasColumnName("rue")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Ville)
                    .HasColumnName("ville")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Adresse)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_adresse_client1");
            });

            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.ToTable("categorie");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Libellé)
                    .HasColumnName("libellé")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nom)
                    .HasColumnName("nom")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Prenom)
                    .HasColumnName("prenom")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Telephone)
                    .HasColumnName("telephone")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Fiche>(entity =>
            {
                entity.ToTable("fiche");

                entity.HasIndex(e => e.ClientId)
                    .HasName("fk_panier_client1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Fiche)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_panier_client1");
            });

            modelBuilder.Entity<Materiel>(entity =>
            {
                entity.ToTable("materiel");

                entity.HasIndex(e => e.CategorieId)
                    .HasName("fk_materiel_categorie_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategorieId).HasColumnName("categorie_id");

                entity.Property(e => e.DateAchat)
                    .HasColumnName("date_achat")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PrixLoc).HasColumnName("prix_loc");

                entity.Property(e => e.Reference)
                    .HasColumnName("reference")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.Categorie)
                    .WithMany(p => p.Materiel)
                    .HasForeignKey(d => d.CategorieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_materiel_categorie");
            });

            modelBuilder.Entity<MaterielHasFiche>(entity =>
            {
                entity.ToTable("materiel_has_fiche");

                entity.HasIndex(e => e.FicheId)
                    .HasName("fk_materiel_has_fiche_fiche1_idx");

                entity.HasIndex(e => e.MaterielId)
                    .HasName("fk_materiel_has_fiche_materiel1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateDebut)
                    .HasColumnName("date_debut")
                    .HasColumnType("date");

                entity.Property(e => e.DateFin)
                    .HasColumnName("date_fin")
                    .HasColumnType("date");

                entity.Property(e => e.FicheId).HasColumnName("fiche_id");

                entity.Property(e => e.MaterielId).HasColumnName("materiel_id");

                entity.HasOne(d => d.Fiche)
                    .WithMany(p => p.MaterielHasFiche)
                    .HasForeignKey(d => d.FicheId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_materiel_has_fiche_fiche1");

                entity.HasOne(d => d.Materiel)
                    .WithMany(p => p.MaterielHasFiche)
                    .HasForeignKey(d => d.MaterielId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_materiel_has_fiche_materiel1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
