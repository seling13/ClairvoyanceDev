
using OneFin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace OneFin.Models
{
    public class AppDbContext : DbContext
    {
        //public AppDbContext(DbContextOptions<AppDbContext> options)
        //    : base(options)
        //{
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OptMaster>().HasKey(vf => new { vf.OptName, vf.Value });
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
				{
				}

        public DbSet<OptMaster> OptMaster { get; set; }
        public DbSet<OneFin.Models.Roles> AspNetRoles { get; set; }
        public DbSet<TransactionMaster> TransactionMaster { get; set; }

        public DbSet<OneFin.Models.Users> AspNetUsers { get; set; }

        public DbSet<IdMaster> IdMaster { get; set; }
        public DbSet<CFCustomer> Customer { get; set; }

        public DbSet<UNList> UNlist { get; set; }


        //public DbSet<CustomerMaster_api> CustomerMaster_api { get; set; }
    }
}
