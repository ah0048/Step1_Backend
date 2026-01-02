using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Step1_Backend.Services.DashboardService;

namespace Step1_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;
        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            var result = await _dashboardService.GetDashboardData();
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
