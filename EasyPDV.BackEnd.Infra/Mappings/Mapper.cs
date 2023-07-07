using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EasyPDV.BackEnd.Domain.Entities;

namespace EasyPDV.BackEnd.Infra.Mappings
{
    public class Mapper
    {
        public class ProductMap : IEntityTypeConfiguration<Product>
        {
            public void Configure(EntityTypeBuilder<Product> builder)
            {

                builder.ToTable("Products");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name).IsRequired();
                builder.Property(x => x.Price).IsRequired();
                builder.Property(x => x.Image).HasColumnType("varbinary(MAX)").HasConversion<byte[]>();

            }
        }
        public class SoldProductMap : IEntityTypeConfiguration<SoldProduct>
        {
            public void Configure(EntityTypeBuilder<SoldProduct> builder)
            {

                builder.ToTable("SoldProducts");
                builder.HasKey(x => x.SoldProductId);
                builder.Property(x => x.Name).IsRequired();
                builder.Property(x => x.Price).IsRequired();

            }
        }
        public class CancelledSaleMap : IEntityTypeConfiguration<CancelledSale>
        {
            public void Configure(EntityTypeBuilder<CancelledSale> builder)
            {

                builder.ToTable("CancelledSales");
                builder.HasKey(x => x.CancelledSaleId);
                builder.Property(x => x.PaymentMethod).IsRequired();
                builder.Property(x => x.SalePrice).IsRequired();
                builder.Property(x => x.SaleDate).IsRequired();
                builder.HasMany(x => x.CancelledSaleProducts);

            }
        }
        public class RegularSaleMap : IEntityTypeConfiguration<RegularSale>
        {
            public void Configure(EntityTypeBuilder<RegularSale> builder)
            {
                
                builder.ToTable("RegularSales");
                builder.HasKey(x => x.RegularSaleId);
                builder.Property(x => x.SalePrice);
                builder.Property(x => x.SaleDate);
                builder.Property(x => x.PaymentMethod);
                builder.HasMany(x => x.SoldProducts);

            }
        }
        public class ReversedSaleMap : IEntityTypeConfiguration<ReversedSale>
        {
            public void Configure(EntityTypeBuilder<ReversedSale> builder)
            {
                
                builder.ToTable("ReversedSales");
                builder.HasKey(x => x.ReversedSaleId);
                builder.Property(x => x.PaymentMethod);
                builder.Property(x => x.SalePrice);
                builder.Property(x => x.SaleDate);
                builder.HasOne(x => x.ProductChangeFrom)
                    .WithMany()
                    .OnDelete(DeleteBehavior.NoAction);
                builder.HasOne(x => x.ProductChangeTo)
                    .WithMany()
                    .OnDelete(DeleteBehavior.NoAction);

            }
        }
        public class IndividualSaleMap : IEntityTypeConfiguration<IndividualSale>
        {
            public void Configure(EntityTypeBuilder<IndividualSale> builder)
            {

                builder.ToTable("IndividualSales");
                builder.HasKey(x => x.IndividualSaleId);
                builder.Property(x => x.PaymentMethod);
                builder.Property(x => x.SalePrice);
                builder.Property(x => x.SaleDate);
                builder.HasOne(x => x.SoldProduct);
            }
        }
        public class CashierOpenMap : IEntityTypeConfiguration<CashierOpen>
        {
            public void Configure(EntityTypeBuilder<CashierOpen> builder)
            {

                builder.ToTable("CashierOpen");
                builder.Property(x => x.Status);
                builder.Property(x => x.EventName);
                builder.Property(x => x.CashierResponsible);
                builder.Property(x => x.CashierNumber);
                builder.Property(x => x.InitialBalance);
                builder.Property(x => x.Date);
            }
        }
        public class CashierMap : IEntityTypeConfiguration<Cashier>
        {
            public void Configure(EntityTypeBuilder<Cashier> builder)
            {

                builder.ToTable("Cashier");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.CashierNumber);
                builder.Property(x => x.EventName);
                builder.Property(x => x.CashierResponsible);
                builder.Property(x => x.Date);
            }
        }
        public class CashierBleedMap : IEntityTypeConfiguration<CashierBleed>
        {
            public void Configure(EntityTypeBuilder<CashierBleed> builder)
            {

                builder.ToTable("CashierBleed");
                builder.HasKey(x => x.Value);
                builder.Property(x => x.Type);
                builder.Property(x => x.Description);
            }
        }
    }
}
