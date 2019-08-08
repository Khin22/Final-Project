using Final_Web_Project.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Text;

namespace Final_Web_Project.Data
{
    public class FinalWebProjectDbContext : IdentityDbContext<FinalWebProjectUser, FinalWebProjectUserRole, string>
    {
        public DbSet<Record> Records { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderStatus> OrderStatuses { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        public DbSet<DeliveryDetails> DeliveryDetails { get; set; }

        public DbSet<ReceiptStatus> ReceiptStatuses { get; set; }

        public FinalWebProjectDbContext(DbContextOptions<FinalWebProjectDbContext> options) : base(options)
        {

        }

        public FinalWebProjectDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Genre>().HasIndex(i => i.Name).IsUnique();
        }
    }
}
