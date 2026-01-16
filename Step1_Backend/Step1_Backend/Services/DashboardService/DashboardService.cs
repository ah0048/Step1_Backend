
using Step1_Backend.DTOs.DashboardDTOs;
using Step1_Backend.Helpers;
using Step1_Backend.UnitOfWorks;

namespace Step1_Backend.Services.DashboardService
{
    public class DashboardService : IDashboardService
    {

        private readonly IUnitOfWork _unit;

        public DashboardService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<Result<DashboardDataDTO>> GetDashboardData()
        {
            try
            {
                var data = new DashboardDataDTO();

                // 1. Get Trainers and count their reservations
                var trainers = await _unit.TrainerRepo.GetAllAsync();
                var reservations = await _unit.ReservationRepo.GetAllAsync();
                var packages = await _unit.PackageRepo.GetAllAsync();
                var orders = await _unit.PaymentOrderRepo.GetAllAsync();

                data.TrainerCount = trainers.Count;
                data.ReservationCount = reservations.Count;
                data.PackageCount = packages.Count;
                data.OrderCount = orders.Count;
                return Result<DashboardDataDTO>.Success(data);
            }
            catch (Exception ex)
            {
                return Result<DashboardDataDTO>.Failure($"Failed to load dashboard: {ex.Message}");
            }
        }
    }
}
