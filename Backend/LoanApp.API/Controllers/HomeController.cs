using Microsoft.AspNetCore.Mvc;

namespace LoanApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Welcome to the Loan API");
        }
    }
}

