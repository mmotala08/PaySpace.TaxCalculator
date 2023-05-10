using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TaxCalculator.DataAccess.Entities
{
    public partial class TaxContext : DbContext
    {
        public TaxContext(DbContextOptions<TaxContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProgressiveTax> ProgressiveTax { get; set; }
        public virtual DbSet<TaxCalculationOutputs> TaxCalculationOutputs { get; set; }
        public virtual DbSet<TaxCalculationType> TaxCalculationType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgressiveTax>(entity =>
            {
                entity.Property(e => e.LowerBound).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Rate).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.UpperBound).HasColumnType("decimal(18, 6)");
            });

            modelBuilder.Entity<TaxCalculationOutputs>(entity =>
            {
                entity.HasKey(e => e.TaxCalculationOutputId);

                entity.Property(e => e.AnnualIncome).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.TaxValue).HasColumnType("decimal(18, 6)");
            });

            modelBuilder.Entity<TaxCalculationType>(entity =>
            {
                entity.HasKey(e => e.TaxTypeId);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
