using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ACUDallasAdminPortal.AdminModels
{
    public partial class ACUDallasAdminContext : DbContext
    {
        public ACUDallasAdminContext()
        {
        }

        public ACUDallasAdminContext(DbContextOptions<ACUDallasAdminContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContactTypes> ContactTypes { get; set; }
        public virtual DbSet<FacultyChairs> FacultyChairs { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<PeopleEducation> PeopleEducation { get; set; }
        public virtual DbSet<PeopleTypes> PeopleTypes { get; set; }
        public virtual DbSet<PersonalContacts> PersonalContacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=desktop-lvkbeqg;Database=ACUDallasAdmin;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactTypes>(entity =>
            {
                entity.HasKey(e => e.ContactTypeId);

                entity.Property(e => e.ContactTypeId).HasColumnName("ContactTypeID");

                entity.Property(e => e.ContactType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FacultyChairs>(entity =>
            {
                entity.HasKey(e => e.FacultyChairId);

                entity.Property(e => e.FacultyChairId).HasColumnName("FacultyChairID");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.ResearchFocus)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.FacultyChairs)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacultyChairs_People");
            });

            modelBuilder.Entity<People>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.Title)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.PeopleType)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.PeopleTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_People_PeopleTypes");
            });

            modelBuilder.Entity<PeopleEducation>(entity =>
            {
                entity.Property(e => e.PeopleEducationId).HasColumnName("PeopleEducationID");

                entity.Property(e => e.Degree)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Discipline)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.GraduationDate).HasColumnType("date");

                entity.Property(e => e.Institution)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PeopleEducation)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PeopleEducation_People");
            });

            modelBuilder.Entity<PeopleTypes>(entity =>
            {
                entity.HasKey(e => e.PeopleTypeId);

                entity.Property(e => e.PeopleTypeId).HasColumnName("PeopleTypeID");

                entity.Property(e => e.PeopleTypeDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PersonalContacts>(entity =>
            {
                entity.HasKey(e => e.PeopleContactId);

                entity.Property(e => e.PeopleContactId).HasColumnName("PeopleContactID");

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContactTypeId).HasColumnName("ContactTypeID");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.HasOne(d => d.ContactType)
                    .WithMany(p => p.PersonalContacts)
                    .HasForeignKey(d => d.ContactTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonalContacts_ContactTypes");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonalContacts)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonalContacts_People");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
