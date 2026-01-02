
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
                var trainers = await _unit.TrainerRepo.GetAllWithReservationsAsync();
                data.TrainerStats = trainers.Select(t => new TrainerStatDTO
                {
                    Name = t.ArabicName,
                    ReservationCount = t.Reservations?.Count ?? 0
                }).ToList();

                // 2. Get Packages and count their payment orders
                var packages = await _unit.PackageRepo.GetAllWithOrdersAsync();
                data.PackageStats = packages.Select(p => new PackageStatDTO
                {
                    Title = p.Title,
                    OrderCount = p.paymentOrders?.Count ?? 0
                }).ToList();

                return Result<DashboardDataDTO>.Success(data);
            }
            catch (Exception ex)
            {
                return Result<DashboardDataDTO>.Failure($"Failed to load dashboard: {ex.Message}");
            }
        }
    }
}
