﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    class MafiaFamilyConfiguration : IEntityTypeConfiguration<MafiaFamily>
    {
        public void Configure(EntityTypeBuilder<MafiaFamily> builder)
        {
            builder.ToTable("MafiaFamily");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Description).IsRequired();

            /*Доделать ключи в остальных конфигурациях*/
            builder.HasMany(t => t.MafiaMembers)
                .WithOne()
                .HasForeignKey(t => t.MafiaFamiliesId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(t => t.MafiaCompanies)
                .WithOne()
                .HasForeignKey(t => t.MafiaFamiliesId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}