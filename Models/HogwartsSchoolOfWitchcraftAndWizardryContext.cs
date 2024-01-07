using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HogwartsSchool.Models;

public partial class HogwartsSchoolOfWitchcraftAndWizardryContext : DbContext
{
    public HogwartsSchoolOfWitchcraftAndWizardryContext()
    {
    }

    public HogwartsSchoolOfWitchcraftAndWizardryContext(DbContextOptions<HogwartsSchoolOfWitchcraftAndWizardryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Owl> Owls { get; set; }

    public virtual DbSet<Profession> Professions { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=HogwartsSchoolOfWitchcraftAndWizardry;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.ToTable("Class");

            entity.Property(e => e.ClassId)
                .ValueGeneratedNever()
                .HasColumnName("ClassID");
            entity.Property(e => e.ClassName).HasMaxLength(50);
            entity.Property(e => e.FkheadOfHouseId).HasColumnName("FKHeadOfHouseID");

            entity.HasOne(d => d.FkheadOfHouse).WithMany(p => p.Classes)
                .HasForeignKey(d => d.FkheadOfHouseId)
                .HasConstraintName("FK_Class_Staff");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("Course");

            entity.Property(e => e.CourseId)
                .ValueGeneratedNever()
                .HasColumnName("CourseID");
            entity.Property(e => e.CourseName).HasMaxLength(50);
            entity.Property(e => e.FkcourseCoordinatorId).HasColumnName("FKCourseCoordinatorID");

            entity.HasOne(d => d.FkcourseCoordinator).WithMany(p => p.Courses)
                .HasForeignKey(d => d.FkcourseCoordinatorId)
                .HasConstraintName("FK_Course_Staff");
        });

        modelBuilder.Entity<Owl>(entity =>
        {
            entity.ToTable("OWL");

            entity.Property(e => e.OwlId).HasColumnName("OwlID");
            entity.Property(e => e.FkcourseId).HasColumnName("FKCourseID");
            entity.Property(e => e.FkstudentId).HasColumnName("FKStudentID");

            entity.HasOne(d => d.Fkcourse).WithMany(p => p.Owls)
                .HasForeignKey(d => d.FkcourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enrolment_Course");

            entity.HasOne(d => d.Fkstudent).WithMany(p => p.Owls)
                .HasForeignKey(d => d.FkstudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enrolment_Students");
        });

        modelBuilder.Entity<Profession>(entity =>
        {
            entity.Property(e => e.ProfessionId)
                .ValueGeneratedNever()
                .HasColumnName("ProfessionID");
            entity.Property(e => e.Role)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK_Staff_1");

            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.FkprofessionId).HasColumnName("FKProfessionID");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Region)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Species)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Street).HasMaxLength(50);
            entity.Property(e => e.Town).HasMaxLength(50);

            entity.HasOne(d => d.Fkprofession).WithMany(p => p.Staff)
                .HasForeignKey(d => d.FkprofessionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Staff_Professions");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK_Students_1");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.FkclassId).HasColumnName("FKClassID");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PersonNumber)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Fkclass).WithMany(p => p.Students)
                .HasForeignKey(d => d.FkclassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_Class");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
