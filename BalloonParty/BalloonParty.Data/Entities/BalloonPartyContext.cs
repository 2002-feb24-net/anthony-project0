using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BalloonParty.Library.Models;

namespace BalloonParty.Data.Entities
{
    public partial class BalloonPartyContext : DbContext
    {
        public BalloonPartyContext()
        {
        }

        public BalloonPartyContext(DbContextOptions<BalloonPartyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerOrders> CustomerOrders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductsPurchased> ProductsPurchased { get; set; }
        public virtual DbSet<RootUser> RootUser { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<StoreInventory> StoreInventory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(EfSecretFile.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.EmailAddress)
                    .HasName("PK__Customer__49A147415F8CC91A");

                entity.ToTable("Customer", "BPDB");

                entity.HasIndex(e => e.CustomerPw)
                    .HasName("UQ__Customer__A4AFAF85ABBF9290")
                    .IsUnique();

                entity.Property(e => e.EmailAddress).HasMaxLength(150);

                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.City).HasMaxLength(150);

                entity.Property(e => e.CustomerPw)
                    .HasColumnName("CustomerPW")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.State).HasMaxLength(25);
            });

            modelBuilder.Entity<CustomerOrders>(entity =>
            {
                entity.HasKey(e => e.CustomerOrderId)
                    .HasName("PK__Customer__28FBA0DC3C886732");

                entity.ToTable("CustomerOrders", "BPDB");

                entity.Property(e => e.CustomerOrderId).HasColumnName("CustomerOrderID");

                entity.Property(e => e.CustomerEmail).HasMaxLength(150);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TotalPrice).HasColumnType("numeric(10, 2)");

                entity.HasOne(d => d.CustomerEmailNavigation)
                    .WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.CustomerEmail)
                    .HasConstraintName("FK__CustomerO__Custo__17036CC0");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Products__B40CC6EDE63E1C24");

                entity.ToTable("Products", "BPDB");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName).HasMaxLength(100);

                entity.Property(e => e.ProductPrice).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<ProductsPurchased>(entity =>
            {
                entity.HasKey(e => e.PurchasedProductId)
                    .HasName("PK__Products__FFE592CD75DFA111");

                entity.ToTable("ProductsPurchased", "BPDB");

                entity.Property(e => e.PurchasedProductId).HasColumnName("PurchasedProductID");

                entity.Property(e => e.CustomerEmail).HasMaxLength(150);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.CustomerEmailNavigation)
                    .WithMany(p => p.ProductsPurchased)
                    .HasForeignKey(d => d.CustomerEmail)
                    .HasConstraintName("FK__ProductsP__Custo__1BC821DD");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductsPurchased)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductsP__Produ__19DFD96B");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.ProductsPurchased)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductsP__Store__1AD3FDA4");
            });

            modelBuilder.Entity<RootUser>(entity =>
            {
                entity.HasKey(e => e.RootName)
                    .HasName("PK__RootUser__95AB648FB555849D");

                entity.ToTable("RootUser", "BPDB");

                entity.Property(e => e.RootName).HasMaxLength(15);

                entity.Property(e => e.RootPw)
                    .HasColumnName("RootPW")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store", "BPDB");

                entity.HasIndex(e => e.StorePw)
                    .HasName("UQ__Store__3B823A14BC581DDA")
                    .IsUnique();

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.City).HasMaxLength(150);

                entity.Property(e => e.State).HasMaxLength(25);

                entity.Property(e => e.StoreName).HasMaxLength(150);

                entity.Property(e => e.StorePw)
                    .HasColumnName("StorePW")
                    .HasMaxLength(50);

                entity.Property(e => e.StoreUsername).HasMaxLength(50);
            });

            modelBuilder.Entity<StoreInventory>(entity =>
            {
                entity.HasKey(e => e.SinventoryId)
                    .HasName("PK__StoreInv__27E8BCF05DF24467");

                entity.ToTable("StoreInventory", "BPDB");

                entity.Property(e => e.SinventoryId).HasColumnName("SinventoryID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName).HasMaxLength(100);

                entity.Property(e => e.ProductPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.StoreInventory)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StoreInve__Produ__236943A5");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreInventory)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StoreInve__Store__22751F6C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
