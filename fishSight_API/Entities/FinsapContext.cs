using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace fishSight_API.Entities;

public partial class FinsapContext : DbContext
{
    public FinsapContext()
    {
    }

    public FinsapContext(DbContextOptions<FinsapContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Environment> Environments { get; set; }

    public virtual DbSet<Fish> Fish { get; set; }

    public virtual DbSet<FishDescription> FishDescriptions { get; set; }

    public virtual DbSet<FishLength> FishLengths { get; set; }

    public virtual DbSet<Gallery> Galleries { get; set; }

    public virtual DbSet<LocalName> LocalNames { get; set; }

    public virtual DbSet<Municipality> Municipalities { get; set; }

    public virtual DbSet<Province> Provinces { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<WaterEnvironment> WaterEnvironments { get; set; }

    public virtual DbSet<WaterTbl> WaterTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=finsap;uid=root;pwd=newpassword", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Environment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("environment");

            entity.HasIndex(e => e.FishId, "fish_loc");

            entity.HasIndex(e => e.MunicipalityId, "fish_muni");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.FishId)
                .HasColumnType("int(10)")
                .HasColumnName("fish_id");
            entity.Property(e => e.MunicipalityId)
                .HasColumnType("int(10)")
                .HasColumnName("municipality_id");

            entity.HasOne(d => d.Fish).WithMany(p => p.Environments)
                .HasForeignKey(d => d.FishId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fish_loc");

            entity.HasOne(d => d.Municipality).WithMany(p => p.Environments)
                .HasForeignKey(d => d.MunicipalityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fish_muni");
        });

        modelBuilder.Entity<Fish>(entity =>
        {
            entity.HasKey(e => e.FishId).HasName("PRIMARY");

            entity.ToTable("fish");

            entity.Property(e => e.FishId)
                .HasColumnType("int(11)")
                .HasColumnName("fish_id");
            entity.Property(e => e.FishImg).HasColumnName("fish_img");
            entity.Property(e => e.GeneralName)
                .HasMaxLength(50)
                .HasColumnName("general_name");
            entity.Property(e => e.ScientificName)
                .HasMaxLength(50)
                .HasColumnName("scientific_name");
        });

        modelBuilder.Entity<FishDescription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("fish_description");

            entity.HasIndex(e => e.FishId, "fish");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Biology).HasColumnName("biology");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Distribution).HasColumnName("distribution");
            entity.Property(e => e.FishId)
                .HasColumnType("int(10)")
                .HasColumnName("fish_id");
            entity.Property(e => e.LifeCycle).HasColumnName("life_cycle");

            entity.HasOne(d => d.Fish).WithMany(p => p.FishDescriptions)
                .HasForeignKey(d => d.FishId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fish");
        });

        modelBuilder.Entity<FishLength>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("fish_length");

            entity.HasIndex(e => e.FishId, "fish_length");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.FishId)
                .HasColumnType("int(10)")
                .HasColumnName("fish_id");
            entity.Property(e => e.Maturity)
                .HasMaxLength(255)
                .HasColumnName("maturity");
            entity.Property(e => e.MaxLength)
                .HasMaxLength(255)
                .HasColumnName("max_length");
            entity.Property(e => e.Other)
                .HasMaxLength(255)
                .HasColumnName("other");

            entity.HasOne(d => d.Fish).WithMany(p => p.FishLengths)
                .HasForeignKey(d => d.FishId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fish_length");
        });

        modelBuilder.Entity<Gallery>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("gallery");

            entity.HasIndex(e => e.FishId, "gallery");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.FishId)
                .HasColumnType("int(10)")
                .HasColumnName("fish_id");
            entity.Property(e => e.FishImg)
                .HasColumnType("blob")
                .HasColumnName("fish_img");

            entity.HasOne(d => d.Fish).WithMany(p => p.Galleries)
                .HasForeignKey(d => d.FishId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("gallery");
        });

        modelBuilder.Entity<LocalName>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("local_names");

            entity.HasIndex(e => e.FishId, "local_name");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.FishId)
                .HasColumnType("int(10)")
                .HasColumnName("fish_id");
            entity.Property(e => e.LocalName1)
                .HasMaxLength(50)
                .HasColumnName("local_name");

            entity.HasOne(d => d.Fish).WithMany(p => p.LocalNames)
                .HasForeignKey(d => d.FishId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("local_name");
        });

        modelBuilder.Entity<Municipality>(entity =>
        {
            entity.HasKey(e => e.MunicipalityId).HasName("PRIMARY");

            entity.ToTable("municipality");

            entity.HasIndex(e => e.ProvinceId, "municipality");

            entity.Property(e => e.MunicipalityId)
                .HasColumnType("int(11)")
                .HasColumnName("municipality_id");
            entity.Property(e => e.MunicipalityName)
                .HasMaxLength(50)
                .HasColumnName("municipality_name");
            entity.Property(e => e.ProvinceId)
                .HasColumnType("int(10)")
                .HasColumnName("province_id");

            entity.HasOne(d => d.Province).WithMany(p => p.Municipalities)
                .HasForeignKey(d => d.ProvinceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("municipality");
        });

        modelBuilder.Entity<Province>(entity =>
        {
            entity.HasKey(e => e.ProvinceId).HasName("PRIMARY");

            entity.ToTable("province");

            entity.HasIndex(e => e.RegionId, "province");

            entity.Property(e => e.ProvinceId)
                .HasColumnType("int(11)")
                .HasColumnName("province_id");
            entity.Property(e => e.ProvinceName)
                .HasMaxLength(50)
                .HasColumnName("province_name");
            entity.Property(e => e.RegionId)
                .HasColumnType("int(10)")
                .HasColumnName("region_id");

            entity.HasOne(d => d.Region).WithMany(p => p.Provinces)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("province");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.RegionId).HasName("PRIMARY");

            entity.ToTable("region");

            entity.Property(e => e.RegionId)
                .HasColumnType("int(11)")
                .HasColumnName("region_id");
            entity.Property(e => e.RegionName)
                .HasMaxLength(50)
                .HasColumnName("region_name");
        });

        modelBuilder.Entity<WaterEnvironment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("water_environment");

            entity.HasIndex(e => e.FishId, "fish_id");

            entity.HasIndex(e => e.WaterId, "water");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.FishId)
                .HasColumnType("int(11)")
                .HasColumnName("fish_id");
            entity.Property(e => e.WaterId)
                .HasColumnType("int(11)")
                .HasColumnName("water_id");

            entity.HasOne(d => d.Fish).WithMany(p => p.WaterEnvironments)
                .HasForeignKey(d => d.FishId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fish_id");

            entity.HasOne(d => d.Water).WithMany(p => p.WaterEnvironments)
                .HasForeignKey(d => d.WaterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("water");
        });

        modelBuilder.Entity<WaterTbl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("water_tbl");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.WaterType)
                .HasMaxLength(50)
                .HasColumnName("water_type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
