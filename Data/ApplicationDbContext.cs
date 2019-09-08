using System;
using System.Collections.Generic;
using System.Text;
using MerchTracker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MerchTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<MyAccessories> MyAccessories { get; set; }
        public DbSet<MyCaps> MyCaps { get; set; }
        public DbSet<MyShirts> MyShirts { get; set; }
    }
}
