using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Catalog;
using Shop.Domain.Experiment;
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

        //many to many test 1
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        //end many to many test 1

        //one to one
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogImage> BlogImages { get; set; }
        //end one to one


        //https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key
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

            //experiment many to many 1
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Tags)
                .WithMany(p => p.Posts)
                .UsingEntity<PostTag>(
                    j => j
                        .HasOne(pt => pt.Tag)
                        .WithMany(t => t.PostTags)
                        .HasForeignKey(pt => pt.TagId),
                    j => j
                        .HasOne(pt => pt.Post)
                        .WithMany(p => p.PostTags)
                        .HasForeignKey(pt => pt.PostId),
                    j =>
                    {
                        j.Property(pt => pt.PublicationDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                        j.HasKey(t => new { t.PostId, t.TagId });
                    });

            //experiment many2many 2 without linktable
            //modelBuilder
            //    .Entity<Post>()
            //    .HasMany(p => p.Tags)
            //    .WithMany(p => p.Posts)
            //    .UsingEntity(j => j.ToTable("PostTags"));

            //experiment one 2 one
            modelBuilder.Entity<Blog>()
                .HasOne(b => b.BlogImage)
                .WithOne(i => i.Blog)
                .HasForeignKey<BlogImage>(b => b.BlogForeignKey);
            //
        }
    }
}
