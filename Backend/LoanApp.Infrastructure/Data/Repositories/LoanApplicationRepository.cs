using LoanApp.Core.Models;
using LoanApp.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LoanApp.Infrastructure.Data.Repositories
{
    public class LoanApplicationRepository : ILoanApplicationRepository
    {
        private readonly LoansUnlimitedContext _context;

        public LoanApplicationRepository(LoansUnlimitedContext context)
        {
            _context = context;
        }

        public async Task AddAsync(LoanApplication application)
        {
            _context.LoanApplications.Add(application);
            await _context.SaveChangesAsync();
        }
    }
}