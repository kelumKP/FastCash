
using LoanApp.Application.Dtos;

namespace LoanApp.Infrastructure.Interfaces
{
    public interface ILoanApplicationService
    {
        void SubmitLoanApplication(LoanApplicationDto loanApplicationDto);
    }
}
