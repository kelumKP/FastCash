using Microsoft.AspNetCore.Mvc;
using LoanApp.Application.Dtos;
using LoanApp.Infrastructure.Interfaces;
using System.Web.Http.Cors;
using LoanApp.Application.Services;

namespace LoanApp.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly LoanApplicationManager _loanApplicationManager;

        public LoanController(LoanApplicationManager loanApplicationManager)
        {
            _loanApplicationManager = loanApplicationManager;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitLoanApplication([FromBody] LoanApplicationDto loanApplicationDto)
        {
            var result = await _loanApplicationManager.SubmitLoanApplicationAsync(loanApplicationDto);
            if (result)
                return Ok(new { message = "Loan application submitted successfully." });

            return BadRequest(new { message = "Failed to submit loan application." });
        }
    }
}