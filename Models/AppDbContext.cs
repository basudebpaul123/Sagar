﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Lost_and_Found.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Claim> Claims { get; set; }
        public virtual DbSet<Founditem> Founditems { get; set; }
        public virtual DbSet<Lostitem> Lostitems { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserClaim> UserClaims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=WIN-FAPD9VNV3T5\\SQLEXPRESS;Initial Catalog=lostandfound;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admins");

                entity.Property(e => e.AdminId).HasColumnName("adminID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Contact).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("lastName");

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<Claim>(entity =>
            {
                entity.ToTable("claim");

                entity.Property(e => e.ClaimId).HasColumnName("claimID");

                entity.Property(e => e.ItemId).HasColumnName("itemID");

                entity.Property(e => e.UserId).HasColumnName("userID");
            });

            modelBuilder.Entity<Founditem>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.ToTable("founditems");

                entity.Property(e => e.ItemId).HasColumnName("itemID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.FoundArea)
                    .HasMaxLength(50)
                    .HasColumnName("foundArea");

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.ItemCategory)
                    .HasMaxLength(50)
                    .HasColumnName("itemCategory");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(50)
                    .HasColumnName("itemName");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Founditems)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_founditems_Users");
            });

            modelBuilder.Entity<Lostitem>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.ToTable("lostitems");

                entity.Property(e => e.ItemId).HasColumnName("itemID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.ItemCategory)
                    .HasMaxLength(50)
                    .HasColumnName("itemCategory");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(50)
                    .HasColumnName("itemName");

                entity.Property(e => e.LostArea)
                    .HasMaxLength(50)
                    .HasColumnName("lostArea");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Lostitems)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_lostitems_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Contact).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("lastName");

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<UserClaim>(entity =>
            {
                entity.ToTable("user_claim");

                entity.Property(e => e.UserClaimId).HasColumnName("user_claimID");

                entity.Property(e => e.ClaimId).HasColumnName("claimID");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Claim)
                    .WithMany(p => p.UserClaims)
                    .HasForeignKey(d => d.ClaimId)
                    .HasConstraintName("FK_user_claim_claim");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_user_claim_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
