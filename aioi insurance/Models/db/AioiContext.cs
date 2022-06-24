using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace aioi_insurance.Models.db
{
    public partial class AioiContext : DbContext
    {
        public AioiContext()
        {
        }

        public AioiContext(DbContextOptions<AioiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contract> Contracts { get; set; } = null!;
        public virtual DbSet<ContractType> ContractTypes { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<NameTitle> NameTitles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile("appsettings.json")
                               .Build();
                var connectionString = configuration.GetConnectionString("AioiDB");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("contract");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CarBrand)
                    .HasMaxLength(50)
                    .HasColumnName("carBrand");

                entity.Property(e => e.CarSerie)
                    .HasMaxLength(50)
                    .HasColumnName("carSerie");

                entity.Property(e => e.Cc)
                    .HasMaxLength(5)
                    .HasColumnName("cc");

                entity.Property(e => e.ContractId)
                    .HasMaxLength(50)
                    .HasColumnName("contractID");

                entity.Property(e => e.CusId)
                    .HasMaxLength(50)
                    .HasColumnName("cusID");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("endDate");

                entity.Property(e => e.LicenseNo)
                    .HasMaxLength(10)
                    .HasColumnName("licenseNo");

                entity.Property(e => e.Limit).HasColumnName("limit");

                entity.Property(e => e.Premium).HasColumnName("premium");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("startDate");

                entity.Property(e => e.TypeId).HasColumnName("typeID");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_contract_contractType");
            });

            modelBuilder.Entity<ContractType>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("contractType");

                entity.Property(e => e.TypeId).HasColumnName("typeID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CusId)
                    .HasMaxLength(50)
                    .HasColumnName("cusID");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.RegistDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registDate");

                entity.Property(e => e.Surname)
                    .HasMaxLength(150)
                    .HasColumnName("surname");

                entity.Property(e => e.Tel)
                    .HasMaxLength(15)
                    .HasColumnName("tel");

                entity.Property(e => e.TitleId).HasColumnName("titleID");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_customer_nameTitle");
            });

            modelBuilder.Entity<NameTitle>(entity =>
            {
                entity.ToTable("nameTitle");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                    .HasMaxLength(10)
                    .HasColumnName("title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
