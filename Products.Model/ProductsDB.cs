using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Products.Model
{
    public partial class ProductsDB : DbContext
    {
        public ProductsDB()
        {
        }

        public ProductsDB(DbContextOptions<ProductsDB> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> TabProducts { get; set; }
        public virtual DbSet<ProductType> TabTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var str = File.ReadAllText("connection_string.cfg");
                optionsBuilder.UseMySQL(str);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("tab_products");

                entity.HasIndex(e => e.IdType, "id_type");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.IdType)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_type");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.TabProducts)
                    .HasForeignKey(d => d.IdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tab_products_ibfk_1");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("tab_types");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
