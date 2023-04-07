using EasyPDV.BackEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static EasyPDV.BackEnd.Infra.Mappings.Mapper;

namespace EasyPDV.BackEnd.Infra.Context
{
    public class PdvDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<CancelledSale> CancelledSale { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<ReversedSale> ReversedSale { get; set; }
        public DbSet<RegularSale> RegularSale { get; set; }
        public DbSet<Cashier> Cashier { get; set; }
        public DbSet<CashierBleed> CashierBleed { get; set; }
        public DbSet<CashierOpen> CashierOpen { get; set; }
        public DbSet<IndividualSale> IndividualSale { get; set; }
        public PdvDbContext(
            DbContextOptions options
            ) : base( options )
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new CancelledSaleMap());
            builder.ApplyConfiguration(new SaleMap());
            builder.ApplyConfiguration(new ReversedSaleMap());
            builder.ApplyConfiguration(new RegularSaleMap());
            builder.ApplyConfiguration(new RegularSaleMap());
            builder.ApplyConfiguration(new CashierMap());
            builder.ApplyConfiguration(new CashierOpenMap());
            builder.ApplyConfiguration(new IndividualSaleMap());
        }

    }
}
