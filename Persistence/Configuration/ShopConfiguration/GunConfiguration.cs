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
    public class GunConfiguration : IEntityTypeConfiguration<Gun>
    {
        public void Configure(EntityTypeBuilder<Gun> builder)
        {
            builder.ToTable("Gun");

            builder.HasKey(x => x.Id);

            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Count).IsRequired();
            builder.Property(t => t.Type).IsRequired();
            builder.Property(t => t.Price).IsRequired();
        }
    }
}
