using Final_Web_Project.DataModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Web_Project.Data
{
    public class FinalWebProjectDbContext : IdentityDbContext<FinalWebProjectUser, FinalWebProjectUserRole, string>
    {
        public FinalWebProjectDbContext(DbContextOptions<FinalWebProjectDbContext> options) : base(options)
        {

        }
        public FinalWebProjectDbContext()
        {

        }
    }
}
