using Step1_Backend.Repositories.ReservationRepository;
using Step1_Backend.Repositories.TrainerRepository;

namespace Step1_Backend.UnitOfWorks
{
    public interface IUnitOfWork: IDisposable
    {
        ITrainerRepository TrainerRepo { get; }
        IReservationRepository ReservationRepo { get; }
        Task SaveAsync();
        void Dispose();
    }
}
