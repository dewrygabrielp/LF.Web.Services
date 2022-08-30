using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LF.Web.Services.Models
{
    public partial class LiveFlowingContext : DbContext
    {
        public LiveFlowingContext()
        {
        }

        public LiveFlowingContext(DbContextOptions<LiveFlowingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PersonModel> PersonModel { get; set; }
        public virtual DbSet<UserModel> UserModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:lf-serverstorage.database.windows.net,1433;Initial Catalog=LiveFlowing;Persist Security Info=False;User ID=Dewry;Password=Itla#809;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonModel>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("PK__PersonMo__543848DFDF1ACA63");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.AgeField).HasColumnName("age_field");

                entity.Property(e => e.NameField)
                    .IsRequired()
                    .HasColumnName("name_field")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserMode__B9BE370FA8C711E0");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.AgeField).HasColumnName("age_field");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EmailField)
                    .IsRequired()
                    .HasColumnName("email_field")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NameField)
                    .IsRequired()
                    .HasColumnName("name_field")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordField)
                    .IsRequired()
                    .HasColumnName("password_field")
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
