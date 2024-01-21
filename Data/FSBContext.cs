using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using fsb.Models;

namespace FSB.Data
{
    public class FSBContext : DbContext
    {
        public FSBContext (DbContextOptions<FSBContext> options)
            : base(options)
        {
        }

        public DbSet<fsb.Models.Docs> Docs { get; set; } = default!;
    }
}
