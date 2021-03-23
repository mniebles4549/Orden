using System;
using Microsoft.EntityFrameworkCore;
using Orden.Model;
namespace Orden.BdContext
{
    public class ApplicationDbContext:  DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Ordenn> Ordens  { get; set; }
        public DbSet<Detalle> Detalles { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
    

}
