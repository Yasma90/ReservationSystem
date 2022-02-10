using ReservationSystem.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReservationSysDbContext _context;
        public ContactRespository ContactRespository { get; set; }
        public ReservationRepository ReservationRespository { get; set; }
        private bool _disposed;

        public UnitOfWork(ReservationSysDbContext context, ContactRespository contactRepository, ReservationRepository reservationRepository)
        {
            _context = context;
            ContactRespository = contactRepository;
            ReservationRespository = reservationRepository;
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
