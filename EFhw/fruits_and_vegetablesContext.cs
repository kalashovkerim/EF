using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFhw
{
    public partial class fruits_and_vegetablesContext : DbContext
    {
        public fruits_and_vegetablesContext()
        {
        }

        public fruits_and_vegetablesContext(DbContextOptions<fruits_and_vegetablesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Info> Infos { get; set; } = null!;
        public virtual DbSet<Info2> Info2s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-JDQ2UQC;Initial Catalog=fruits_and_vegetables;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Info>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Info");

                entity.Property(e => e.Color).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Type).HasMaxLength(20);
            });

            modelBuilder.Entity<Info2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Info2");

                entity.Property(e => e.City).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
