namespace Step1_Backend.DTOs.DashboardDTOs
{
    // Small DTO for Trainer stats
    public class TrainerStatDTO
    {
        public string Name { get; set; }
        public int ReservationCount { get; set; }
    }

    // Small DTO for Package stats
    public class PackageStatDTO
    {
        public string Title { get; set; }
        public int OrderCount { get; set; }
    }

    // The Main Wrapper DTO
    public class DashboardDataDTO
    {
        public List<TrainerStatDTO> TrainerStats { get; set; } = new();
        public List<PackageStatDTO> PackageStats { get; set; } = new();
    }
}
