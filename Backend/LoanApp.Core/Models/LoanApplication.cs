using System.ComponentModel.DataAnnotations;


namespace LoanApp.Core.Models
{
    public class LoanApplication
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } // Ensure this field is set before saving
    }
}