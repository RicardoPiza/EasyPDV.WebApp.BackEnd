using EasyPDV.BackEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using static EasyPDV.BackEnd.Infra.Mappings.Mapper;

namespace EasyPDV.BackEnd.Infra.Context
{
    public class PdvDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<SoldProduct> SoldProducts { get; set; }
        public DbSet<CancelledSale> CancelledSale { get; set; }
        public DbSet<ReversedSale> ReversedSales { get; set; }
        public DbSet<RegularSale> RegularSales { get; set; }
        public DbSet<Cashier> Cashier { get; set; }
        public DbSet<CashierBleed> CashierBleed { get; set; }
        public DbSet<CashierOpen> CashierOpen { get; set; }
        public DbSet<IndividualSale> IndividualSales { get; set; }
        public PdvDbContext(
            DbContextOptions options
            ) : base( options )
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new SoldProductMap());
            builder.ApplyConfiguration(new CancelledSaleMap());
            builder.ApplyConfiguration(new ReversedSaleMap());
            builder.ApplyConfiguration(new RegularSaleMap());
            builder.ApplyConfiguration(new RegularSaleMap());
            builder.ApplyConfiguration(new CashierMap());
            builder.ApplyConfiguration(new CashierOpenMap());
            builder.ApplyConfiguration(new IndividualSaleMap());
        }

    }
}
