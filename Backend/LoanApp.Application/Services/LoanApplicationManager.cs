using LoanApp.Core.Events;  // Add this directive
using LoanApp.Core.Models;
using LoanApp.Core.Interfaces;
using LoanApp.Application.Dtos;
using System.Threading.Tasks;
using LoanApp.Infrastructure.Data.Repositories;

namespace LoanApp.Application.Services
{
    public class LoanApplicationManager
    {
        private readonly ILoanApplicationRepository _loanApplicationRepository;
        private readonly IEventBus _eventBus;

        public LoanApplicationManager(ILoanApplicationRepository loanApplicationRepository, IEventBus eventBus)
        {
            _loanApplicationRepository = loanApplicationRepository;
            _eventBus = eventBus;
        }

        public async Task<bool> SubmitLoanApplicationAsync(LoanApplicationDto loanApplicationDto)
        {
            try
            {
                // Convert DTO to domain model
                var loanApplication = new LoanApplication
                {
                    CustomerId = loanApplicationDto.CustomerId,
                    Amount = loanApplicationDto.Amount,
                    Status = loanApplicationDto.Status
                };

                // Save the loan application
                await _loanApplicationRepository.AddAsync(loanApplication);

                // Publish an event
                _eventBus.Publish(new LoanApplicationSubmittedEvent(loanApplication.Id));

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}