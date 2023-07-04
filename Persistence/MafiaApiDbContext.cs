using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class MafiaApiDbContext : DbContext
    {
        public MafiaApiDbContext(DbContextOptions options)
    : base(options)
        {
        }

        public DbSet<MafiaFamily> MafiaFamilies { get; set; }

        public DbSet<MafiaMember> MafiaMembers { get; set; }

        public DbSet<MafiaCompany> MafiaCompanies { get; set; }

        public DbSet<FinancialReports> FinancialReports { get; set; }

    }
}
