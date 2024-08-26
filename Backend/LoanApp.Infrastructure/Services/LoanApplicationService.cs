using LoanApp.Application.Dtos;
using LoanApp.Core.Models;
using LoanApp.Infrastructure.Data;
using LoanApp.Infrastructure.Interfaces;

namespace LoanApp.Infrastructure.Services
{
 public class LoanApplicationService : ILoanApplicationService
{
    private readonly LoansUnlimitedContext _context;

    public LoanApplicationService(LoansUnlimitedContext context)
    {
        _context = context;
    }

    public void SubmitLoanApplication(LoanApplicationDto loanApplicationDto)
    {
        var loanApplication = new LoanApplication
        {
            CustomerId = loanApplicationDto.CustomerId,
            Amount = loanApplicationDto.Amount,
            Status = loanApplicationDto.Status
        };
       
        _context.LoanApplications.Add(loanApplication);
        _context.SaveChanges();
    }
}
}
