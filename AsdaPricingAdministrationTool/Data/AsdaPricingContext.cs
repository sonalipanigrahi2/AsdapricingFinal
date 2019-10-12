using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AsdaPricingAdministrationTool.Models;

namespace AsdaPricingAdministrationTool.Models
{
    public class AsdaPriceContext : DbContext
    {
        public AsdaPriceContext()
        {
        }

        public AsdaPriceContext(DbContextOptions<AsdaPriceContext> options)
            : base(options)
        {
        }

        public DbSet<AsdaPricingAdministrationTool.Models.Delivery_Status> Delivery_Status { get; set; }
        public DbSet<AsdaPricingAdministrationTool.Models.Parameters> Parameters { get; set; }
        public DbSet<AsdaPricingAdministrationTool.Models.Delivery_Status_History> Delivery_Status_History { get; set; }
        public DbSet<AsdaPricingAdministrationTool.Models.FIELDMASTER> FIELDMASTER { get; set; }
        public DbSet<AsdaPricingAdministrationTool.Models.MARKETVOLUMES> MARKETVOLUMES { get; set; }
        public DbSet<AsdaPricingAdministrationTool.Models.NETVIDEMAPPINGPART1> NETVIDEMAPPINGPART1 { get; set; }
        public DbSet<AsdaPricingAdministrationTool.Models.NETVIDEMAPPINGPART2> NETVIDEMAPPINGPART2 { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Delivery_Status_History>()
                .HasKey(o => new { o.Delivery, o.TaskName });
            modelBuilder.Entity<FIELDMASTER>()
               .HasKey(o => new { o.Retailer, o.IRIWeek });
            modelBuilder.Entity<MARKETVOLUMES>()
              .HasKey(o => new { o.Retailer, o.CollectionDate });
            modelBuilder.Entity<NETVIDEMAPPINGPART1>()
              .HasKey(o => new { o.Retailer, o.BatchID });
            modelBuilder.Entity<NETVIDEMAPPINGPART2>()
              .HasKey(o => new { o.Retailer, o.BatchID });
        }

    }
}
