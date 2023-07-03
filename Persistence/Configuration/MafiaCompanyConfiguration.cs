using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class MafiaCompanyConfiguration : IEntityTypeConfiguration<MafiaCompany>
    {
        public void Configure(EntityTypeBuilder<MafiaCompany> builder)
        {
            builder.ToTable("MafiaCompany");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Address).IsRequired();
            builder.Property(t => t.ContactPhone).IsRequired();
            builder.Property(t => t.BusinessType).IsRequired();
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Name).IsRequired();

            builder.HasMany(t => t.FinancialReports)
               .WithOne()
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
