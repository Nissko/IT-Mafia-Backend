﻿using Domain.Entities.MainAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration.MainConfiguration
{
    public class MafiaCompanyConfiguration : IEntityTypeConfiguration<MafiaCompany>
    {
        public void Configure(EntityTypeBuilder<MafiaCompany> builder)
        {
            builder.ToTable("MafiaCompany");

            builder.HasKey(x => x.Id);

            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Address).IsRequired();
            builder.Property(t => t.ContactPhone).IsRequired();
            builder.Property(t => t.BusinessType).IsRequired();

            builder.HasMany(t => t.FinancialReports)
                .WithOne()
                .HasForeignKey(t => t.MafiaCompanyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
