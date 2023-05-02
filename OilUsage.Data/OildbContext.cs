using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OilUsage.Data.Entity;

namespace OilUsage.Data;

public partial class OildbContext : DbContext
{
    public OildbContext()
    {
    }

    public OildbContext(DbContextOptions<OildbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdditionalRecomendation> AdditionalRecomendations { get; set; }

    public virtual DbSet<Issue> Issues { get; set; }

    public virtual DbSet<Oil> Oils { get; set; }

    public virtual DbSet<Usage> Usages { get; set; }

    public virtual DbSet<UsageType> UsageTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=database-2.ckqufcaqegte.us-east-1.rds.amazonaws.com;port=3306;database=oildb;uid=;password=");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdditionalRecomendation>(entity =>
        {
            entity.HasKey(e => e.AdditionalRecomendationId).HasName("PRIMARY");

            entity.ToTable("AdditionalRecomendation");

            entity.HasIndex(e => e.AdditionalRecomendationId, "AdditionalRecomendationId_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IssueId, "FK_AdditionalRec_Issue_idx");

            entity.Property(e => e.Description).HasMaxLength(100);

            entity.HasOne(d => d.Issue).WithMany(p => p.AdditionalRecomendations)
                .HasForeignKey(d => d.IssueId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_AdditionalRec_Issue");
        });

        modelBuilder.Entity<Issue>(entity =>
        {
            entity.HasKey(e => e.IssueId).HasName("PRIMARY");

            entity.ToTable("Issue");

            entity.HasIndex(e => e.IssueId, "IssueId_UNIQUE").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Oil>(entity =>
        {
            entity.HasKey(e => e.OilId).HasName("PRIMARY");

            entity.ToTable("Oil");

            entity.HasIndex(e => e.OilId, "OilId_UNIQUE").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<Usage>(entity =>
        {
            entity.HasKey(e => e.UsageId).HasName("PRIMARY");

            entity.ToTable("Usage");

            entity.HasIndex(e => e.IssueId, "FK_Issue_Usage_idx");

            entity.HasIndex(e => e.OilId, "FK_Oil_Usage_idx");

            entity.HasIndex(e => e.UsageTypeId, "FK_Usage_UsageType_idx");

            entity.HasIndex(e => e.UsageId, "UsageId_UNIQUE").IsUnique();

            entity.Property(e => e.Usagecol).HasMaxLength(45);

            entity.HasOne(d => d.Issue).WithMany(p => p.Usages)
                .HasForeignKey(d => d.IssueId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Issue_Usage");

            entity.HasOne(d => d.Oil).WithMany(p => p.Usages)
                .HasForeignKey(d => d.OilId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Oil_Usage");

            entity.HasOne(d => d.UsageType).WithMany(p => p.Usages)
                .HasForeignKey(d => d.UsageTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Usage_UsageType");
        });

        modelBuilder.Entity<UsageType>(entity =>
        {
            entity.HasKey(e => e.UsageTypeId).HasName("PRIMARY");

            entity.ToTable("UsageType");

            entity.HasIndex(e => e.UsageTypeId, "UsageTypeId_UNIQUE").IsUnique();

            entity.Property(e => e.Description).HasMaxLength(45);
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
