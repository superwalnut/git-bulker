using System;
using Gitbulker.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gitbulker.Repository
{
    public class GitbulkerDbContext : DbContext
    {
        public GitbulkerDbContext(DbContextOptions<GitbulkerDbContext> options)
        : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<TagItem> TagItems { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite(@"Data Source=InitDb/gitbulker.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>()
            .HasOne(p => p.Project)
            .WithMany(b => b.Tags)
            .HasForeignKey(p => p.ProjectId);

            modelBuilder.Entity<TagItem>()
                .HasOne(p => p.Tag)
                .WithMany(b => b.TagItems);
        }
    }
}
