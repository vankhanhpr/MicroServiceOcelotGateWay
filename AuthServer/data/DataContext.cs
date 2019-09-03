using Microsoft.EntityFrameworkCore;
using ModelClassLibrary.area.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
    }
}
