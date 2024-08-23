using Microsoft.AspNetCore.Mvc;
using LoanApp.Application.Dtos;
using LoanApp.Infrastructure.Interfaces;
using System.Web.Http.Cors;

namespace LoanApp.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanApplicationService _loanApplicationService;

        public LoanController(ILoanApplicationService loanApplicationService)
        {
            _loanApplicationService = loanApplicationService;
        }

        [HttpPost]
        public IActionResult SubmitLoanApplication([FromBody] LoanApplicationDto loanApplication)
        {
            _loanApplicationService.SubmitLoanApplication(loanApplication);
            return Ok();
        }
    }
}