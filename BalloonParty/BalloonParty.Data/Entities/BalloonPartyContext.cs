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
        public virtual DbSet<CustomerOrder> CustomerOrder { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Store> Store { get; set; }

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
                    .HasName("PK__Customer__49A14741F445B390");

                entity.ToTable("Customer", "BPDB");

                entity.Property(e => e.EmailAddress).HasMaxLength(150);

                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.City).HasMaxLength(150);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.State).HasMaxLength(25);
            });

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.ToTable("CustomerOrder", "BPDB");

                entity.Property(e => e.CustomerOrderId).HasColumnName("CustomerOrderID");

                entity.Property(e => e.CustomerEmail).HasMaxLength(150);

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("numeric(10, 2)");

                entity.HasOne(d => d.CustomerEmailNavigation)
                    .WithMany(p => p.CustomerOrder)
                    .HasForeignKey(d => d.CustomerEmail)
                    .HasConstraintName("FK__CustomerO__Custo__02084FDA");

                entity.HasOne(d => d.CustomerLineNavigation)
                    .WithMany(p => p.CustomerOrder)
                    .HasForeignKey(d => d.CustomerLine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerO__Custo__02FC7413");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory", "BPDB");

                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__ItemI__7E37BEF6");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Store__7F2BE32F");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice", "BPDB");

                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

                entity.Property(e => e.EmailAddress).HasMaxLength(150);

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.EmailAddressNavigation)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.EmailAddress)
                    .HasConstraintName("FK__Invoice__EmailAd__797309D9");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Invoice__ItemID__7B5B524B");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Invoice__StoreID__7A672E12");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item", "BPDB");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.ItemName).HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store", "BPDB");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.City).HasMaxLength(150);

                entity.Property(e => e.State).HasMaxLength(25);

                entity.Property(e => e.StoreName).HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
