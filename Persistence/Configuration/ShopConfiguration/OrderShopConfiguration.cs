using Domain.Entities;
using Domain.Entities.ShopAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration.ShopConfiguration
{
    public class OrderShopConfiguration : IEntityTypeConfiguration<OrderShop>
    {
        public void Configure(EntityTypeBuilder<OrderShop> builder)
        {
            builder.ToTable("OrderShop");

            builder.HasKey(x => x.Id);

            builder.Property(t => t.GunName).IsRequired();
            builder.Property(t => t.AmmunitonName).IsRequired();
            builder.Property(t => t.AmmunitonCount).IsRequired();
        }
    }
}
