using AutoMapper;
using Step1_Backend.DTOs.AuthDTOs;
using Step1_Backend.DTOs.PackageDTOs;
using Step1_Backend.DTOs.PaymentOrderDTOs;
using Step1_Backend.DTOs.ReservationDTOs;
using Step1_Backend.DTOs.TrainerDTOs;
using Step1_Backend.Models;

namespace Step1_Backend.Mapper
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<RegisterDTO, ApplicationUser>().ReverseMap();
            CreateMap<AddTrainerDTO, Trainer>().ReverseMap();
            CreateMap<UpdateTrainerDTO, Trainer>().ReverseMap();
            CreateMap<TrainerHomeCardDTO, Trainer>().ReverseMap();
            CreateMap<Trainer, TrainerDashboardCardDTO>()
                .ForMember(dest => dest.ReservationCount, opt => opt.MapFrom(src => src.Reservations != null ? src.Reservations.Count : 0));
            CreateMap<RateTrainerDTO, Trainer>().ReverseMap();
            CreateMap<AddReservationDTO, Reservation>().ReverseMap();
            CreateMap<AddPackageDTO, Package>().ReverseMap();
            CreateMap<UpdatePackageDTO, Package>().ReverseMap();
            CreateMap<PackageHomeCardDTO, Package>().ReverseMap();
            CreateMap<Package, PackageDashboardCardDTO>()
                .ForMember(dest => dest.OrderCount, opt => opt.MapFrom(src => src.paymentOrders != null ? src.paymentOrders.Count : 0));
            CreateMap<PlaceOrderDTO, PaymentOrder>().ReverseMap();
        }
    }
}
