using Step1_Backend.Models;
using Step1_Backend.Repositories.TrainerRepository;

namespace Step1_Backend.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private ITrainerRepository? trainerRepo;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ITrainerRepository TrainerRepo
        {
            get
            {
                if (trainerRepo == null)
                {
                    trainerRepo = new TrainerRepository(_dbContext);
                }
                ;
                return trainerRepo;
            }
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
