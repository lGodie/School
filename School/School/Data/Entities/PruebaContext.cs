using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace School.Data.Entities
{
    public partial class PruebaContext : DbContext
    {
        public PruebaContext()
        {
        }

        public PruebaContext(DbContextOptions<PruebaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Enrollments> Enrollments { get; set; }
        public virtual DbSet<Qualification> Qualification { get; set; }
        public virtual DbSet<Students> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-ENU8D7B;Initial Catalog=Prueba;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.IdCourse)
                    .HasName("PK__Courses__8982E30966C83D12");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.Credits)
                    .HasColumnName("credits")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Enrollments>(entity =>
            {
                entity.HasKey(e => e.IdEnrollment)
                    .HasName("PK__Enrollme__59432236627B4144");

                entity.Property(e => e.IdEnrollment).HasColumnName("idEnrollment");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.IdStudent).HasColumnName("idStudent");
            });

            modelBuilder.Entity<Qualification>(entity =>
            {
                entity.HasKey(e => e.IdQualification)
                    .HasName("PK__Qualific__7549CFDB1DA3A5E7");

                entity.Property(e => e.IdQualification).HasColumnName("idQualification");

                entity.Property(e => e.IdCourseNote).HasColumnName("idCourseNote");

                entity.Property(e => e.IdStudentNote).HasColumnName("idStudentNote");

                entity.Property(e => e.Qualification1).HasColumnName("Qualification");

                entity.HasOne(d => d.IdCourseNoteNavigation)
                    .WithMany(p => p.QualificationIdCourseNoteNavigation)
                    .HasForeignKey(d => d.IdCourseNote)
                    .HasConstraintName("QualificationEnrollmentNota");

                entity.HasOne(d => d.IdStudentNoteNavigation)
                    .WithMany(p => p.QualificationIdStudentNoteNavigation)
                    .HasForeignKey(d => d.IdStudentNote)
                    .HasConstraintName("QualificationEnrollment");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.IdStudent)
                    .HasName("PK__Students__35B1F88AF74B13F6");

                entity.Property(e => e.IdStudent).HasColumnName("idStudent");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone).HasMaxLength(15);
            });
        }
    }
}
