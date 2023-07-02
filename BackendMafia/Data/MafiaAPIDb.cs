using BackendMafia.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendMafia.Data
{
    public class MafiaAPIDb: DbContext
    {
        public MafiaAPIDb(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MafiaFamily> MafiaFamilies { get; set; }

        public DbSet<MafiaMember> MafiaMembers { get; set; }

        public DbSet<MafiaCompany> MafiaCompanies { get; set; }
        
        public DbSet<FinancialReports> FinancialReports { get; set; }
    }
}
