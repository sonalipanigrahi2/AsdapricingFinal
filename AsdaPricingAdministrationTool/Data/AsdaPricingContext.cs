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
        
    }
}
