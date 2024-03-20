using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class CustomerDBContext : DbContext
    {
        public CustomerDBContext(DbContextOptions<CustomerDBContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
