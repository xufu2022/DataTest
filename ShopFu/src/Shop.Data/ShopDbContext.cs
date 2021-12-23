using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Catalog;
using Shop.Domain.Product;

namespace Shop.Data
{
    public class ShopDbContext:DbContext
    {
        public ShopDbContext()
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("server=.;database=ShopFu;Integrated Security=true;");
            }
        }
        //public ShopDbContext(DbContextOptions<ShopDbContext> options): base(options)
        //{
        //    if (options == null) throw new ArgumentNullException(nameof(options));
        //}

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<ProductCategory> ProductCategories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //self reference Property
            modelBuilder.Entity<Category>()
                .HasOne(x => x.Parent)
                .WithMany()
                .HasForeignKey(x => x.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // many to many 1
            //modelBuilder.Entity<Category>()
            //    .HasMany(p => p.Products)
            //    .WithMany(p => p.Categories)
            //    .UsingEntity<ProductCategory>(
            //        j => j.HasOne(pt => pt.Category)
            //            .WithMany(t => t.ProductCategories)
            //            .HasForeignKey(pt => pt.CategoryId),
            //        k => k.HasOne(x => x.Product)
            //            .WithMany(x => x.ProductCategories)
            //            .HasForeignKey(x => x.ProductId),
            //        j =>
            //        {
            //            j.Property(x => x.IsFeaturedProduct).HasDefaultValue(false);
            //        }
            //    );

        }
    }
}
