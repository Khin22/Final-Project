using Final_Web_Project.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public FinalWebProjectDbContext(DbContextOptions<FinalWebProjectDbContext> options) : base(options)
        {

        }

        public FinalWebProjectDbContext()
        {

        }
    }
}
