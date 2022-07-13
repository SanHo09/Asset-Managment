using Microsoft.EntityFrameworkCore;
using SalesWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWebsite.UnitTest
{
    public class FakeDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
    }
}
