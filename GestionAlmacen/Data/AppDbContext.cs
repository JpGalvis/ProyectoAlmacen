using GestionAlmacen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionAlmacen.Data
{
    public class AppDbContext : DbContext

    {
        public DbSet<Almacenes> Almacen { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }
            

    }
}
