using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace brgWebApi.Models
{
    public partial class brgDatabaseContext : DbContext
    {
        public brgDatabaseContext()
        {
        }

        public brgDatabaseContext(DbContextOptions<brgDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Colaborador> Colaborador { get; set; }
        public virtual DbSet<Habilidades> Habilidades { get; set; }
        public virtual DbSet<Trilha> Trilha { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-1D0TA2VC\\SQLEXPRESS01;Database=brgDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colaborador>(entity =>
            {
                entity.HasKey(e => e.IdColaborador)
                    .HasName("pk_ID_colaborador");

                entity.Property(e => e.IdColaborador)
                    .HasColumnName("ID_colaborador")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cargo)
                    .HasColumnName("cargo")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Departamento)
                    .HasColumnName("departamento")
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Habilidades>(entity =>
            {
                entity.HasKey(e => e.IdHabilidades)
                    .HasName("pk_ID_habilidades");

                entity.Property(e => e.IdHabilidades)
                    .HasColumnName("ID_habilidades")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Trilha>(entity =>
            {
                entity.HasKey(e => e.IdTrilha)
                    .HasName("pk_ID_trilha");

                entity.Property(e => e.IdTrilha)
                    .HasColumnName("ID_trilha")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataTrilha)
                    .HasColumnName("Data_trilha")
                    .HasColumnType("date");

                entity.Property(e => e.IdColaborador).HasColumnName("ID_colaborador");

                entity.Property(e => e.IdHabilidades).HasColumnName("ID_habilidades");

                entity.HasOne(d => d.IdColaboradorNavigation)
                    .WithMany(p => p.Trilha)
                    .HasForeignKey(d => d.IdColaborador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ID_colaborador");

                entity.HasOne(d => d.IdHabilidadesNavigation)
                    .WithMany(p => p.Trilha)
                    .HasForeignKey(d => d.IdHabilidades)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ID_habilidade");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
