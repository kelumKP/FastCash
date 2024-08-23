using Microsoft.EntityFrameworkCore;
using LoanApp.Core.Models;

namespace LoanApp.Infrastructure.Data
{
    public class LoansUnlimitedContext : DbContext
    {
        public LoansUnlimitedContext(DbContextOptions<LoansUnlimitedContext> options)
            : base(options)
        {
        }

        public DbSet<LoanApplication> LoanApplications { get; set; }
    }
}