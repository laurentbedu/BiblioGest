using Microsoft.EntityFrameworkCore;

namespace BiblioDb.Entities
{
    public partial class BiblioDbContext : DbContext
    {
        public BiblioDbContext()
        {
        }

        public BiblioDbContext(DbContextOptions<BiblioDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Abonne> Abonnes { get; set; } = null!;
        public virtual DbSet<Auteur> Auteurs { get; set; } = null!;
        public virtual DbSet<Categorie> Categories { get; set; } = null!;
        public virtual DbSet<Editeur> Editeurs { get; set; } = null!;
        public virtual DbSet<Emprunt> Emprunts { get; set; } = null!;
        public virtual DbSet<Exemplaire> Exemplaires { get; set; } = null!;
        public virtual DbSet<Livre> Livres { get; set; } = null!;
        public virtual DbSet<Motcle> Motcles { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<Theme> Themes { get; set; } = null!;
        public virtual DbSet<Usure> Usures { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\;Database=biblio_db;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Abonne>(entity =>
            {
                entity.HasKey(e => e.IdAbonne)
                    .HasName("PK__abonne__CE27AA549C26F6AB");

                entity.HasOne(d => d.IdCategorieNavigation)
                    .WithMany(p => p.Abonnes)
                    .HasForeignKey(d => d.IdCategorie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__abonne__Id_categ__37A5467C");
            });

            modelBuilder.Entity<Auteur>(entity =>
            {
                entity.HasKey(e => e.IdAuteur)
                    .HasName("PK__auteur__DEA78B8A3215BF76");
            });

            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.HasKey(e => e.IdCategorie)
                    .HasName("PK__categori__4A033A9F7DB13E86");
            });

            modelBuilder.Entity<Editeur>(entity =>
            {
                entity.HasKey(e => e.IdEditeur)
                    .HasName("PK__editeur__D9D94FC07B85A383");
            });

            modelBuilder.Entity<Emprunt>(entity =>
            {
                entity.HasKey(e => e.IdEmprunt)
                    .HasName("PK__emprunt__A34A5334D5C30763");

                entity.HasOne(d => d.IdAbonneNavigation)
                    .WithMany(p => p.Emprunts)
                    .HasForeignKey(d => d.IdAbonne)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__emprunt__Id_abon__403A8C7D");

                entity.HasOne(d => d.IdExemplaireNavigation)
                    .WithMany(p => p.Emprunts)
                    .HasForeignKey(d => d.IdExemplaire)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__emprunt__Id_exem__3F466844");
            });

            modelBuilder.Entity<Exemplaire>(entity =>
            {
                entity.HasKey(e => e.IdExemplaire)
                    .HasName("PK__exemplai__A3794F0DE7419EAD");

                entity.HasOne(d => d.IdEditeurNavigation)
                    .WithMany(p => p.Exemplaires)
                    .HasForeignKey(d => d.IdEditeur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__exemplair__Id_ed__31EC6D26");

                entity.HasOne(d => d.IdLivreNavigation)
                    .WithMany(p => p.Exemplaires)
                    .HasForeignKey(d => d.IdLivre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__exemplair__Id_li__33D4B598");

                entity.HasOne(d => d.IdUsureNavigation)
                    .WithMany(p => p.Exemplaires)
                    .HasForeignKey(d => d.IdUsure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__exemplair__Id_us__32E0915F");
            });

            modelBuilder.Entity<Livre>(entity =>
            {
                entity.HasKey(e => e.IdLivre)
                    .HasName("PK__livre__C557D88FC6566493");

                entity.HasMany(d => d.IdAuteurs)
                    .WithMany(p => p.IdLivres)
                    .UsingEntity<Dictionary<string, object>>(
                        "AuteurLivre",
                        l => l.HasOne<Auteur>().WithMany().HasForeignKey("IdAuteur").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__auteur_li__Id_au__440B1D61"),
                        r => r.HasOne<Livre>().WithMany().HasForeignKey("IdLivre").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__auteur_li__Id_li__4316F928"),
                        j =>
                        {
                            j.HasKey("IdLivre", "IdAuteur").HasName("PK__auteur_l__78BDA0378E7DC21C");

                            j.ToTable("auteur_livre");

                            j.IndexerProperty<int>("IdLivre").HasColumnName("Id_livre");

                            j.IndexerProperty<int>("IdAuteur").HasColumnName("Id_auteur");
                        });

                entity.HasMany(d => d.IdMotcles)
                    .WithMany(p => p.IdLivres)
                    .UsingEntity<Dictionary<string, object>>(
                        "LivreMotcle",
                        l => l.HasOne<Motcle>().WithMany().HasForeignKey("IdMotcle").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__livre_mot__Id_mo__47DBAE45"),
                        r => r.HasOne<Livre>().WithMany().HasForeignKey("IdLivre").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__livre_mot__Id_li__46E78A0C"),
                        j =>
                        {
                            j.HasKey("IdLivre", "IdMotcle").HasName("PK__livre_mo__909EF3516E64BA11");

                            j.ToTable("livre_motcle");

                            j.IndexerProperty<int>("IdLivre").HasColumnName("Id_livre");

                            j.IndexerProperty<int>("IdMotcle").HasColumnName("Id_motcle");
                        });

                entity.HasMany(d => d.IdThemes)
                    .WithMany(p => p.IdLivres)
                    .UsingEntity<Dictionary<string, object>>(
                        "LivreTheme",
                        l => l.HasOne<Theme>().WithMany().HasForeignKey("IdTheme").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__livre_the__Id_th__4BAC3F29"),
                        r => r.HasOne<Livre>().WithMany().HasForeignKey("IdLivre").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__livre_the__Id_li__4AB81AF0"),
                        j =>
                        {
                            j.HasKey("IdLivre", "IdTheme").HasName("PK__livre_th__0123E5909F849FE5");

                            j.ToTable("livre_theme");

                            j.IndexerProperty<int>("IdLivre").HasColumnName("Id_livre");

                            j.IndexerProperty<int>("IdTheme").HasColumnName("Id_theme");
                        });
            });

            modelBuilder.Entity<Motcle>(entity =>
            {
                entity.HasKey(e => e.IdMotcle)
                    .HasName("PK__motcle__5C92BDE47ED06D2E");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.IdReservation)
                    .HasName("PK__reservat__0DE64F819B6BC33F");

                entity.HasOne(d => d.IdAbonneNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.IdAbonne)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__reservati__Id_ab__3C69FB99");

                entity.HasOne(d => d.IdEditeurNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.IdEditeur)
                    .HasConstraintName("FK__reservati__Id_ed__3A81B327");

                entity.HasOne(d => d.IdLivreNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.IdLivre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__reservati__Id_li__3B75D760");
            });

            modelBuilder.Entity<Theme>(entity =>
            {
                entity.HasKey(e => e.IdTheme)
                    .HasName("PK__theme__4743D1FD2B1B5195");
            });

            modelBuilder.Entity<Usure>(entity =>
            {
                entity.HasKey(e => e.IdUsure)
                    .HasName("PK__usure__9C14644E27848909");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
