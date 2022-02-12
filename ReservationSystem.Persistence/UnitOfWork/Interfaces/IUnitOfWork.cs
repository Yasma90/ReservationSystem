using System;
using System.Threading.Tasks;
using ReservationSystem.Persistence.Repository.Interface;

namespace ReservationSystem.Persistence.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IContactRespository ContactRepository { get; set; }
        IReservationRepository ReservationRepository { get; set; }
        Task<int> SaveChangesAsync();
    }
}