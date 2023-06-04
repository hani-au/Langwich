using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Models
{
    public partial class chaniprojectContext : DbContext
    {
        public chaniprojectContext()
        {
        }

        public chaniprojectContext(DbContextOptions<chaniprojectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblDataForPlacement> TblDataForPlacement { get; set; }
        public virtual DbSet<TblDomains> TblDomains { get; set; }
        public virtual DbSet<TblLanguages> TblLanguages { get; set; }
        public virtual DbSet<TblLevelOfKnowledge> TblLevelOfKnowledge { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=ELI7-SQL\\SQL13;Initial Catalog=chaniproject;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblDataForPlacement>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__tmp_ms_x__357D4CF8F9777604");

                entity.ToTable("tbl_Data_for_placement");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.CodeLanguages).HasColumnName("code_Languages");

                entity.Property(e => e.FriendId).HasColumnName("FriendID");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.TheLevel).HasColumnName("the_level");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.CodeLanguagesNavigation)
                    .WithMany(p => p.TblDataForPlacement)
                    .HasForeignKey(d => d.CodeLanguages)
                    .HasConstraintName("FK__tbl_Data___code___5DCAEF64");

                entity.HasOne(d => d.NameNavigation)
                    .WithMany(p => p.TblDataForPlacement)
                    .HasForeignKey(d => d.Name)
                    .HasConstraintName("FK__tbl_Data_f__name__5FB337D6");

                entity.HasOne(d => d.TheLevelNavigation)
                    .WithMany(p => p.TblDataForPlacement)
                    .HasForeignKey(d => d.TheLevel)
                    .HasConstraintName("FK__tbl_Data___the_l__5EBF139D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblDataForPlacement)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Data___userI__5CD6CB2B");
            });

            modelBuilder.Entity<TblDomains>(entity =>
            {
                entity.ToTable("tbl_domains");

                entity.HasIndex(e => e.Id)
                    .HasName("UQ__tbl_doma__3213E83E85AAF6EE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(15)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblLanguages>(entity =>
            {
                entity.HasKey(e => e.CodeLanguages);

                entity.ToTable("tbl_Languages");

                entity.Property(e => e.CodeLanguages).HasColumnName("code_Languages");

                entity.Property(e => e.NameLanguages)
                    .HasColumnName("name_Languages")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblLevelOfKnowledge>(entity =>
            {
                entity.ToTable("tbl_Level_of_knowledge");

                entity.HasIndex(e => e.Id)
                    .HasName("UQ__tbl_Leve__3213E83E3FF3BFE4")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TheLevel)
                    .HasColumnName("the_level")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__tbl_user__1788CCAC6BE9218E");

                entity.ToTable("tbl_user");

                entity.HasIndex(e => e.UserId)
                    .HasName("UQ__tbl_user__1788CCAD4ADBB127")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CellphoneNumber)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CountryOfResidence)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.LineOfBusiness)
                    .HasColumnName("Line_of_Business")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
