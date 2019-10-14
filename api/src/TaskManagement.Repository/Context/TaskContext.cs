using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Repository.Context
{
    public class TaskContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }



        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
            var isCreated = Database.EnsureCreated();

            Console.WriteLine($"Database was Created ? {isCreated}");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .Property(p => p.Id)
                .HasColumnName("Id")
                .UseSqlServerIdentityColumn();

            modelBuilder.Entity<Task>()
                .Property(p => p.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Task>()
                .Property(p => p.TimeStamp)
                .HasColumnName("TimeStamp")
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
