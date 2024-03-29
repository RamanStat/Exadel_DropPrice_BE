﻿using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataContext
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        public DbSet<Office> Offices { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<Discount> Discounts { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<PointOfSale> PointOfSales { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Assessment> Assessments { get; set; }

        public DbSet<SavedDiscount> SavedDiscounts { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<ConfigVariable> ConfigVariables { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<LocalizedName> LocalizedName { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
