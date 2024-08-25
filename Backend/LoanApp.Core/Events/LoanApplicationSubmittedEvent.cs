namespace LoanApp.Core.Events
{
    public class LoanApplicationSubmittedEvent
    {
        public int LoanApplicationId { get; }

        public LoanApplicationSubmittedEvent(int loanApplicationId)
        {
            LoanApplicationId = loanApplicationId;
        }
    }
}