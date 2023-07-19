using EasyPDV.BackEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using static EasyPDV.BackEnd.Infra.Mappings.Mapper;

namespace EasyPDV.BackEnd.Infra.Context
{
    public class PdvDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Event> Events { get; set; }
        public PdvDbContext(
            DbContextOptions options
            ) : base( options )
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new SaleMap());
            builder.ApplyConfiguration(new EventMap());
        }

    }
}
