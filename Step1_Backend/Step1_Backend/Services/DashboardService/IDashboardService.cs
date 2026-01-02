using Step1_Backend.DTOs.DashboardDTOs;
using Step1_Backend.Helpers;

namespace Step1_Backend.Services.DashboardService
{
    public interface IDashboardService
    {
        Task<Result<DashboardDataDTO>> GetDashboardData();
    }
}
