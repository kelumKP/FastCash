namespace LoanApp.Application.Dtos
{
    public class LoanApplicationDto
    {
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
    }
}