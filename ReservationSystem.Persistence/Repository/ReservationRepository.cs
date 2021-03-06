using ReservationSystem.Domain.Models;
using ReservationSystem.Persistence.Repository.Interfaces;

namespace ReservationSystem.Persistence.Repository
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(ReservationSysDbContext context) : base(context)
        {
        }
    }
}
