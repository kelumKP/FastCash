using LoanApp.Core.Models;
using System.Threading.Tasks;

namespace LoanApp.Infrastructure.Data.Repositories
{
    public interface ILoanApplicationRepository
    {
        Task AddAsync(LoanApplication application);
    }
}