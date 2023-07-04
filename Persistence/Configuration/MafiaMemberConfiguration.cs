﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
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
        }
    }
}
