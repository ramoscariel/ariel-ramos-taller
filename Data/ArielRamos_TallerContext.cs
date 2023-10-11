using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ArielRamos_Taller.Models;

namespace ArielRamos_Taller.Data
{
    public class ArielRamos_TallerContext : DbContext
    {
        public ArielRamos_TallerContext (DbContextOptions<ArielRamos_TallerContext> options)
            : base(options)
        {
        }

        public DbSet<ArielRamos_Taller.Models.Burger> Burger { get; set; } = default!;
    }
}
