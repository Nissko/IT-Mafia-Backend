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
    public class FinancialReportsConfigaration : IEntityTypeConfiguration<FinancialReports>
    {
        public void Configure(EntityTypeBuilder<FinancialReports> builder)
        {
            builder.ToTable("FinanCialReports");

            builder.HasKey(x => x.Id);

            builder.Property(t => t.Date).IsRequired();
            builder.Property(t => t.Revenue).IsRequired();
            builder.Property(t => t.Expense).IsRequired();
            builder.Property(t => t.NetIncome).IsRequired();
            builder.Property(t => t.FamilyDonate).IsRequired();
        }
    }
}
