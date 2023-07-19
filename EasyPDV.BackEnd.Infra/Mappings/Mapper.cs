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
        public class SaleMap : IEntityTypeConfiguration<Sale>
        {
            public void Configure(EntityTypeBuilder<Sale> builder)
            {
                
                builder.ToTable("Sales");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.SalePrice);
                builder.Property(x => x.SaleDate);
                builder.Property(x => x.PaymentMethod);
                builder.HasMany(x => x.Products);

            }
        }
        public class EventMap : IEntityTypeConfiguration<Event>
        {
            public void Configure(EntityTypeBuilder<Event> builder)
            {

                builder.ToTable("Events");
                builder.HasKey(x => x.Id);
                builder.HasMany(x => x.Sales);
                builder.Property(x => x.CashierStatus);

            }
        }

    }
}
