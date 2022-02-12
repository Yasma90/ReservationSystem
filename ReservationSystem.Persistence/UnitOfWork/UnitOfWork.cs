using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using ReservationSystem.Persistence;
using ReservationSystem.Persistence.Repository.Interfaces;
using ReservationSystem.Persistence.UnitOfWork.Interfaces;

namespace ReservationSystem.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly ReservationSysDbContext _context;
        public IContactRespository ContactRepository { get; set; }
        public IReservationRepository ReservationRepository { get; set; }
        public IContactTypeRepository ContactTypeRepository { get; set; }

        public UnitOfWork(ReservationSysDbContext context,
            IContactRespository contactRepository,
            IReservationRepository reservationRepository,
            IContactTypeRepository contactTypeRepository)
        {
            _context = context;
            ContactRepository = contactRepository;
            ReservationRepository = reservationRepository;
            ContactTypeRepository = contactTypeRepository;
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
        
        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
