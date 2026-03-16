using CORE.Entities;
using CORE.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class DataContext:IdentityDbContext<ApplicationUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=202-3\\SQLDERS;Database=OrganicDB;uid=sa;pwd=1;TrustServerCertificate=true");
        }

        //FluentAPI
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Product
            builder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.Entity<Product>()
                .Property(p => p.Description)
                .HasColumnType("varchar(50)")
                .HasAnnotation("Display", "Açıklama");

            builder.Entity<Product>()
                .Property(p => p.ListPrice)
                .HasColumnType("decimal(6,2)");
            #endregion

            #region Category
            builder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
            #endregion
        }
            public DbSet<Product> Products { get; set; }
            public DbSet<Category> Categories { get; set; }
            public DbSet<Comment> Comments { get; set; }
            public DbSet<Contact> Contacts { get; set; }
            public DbSet<Mail> Mails { get; set; }

    
    }
}
