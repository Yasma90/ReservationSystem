using ReservationSystem.Domain.Models;
using ReservationSystem.Persistence.Repository.Interfaces;

namespace ReservationSystem.Persistence.Repository
{
    public class ContactTypeRepository : GenericRepository<ContactType>, IContactTypeRepository
    {
        public ContactTypeRepository(ReservationSysDbContext context) : base(context)
        {
        }
    }
}
