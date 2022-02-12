using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using ReservationSystem.Domain.Models;
using ReservationSystem.Persistence;
using ReservationSystem.Persistence.Repository.Interface;

namespace ReservationSystem.Persistence.Repository
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(ReservationSysDbContext context) : base(context)
        {
        }
    }
}
