using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AzureNet7WebApi.Models;

namespace AzureNet7WebApi.Data
{
    public class AzureNet7WebApiContext : DbContext
    {
        public AzureNet7WebApiContext (DbContextOptions<AzureNet7WebApiContext> options)
            : base(options)
        {
        }

        public DbSet<AzureNet7WebApi.Models.Customer> Customer { get; set; } = default!;

        public DbSet<AzureNet7WebApi.Models.Product> Product { get; set; } = default!;

        public DbSet<AzureNet7WebApi.Models.Order> Order { get; set; } = default!;
    }
}
