using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.MainAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration.MainConfiguration
{
    class MafiaFamilyConfiguration : IEntityTypeConfiguration<MafiaFamily>
    {
        public void Configure(EntityTypeBuilder<MafiaFamily> builder)
        {
            builder.ToTable("MafiaFamily");

            builder.HasKey(x => x.Id);

            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Description).IsRequired();
            builder.Property(t => t.FamilyMoney).IsRequired();

            builder.HasMany(t => t.MafiaMembers)
                .WithOne()
                .HasForeignKey(t => t.MafiaFamilyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(t => t.MafiaCompanies)
                .WithOne()
                .HasForeignKey(t => t.MafiaFamilyId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}