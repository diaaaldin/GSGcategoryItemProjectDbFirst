using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GSGcategoryItemProjectDbFirst.Models
{
    public partial class CategoryItemDb2Context : DbContext
    {
        public CategoryItemDb2Context()
        {
        }

        public CategoryItemDb2Context(DbContextOptions<CategoryItemDb2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<SupCategory> SupCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("Server=DESKTOP-K722RLO\\SQLEXPRESS;Database=CategoryItemDb2;Trusted_Connection=True;");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("items");

                entity.HasIndex(e => e.SupCategoryId, "IX_items_SupCategoryId");

                entity.HasOne(d => d.SupCategory)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.SupCategoryId);
            });

            modelBuilder.Entity<SupCategory>(entity =>
            {
                entity.ToTable("supCategories");

                entity.HasIndex(e => e.CategoryId, "IX_supCategories_CategoryId");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SupCategories)
                    .HasForeignKey(d => d.CategoryId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
