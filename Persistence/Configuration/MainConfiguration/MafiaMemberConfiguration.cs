using Domain.Entities.MainAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration.MainConfiguration
{
    public class MafiaMemberConfiguration : IEntityTypeConfiguration<MafiaMember>
    {
        public void Configure(EntityTypeBuilder<MafiaMember> builder)
        {
            builder.ToTable("MafiaMember");

            builder.HasKey(x => x.Id);

            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Surname).IsRequired();
            builder.Property(t => t.Patronymic).IsRequired();
            builder.Property(t => t.Birthday).IsRequired();
            builder.Property(t => t.Phone).IsRequired();
            builder.Property(t => t.Health);
            builder.Property(t => t.Strength);

            builder.HasMany(t => t.OrderShops)
                .WithOne()
                .HasForeignKey(t => t.MafiaMemberId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
