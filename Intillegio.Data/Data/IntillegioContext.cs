﻿using Intillegio.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Intillegio.Data.Data
{
    public class IntillegioContext : IdentityDbContext<IntillegioUser>
    {
        public IntillegioContext(DbContextOptions<IntillegioContext> options)
            : base(options)
        {
        }

        public DbSet<Partner> Partners { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProjectFeatureJunctionClass> ProjectFeaturesJunction { get; set; }
        public DbSet<ProjectFeature> Features { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<ProductImage> Images { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<QuickLink> QuickLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IntillegioUser>().ToTable("User");
            builder.Entity<IntillegioUser>().Property(u => u.PasswordHash).HasMaxLength(500);

            builder.Entity<ProjectFeatureJunctionClass>()
                .HasKey(pf => new {pf.ProjectId, pf.FeatureId});

            builder.Entity<ProjectFeatureJunctionClass>()
                .HasOne(p => p.Project)
                .WithMany(f => f.Features)
                .HasForeignKey(pf => pf.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProjectFeatureJunctionClass>()
                .HasOne(f => f.ProjectFeature)
                .WithMany(p => p.Projects)
                .HasForeignKey(f => f.FeatureId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
