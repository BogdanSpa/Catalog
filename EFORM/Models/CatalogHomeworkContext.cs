using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFORM.Models
{
    public partial class CatalogHomeworkContext : DbContext
    {
        public CatalogHomeworkContext()
        {
        }

        public CatalogHomeworkContext(DbContextOptions<CatalogHomeworkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Catalog> Catalogs { get; set; } = null!;
        public virtual DbSet<Note> Notes { get; set; } = null!;
        public virtual DbSet<NoteList> NoteLists { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<SubjectCatalog> SubjectCatalogs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CatalogHomework;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalog>(entity =>
            {
                entity.Property(e => e.Clasa)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.HasOne(d => d.Materie)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.MaterieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notes__MaterieId__2A4B4B5E");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notes__StudentId__403A8C7D");
            });

            modelBuilder.Entity<NoteList>(entity =>
            {
                entity.ToTable("NoteList");

                entity.HasOne(d => d.Catalog)
                    .WithMany(p => p.NoteLists)
                    .HasForeignKey(d => d.CatalogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NoteList__Catalo__3D5E1FD2");

                entity.HasOne(d => d.Nota)
                    .WithMany(p => p.NoteLists)
                    .HasForeignKey(d => d.NotaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NoteList__NotaId__37A5467C");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Nume)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prenume)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Nume)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubjectCatalog>(entity =>
            {
                entity.ToTable("SubjectCatalog");

                entity.HasOne(d => d.Catalog)
                    .WithMany(p => p.SubjectCatalogs)
                    .HasForeignKey(d => d.CatalogId)
                    .HasConstraintName("FK__SubjectCa__Catal__49C3F6B7");

                entity.HasOne(d => d.Materie)
                    .WithMany(p => p.SubjectCatalogs)
                    .HasForeignKey(d => d.MaterieId)
                    .HasConstraintName("FK__SubjectCa__Mater__48CFD27E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
