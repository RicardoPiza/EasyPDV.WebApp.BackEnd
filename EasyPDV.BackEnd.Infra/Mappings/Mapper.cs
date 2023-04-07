using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            }
        }
        public class SaleMap : IEntityTypeConfiguration<Sale>
        {
            public void Configure(EntityTypeBuilder<Sale> builder)
            {

                builder.ToTable("Sales");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.SalePrice).IsRequired();
                builder.Property(x => x.PaymentMethod).IsRequired();
                builder.Property(x => x.SaleDate).IsRequired();

            }
        }
        public class CancelledSaleMap : IEntityTypeConfiguration<CancelledSale>
        {
            public void Configure(EntityTypeBuilder<CancelledSale> builder)
            {

                builder.ToTable("CancelledSales");
                builder.Property(x => x.PaymentMethod).IsRequired();
                builder.Property(x => x.SalePrice).IsRequired();
                builder.Property(x => x.SaleDate).IsRequired();

            }
        }
        public class RegularSaleMap : IEntityTypeConfiguration<RegularSale>
        {
            public void Configure(EntityTypeBuilder<RegularSale> builder)
            {
                
                builder.ToTable("RegularSales");
                builder.Property(x => x.SalePrice);
                builder.Property(x => x.SaleDate);
                builder.Property(x => x.PaymentMethod);
                builder.HasMany(x => x.Products);

            }
        }
        public class ReversedSaleMap : IEntityTypeConfiguration<ReversedSale>
        {
            public void Configure(EntityTypeBuilder<ReversedSale> builder)
            {

                builder.ToTable("ReversedSales");
                builder.Property(x => x.PaymentMethod);
                builder.Property(x => x.SalePrice);
                builder.Property(x => x.SaleDate);
                builder.HasOne(x => x.ProductChangeFrom);
                builder.HasOne(x => x.ProductChangeTo);

            }
        }
        public class IndividualSaleMap : IEntityTypeConfiguration<IndividualSale>
        {
            public void Configure(EntityTypeBuilder<IndividualSale> builder)
            {

                builder.ToTable("IndividualSales");
                builder.Property(x => x.PaymentMethod);
                builder.Property(x => x.SalePrice);
                builder.Property(x => x.SaleDate);
                builder.HasOne(x => x.Product);
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
